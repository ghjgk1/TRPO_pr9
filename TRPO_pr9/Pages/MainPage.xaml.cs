using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TRPO_pr9
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public ObservableCollection<Patient> Patients { get; set; } = new();
        public Doctor? CurrentDoctor { get; set; }
        public Patient? SelectedPatient { get; set; }
        private void LoadPatient()
        {
            string[] files = Directory.GetFiles("..\\net8.0-windows\\Patient");
            foreach (string file in files)
            {
                string JsonString = File.ReadAllText(file);
                Patient patient = JsonSerializer.Deserialize<Patient>(JsonString);
                patient!.ID = Path.GetFileNameWithoutExtension(file).Substring(2);
                Patients.Add(patient);
            }
        }

        public MainPage(Doctor currentDoctor)
        {
            LoadPatient();
            CurrentDoctor = currentDoctor;
            InitializeComponent();
            DataContext = this;
        }

        private void PatientCreateButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientCreatePage(CurrentDoctor, Patients));
        }

        private void InspectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
                NavigationService.Navigate(new InspectionPage(CurrentDoctor, SelectedPatient, Patients));
            else
                MessageBox.Show("Сначала выберите пациента",
                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Хотите ли выйти", "Потдверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                NavigationService.GoBack();
        }

        private void PatientEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
                NavigationService.Navigate(new EditPage(SelectedPatient, Patients));
            else 
                MessageBox.Show("Сначала выберите пациента",
                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
