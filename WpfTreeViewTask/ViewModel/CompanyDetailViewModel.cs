using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfTreeViewTask.Model;

namespace WpfTreeViewTask.ViewModel {
    public class CompanyDetailViewModel: ViewModelBase {
        private ObservableCollection<DepartmentViewModel> _departmentCollection;

        public ObservableCollection<DepartmentViewModel> DepartmentCollection
        {
            get => _departmentCollection;
            set
            {
                if (_departmentCollection == value) return;
                _departmentCollection = value;
                RaisePropertyChanged(() => DepartmentCollection);
            }
        }

        public CompanyDetailViewModel() {
            DepartmentCollection = new ObservableCollection<DepartmentViewModel>();
            List<Department> departmentList = GetDepartmentList();
            foreach (Department department in departmentList) {
                DepartmentCollection.Add(new DepartmentViewModel(department));
            }
        }

        #region Methods

        List<Employee> GetEmployeeList() {
            List<Employee> employeeList = new List<Employee>
            {
                new Employee() { EmployeeID = 1, EmployeeName = "Hiren" },
                new Employee() { EmployeeID = 2, EmployeeName = "Imran" },
                new Employee() { EmployeeID = 3, EmployeeName = "Shivpal" },
                new Employee() { EmployeeID = 4, EmployeeName = "Prabhat" },
                new Employee() { EmployeeID = 5, EmployeeName = "Sandip" },
                new Employee() { EmployeeID = 6, EmployeeName = "Chetan" },
                new Employee() { EmployeeID = 7, EmployeeName = "Jayesh" },
                new Employee() { EmployeeID = 8, EmployeeName = "Bhavik" },
                new Employee() { EmployeeID = 9, EmployeeName = "Amit" },
                new Employee() { EmployeeID = 10, EmployeeName = "Brijesh" }
            };
            return employeeList;
        }

        List<Department> GetDepartmentList() {
            List<Employee> employeeList = GetEmployeeList();
            List<Department> departmentList = new List<Department>
            {
                new Department()
                {
                    DepartmentID = 1,
                    DepartmentName = "Mocrosoft.Net",
                    EmployeeList = employeeList.Take(3).ToList()
                },
                new Department()
                {
                    DepartmentID = 2,
                    DepartmentName = "Open Source",
                    EmployeeList = employeeList.Skip(3).Take(3).ToList()
                },
                new Department()
                {
                    DepartmentID = 3,
                    DepartmentName = "Other",
                    EmployeeList = employeeList.Skip(6).Take(4).ToList()
                }
            };
            return departmentList;
        }

        #endregion
    }
}