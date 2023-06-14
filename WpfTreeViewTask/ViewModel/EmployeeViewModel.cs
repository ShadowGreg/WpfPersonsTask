using WpfTreeViewTask.Model;

namespace WpfTreeViewTask.ViewModel {
    public class EmployeeViewModel: ViewModelBase {
        public Employee Employee { get; protected set; }

        public int EmployeeID
        {
            get => Employee.EmployeeID;
            set
            {
                if (Employee.EmployeeID != value) {
                    Employee.EmployeeID = value;
                    RaisePropertyChanged(() => EmployeeID);
                }
            }
        }

        public string EmployeeName
        {
            get => Employee.EmployeeName;
            set
            {
                if (Employee.EmployeeName == value) return;
                Employee.EmployeeName = value;
                RaisePropertyChanged(() => EmployeeName);
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
            }
        }

        public EmployeeViewModel(Employee employee) {
            Employee = employee;
            IsChecked = false;
        }
    }
}