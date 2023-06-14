using System.Collections.ObjectModel;
using WpfTreeViewTask.Model;

namespace WpfTreeViewTask.ViewModel {
    public class DepartmentViewModel: ViewModelBase {
        public Department Department { get; protected set; }

        private ObservableCollection<EmployeeViewModel> _employeeCollection;

        public ObservableCollection<EmployeeViewModel> EmployeeCollection
        {
            get => _employeeCollection;
            set
            {
                if (_employeeCollection == value) return;
                _employeeCollection = value;
                RaisePropertyChanged(() => EmployeeCollection);
            }
        }

        public int DepartmentID
        {
            get => Department.DepartmentID;
            set
            {
                if (Department.DepartmentID == value) return;
                Department.DepartmentID = value;
                RaisePropertyChanged(() => DepartmentID);
            }
        }

        public string DepartmentName
        {
            get => Department.DepartmentName;
            set
            {
                if (Department.DepartmentName == value) return;
                Department.DepartmentName = value;
                RaisePropertyChanged(() => DepartmentName);
            }
        }

        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked == value) return;
                _isChecked = value;
                RaisePropertyChanged(() => IsChecked);
                OnCheckChanged();
            }
        }

        private void OnCheckChanged() {
            foreach (EmployeeViewModel employeeViewModel in EmployeeCollection) {
                employeeViewModel.IsChecked = IsChecked;
            }
        }

        public DepartmentViewModel(Department department) {
            Department = department;
            EmployeeCollection = new ObservableCollection<EmployeeViewModel>();
            foreach (Employee employee in Department.EmployeeList) {
                EmployeeCollection.Add(new EmployeeViewModel(employee));
            }
        }
    }
}