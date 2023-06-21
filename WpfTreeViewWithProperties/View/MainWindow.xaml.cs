using System.Windows;
using WpfTreeViewWithProperties.Core;
using WpfTreeViewWithPropertys.ViewModel;

namespace WpfTreeViewWithPropertys.View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)DataContext;
            viewModel.SelectedItem = (IHierarchical)e.NewValue;
        }
    }
}