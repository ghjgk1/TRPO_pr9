namespace TRPO_pr9
{
    public class Appointment : BaseViewModel
    {
        private string _date;
        public string Date
        {
            get => _date;
            set
            {
                if (value != _date)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        } 

        private string _doctorID;
        public string DoctorID
        {
            get => _doctorID;
            set
            {
                if (value != _doctorID)
                {
                    _doctorID = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _diagnosis;
        public string Diagnosis
        {
            get => _diagnosis;
            set
            {
                if (value != _diagnosis)
                {
                    _diagnosis = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _recomendations;
        public string Recomendations
        {
            get => _recomendations;
            set
            {
                if (value != _recomendations)
                {
                    _recomendations = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
