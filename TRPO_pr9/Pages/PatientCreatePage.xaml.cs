using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TRPO_pr9
{
    /// <summary>
    /// Логика взаимодействия для PatientCreatePage.xaml
    /// </summary>
    public partial class PatientCreatePage : Page
    {
        public Doctor? CurrentDoctor { get; set; }
        public Patient? CreatedPatient { get; set; } = new Patient();
        public ObservableCollection<Patient> PatientsList { get; set; } = new();

        public PatientCreatePage(Doctor currentDoctor, ObservableCollection<Patient> Patients)
        {
            CurrentDoctor = currentDoctor;
            PatientsList = Patients;
            InitializeComponent();
            DataContext = CreatedPatient;
        }
        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (CreatedPatient?.Name != "" && CreatedPatient?.LastName != "" 
                && CreatedPatient?.MiddleName != "" && CreatedPatient?.Birthday != "")
            {
                int countFile = Directory.GetFiles("..\\net8.0-windows\\Patient").Length;
                string fileName = $"..\\net8.0-windows\\Patient\\P_{countFile.ToString("D7")}.json";
                CreatedPatient.ID = countFile.ToString("D7");
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(CreatedPatient, options);
                File.WriteAllText(fileName, jsonString);
                MessageBox.Show($"Добавление успешно! Информация в P_{countFile.ToString("D7")}",
                    "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                PatientsList.Add(CreatedPatient);
            }
            else
                MessageBox.Show("Все поля обязательны для заполнения",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
