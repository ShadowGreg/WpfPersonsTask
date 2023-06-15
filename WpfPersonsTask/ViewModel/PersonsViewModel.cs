using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using WpfPersonsTask.Data;

namespace WpfPersonsTask.ViewModel {
    public class PersonsViewModel: DependencyObject {
        //dependencyProperty
        public static readonly DependencyProperty FilterTextProperty = DependencyProperty.Register(
            nameof(FilterText), typeof(string), typeof(PersonsViewModel),
            new PropertyMetadata(string.Empty, FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            PersonsViewModel current = d as PersonsViewModel;
            if (current != null) {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterPersons;
            }
        }

        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            nameof(Items), typeof(ICollectionView), typeof(PersonsViewModel),
            new PropertyMetadata(null));

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public PersonsViewModel() {
            Items = CollectionViewSource.GetDefaultView(Person.GetPersons());
            Items.Filter = FilterPersons;
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
    }
}