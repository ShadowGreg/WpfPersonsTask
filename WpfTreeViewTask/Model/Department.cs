using System.Collections.Generic;

namespace WpfTreeViewTask.Model {
    public class Department {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee> EmployeeList { get; set; }
    }
}