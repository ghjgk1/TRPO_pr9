using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TRPO_pr9
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public Patient? CurrentPatient { get; set; }
        public Patient? UpdatedPatient { get; set; } = new();
        public ObservableCollection<Patient> Patients { get; set; } = new();

        public void CopyPatient (Patient copyingPatient, Patient copyablePatient)
        {
            copyingPatient.ID = copyablePatient.ID;
            copyingPatient.Name = copyablePatient.Name;
            copyingPatient.LastName = copyablePatient.LastName;
            copyingPatient.MiddleName = copyablePatient.MiddleName;
            copyingPatient.Birthday = copyablePatient.Birthday;
            copyingPatient.PhoneNumber = copyablePatient.PhoneNumber;
            copyingPatient.AppointmentStories = copyablePatient.AppointmentStories;
        }


        public EditPage(Patient patient, ObservableCollection<Patient> patients)
        {
            CurrentPatient = patient;
            CopyPatient(UpdatedPatient, patient);
            Patients = patients;
            InitializeComponent();
            DataContext = this;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (UpdatedPatient.Name != "" && UpdatedPatient.LastName != "" && UpdatedPatient.MiddleName != ""
                && UpdatedPatient.Birthday != "" && UpdatedPatient.LastAppointment != "")
            {
                int index = Patients.IndexOf(Patients.FirstOrDefault(p => p.ID == CurrentPatient.ID));

                string fileName = $"..\\net8.0-windows\\Patient\\P_{CurrentPatient.ID}.json";
                var options = new JsonSerializerOptions { WriteIndented = true };
                CopyPatient(CurrentPatient, UpdatedPatient);
                Patients[index] = CurrentPatient;
                var jsonString = JsonSerializer.Serialize(CurrentPatient, options);
                File.WriteAllText(fileName, jsonString);
                MessageBox.Show($"Пациент успешно отредактирован! Информация в P_{CurrentPatient.ID}",
                    "Редактирование", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            else
                MessageBox.Show("Все поля обязательны для заполнения",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
