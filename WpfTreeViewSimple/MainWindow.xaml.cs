using System.Collections.ObjectModel;
using System.Windows;
using WpfTreeViewSimple.Model;

namespace WpfTreeViewSimple {
    // https://blogadminday.ru/zapolnenie-dannymi-treeview-v-wpf-ispolzuya-mvvm/
    // https://www.codeproject.com/Articles/236621/WPF-Treeview-Styling-and-Template-Binding-using-MV
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window {
        

        public MainWindow() {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}