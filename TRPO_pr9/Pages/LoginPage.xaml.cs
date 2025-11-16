using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO;


namespace TRPO_pr9
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Doctor LoginDoctor = new Doctor();
        public LoginPage()
        {
            InitializeComponent();
            DataContext = LoginDoctor;
        }

        private void UserRegButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void UserEnterButton_Click(object sender, RoutedEventArgs e)
        {
            string ID = LoginDoctor.ID;
            string fileName = $"..\\net8.0-windows\\Doctor\\D_{LoginDoctor.ID}.json";
            if (LoginDoctor.ID == "" || LoginDoctor.Password == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Не существует такого пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var jsonString = File.ReadAllText(fileName);
            if (JsonSerializer.Deserialize<Doctor>(jsonString).Password != LoginDoctor.Password)
            {
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            LoginDoctor = JsonSerializer.Deserialize<Doctor>(jsonString);
            LoginDoctor.ID = ID;
            MessageBox.Show("Вход выполнен успешно!", "Вход", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new MainPage(LoginDoctor));
        }

        private void ChangeThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeHelper.Toggle();
        }
    }
}
