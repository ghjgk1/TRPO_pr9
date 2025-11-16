using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TRPO_pr9
{
    public class Patient : BaseViewModel
    {
        private string _id;
        [JsonIgnore]
        public string ID
        {
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
        private string _middleName;
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (value != _middleName)
                {
                    _middleName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
        private string _birthday;
        public string Birthday
        {
            get => _birthday;
            set
            {
                if (value != _birthday)
                {
                    _birthday = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private List<Appointment> _appointmentStories = new List<Appointment>();
        public List<Appointment> AppointmentStories
        {
            get => _appointmentStories;
            set
            {
                if (value != _appointmentStories)
                {
                    _appointmentStories = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonIgnore]
        public string FullName => $"{LastName} {Name} {MiddleName}";

        [JsonIgnore]
        public string LastAppointment => _appointmentStories?.LastOrDefault()?.Date ?? "Не было осмотров";

        public void AddAppointment(Appointment appointment)
        {
            _appointmentStories.Add(appointment);
            OnPropertyChanged(nameof(AppointmentStories));
            OnPropertyChanged(nameof(LastAppointment));
        }
    }
}
