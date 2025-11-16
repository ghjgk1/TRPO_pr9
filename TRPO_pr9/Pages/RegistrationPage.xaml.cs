using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TRPO_pr9
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Doctor RegisteredDoctor = new ();
        
        public RegistrationPage()
        {
            InitializeComponent();
            DataContext = RegisteredDoctor;
        }

        private void UserRegButton_Click(object sender, RoutedEventArgs e)
        {
            if (RegisteredDoctor.Name != "" && RegisteredDoctor.LastName != "" && RegisteredDoctor.MiddleName != "" && RegisteredDoctor.Password != ""
                && RegisteredDoctor.Specialization != "" && RegisteredDoctor.Password == RegisteredDoctor.Сonfirmation)
            {
                int countFile = Directory.GetFiles("..\\net8.0-windows\\Doctor").Length;
                string fileName = $"..\\net8.0-windows\\Doctor\\D_{countFile.ToString("D5")}.json";
                RegisteredDoctor.ID = countFile.ToString("D5");
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(RegisteredDoctor, options);
                File.WriteAllText(fileName, jsonString);
                MessageBox.Show($"Регистрация успешна! Ваш логин D_{countFile.ToString("D5")}",
                    "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            else
                MessageBox.Show("Все поля обязательны для заполнения. Пароль должен совпадать с подтверждением",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ChangeThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeHelper.Toggle();
        }
    }
}
