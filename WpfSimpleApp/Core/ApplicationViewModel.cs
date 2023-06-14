using System.Collections.ObjectModel;
using System.Linq;

namespace WpfSimpleApp.Core {
    public class ApplicationViewModel: BaseModel {
        private  PhoneB _selectedPhoneB;
        public   PhoneB SelectedPhoneB { 
            get=>_selectedPhoneB;
            set
            {
                _selectedPhoneB.SetProp(value);
                OnPropertyChanged("SelectedPhone");
            }
        }
        public static ObservableCollection<PhoneB> Phones { get; set; }

        public ApplicationViewModel() {
            Phones = new ObservableCollection<PhoneB>
            {
                new PhoneB{Name = "Nikita", Phone = "890762345812345687"},
                new PhoneB{Name = "Vika", Phone = "890324523434545687"},
                new PhoneB{Name = "Misha", Phone = "890765674567456787"},
                new PhoneB{Name = "Nina", Phone = "890762348907890687"},
                new PhoneB{Name = "Marina", Phone = "890762345235245687"},
                new PhoneB{Name = "Lena", Phone = "890123890345345687"}
            };
            _selectedPhoneB = Phones.First();
        }
    }
}