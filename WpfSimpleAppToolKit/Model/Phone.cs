using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfSimpleAppToolKit.Model {
    public class Phone: ObservableObject {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(_name))]
        private string? _name;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(_phone))]
        private string? _phone;

        public Phone(string name, string phone) {
            _name = name;
            _phone = phone;
        }
    }
}