using System.Text.Json.Serialization;

namespace TRPO_pr9
{
     public class Doctor : BaseViewModel
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
                }
            }
        }
        private string _specialization;
        public string Specialization
        {
            get => _specialization;
            set
            {
                if (value != _specialization)
                {
                    _specialization = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _confirmation;
        [JsonIgnore]
        public string Сonfirmation
        {
            get => _confirmation;
            set
            {
                if (value != _confirmation)
                {
                    _confirmation = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
