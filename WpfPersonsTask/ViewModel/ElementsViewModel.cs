using System.ComponentModel;
using System.Windows.Data;
using WpfPersonsTask.Data;

namespace WpfPersonsTask.ViewModel {
    public class ElementsViewModel: INotifyPropertyChanged {
        private string _filterText;
        private ICollectionView _items;
        private Person _selectedItem;

        public string FilterText
        {
            get => _filterText; 
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));

                Items.Filter = null;
                Items.Filter = FilterPersons;
            }
        }

        public ICollectionView Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public Person SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = null;
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ElementsViewModel() {
            Items = CollectionViewSource.GetDefaultView(Person.GetPersons());
            Items.Filter = FilterPersons;
            SelectedItem = (Person)Items.CurrentItem;
        }

        private bool FilterPersons(object obj) {
            bool result = true;
            Person current = obj as Person;
            if (!string.IsNullOrWhiteSpace(FilterText) && current != null && !current.Name.Contains(FilterText) &&
                !current.LastName.Contains(FilterText)) {
                result = false;
            }

            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}