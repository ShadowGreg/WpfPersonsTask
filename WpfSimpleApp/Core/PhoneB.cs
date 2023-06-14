namespace WpfSimpleApp.Core {
    public class PhoneB: BaseModel {

        private string _phone;
        public string Phone
        {
            get => _phone; 
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public void SetProp(PhoneB phoneItem) {
            Name = phoneItem.Name;
            Phone = phoneItem.Phone;
        }
    }
}