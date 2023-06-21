using System.ComponentModel;

namespace WpfTreeViewWithPropertys.ViewModel {
    public class ViewModelBase: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyChangedEvent) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyChangedEvent));
            }
        }
        
    }
}