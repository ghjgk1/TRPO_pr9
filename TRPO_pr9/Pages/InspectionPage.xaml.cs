using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace TRPO_pr9
{
    /// <summary>
    /// Логика взаимодействия для InspectionPage.xaml
    /// </summary>
    public partial class InspectionPage : Page
    {
        public Doctor CurrentDoctor { get; set; }
        public Patient CurrentPatient { get; set; }
        public Appointment CurrentAppointment { get; set; } = new ();
        public ObservableCollection<Patient> Patients { get; set; } = new();


        public ObservableCollection<Appointment> Appointments { get; set; } = new();

        public InspectionPage(Doctor currentDoctor, Patient currentPatient, ObservableCollection<Patient> patients)
        {

            CurrentDoctor = currentDoctor;
            CurrentPatient = currentPatient;
            Appointments = new ObservableCollection<Appointment>(CurrentPatient.AppointmentStories ?? new List<Appointment>());
            Patients = patients;
            InitializeComponent();
            DataContext = this;
        }

        private void InspectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentAppointment.Diagnosis != null && CurrentAppointment.Recomendations != null)
            {
                CurrentPatient.AppointmentStories ??= new List<Appointment>();

                var newAppointment = new Appointment
                {
                    Diagnosis = CurrentAppointment.Diagnosis,
                    Recomendations = CurrentAppointment.Recomendations,
                    DoctorID = CurrentDoctor.ID,
                    Date = DateTime.Today.ToString("d")
                };

                Appointments.Add(newAppointment);
                CurrentPatient.AddAppointment(newAppointment);

                var options = new JsonSerializerOptions { WriteIndented = true };
                string patientJsonString = JsonSerializer.Serialize(CurrentPatient, options);

                string fileName = $"..\\net8.0-windows\\Patient\\P_{CurrentPatient.ID}.json";
                File.WriteAllText(fileName, patientJsonString);

                MessageBox.Show($"Информация об осмотре изменена успешно! Информация в P_{CurrentPatient.ID}",
                    "Осмотр", MessageBoxButton.OK, MessageBoxImage.Information);

                int index = Patients.IndexOf(Patients.FirstOrDefault(p => p.ID == CurrentPatient.ID));
                Patients[index] = CurrentPatient;

            }
            else
                MessageBox.Show("Все поля обязательны для заполнения",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage(CurrentPatient, Patients));
        }
    }
}
