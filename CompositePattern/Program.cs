/**
 * Author : Manikandan M
 * Description: Sample program for composite pattern
 */
using System;
using System.Collections.Generic;
namespace CompositePattern
{
    class Program
    {
        /// <summary>
        /// 'Component' Treenode
        /// </summary>
        interface IEmployee
        {
            void DisplayEmployeeDetails();
        }

        /// <summary>
        /// 'Leaf' Class
        /// </summary>
        class Employee : IEmployee
        {
            private long empId;
            private string name;
            private string designation;
            private string experience;

            /// <summary>
            /// Get employee details with help of parameter constructor
            /// </summary>
            /// <param name="empId"></param>
            /// <param name="name"></param>
            /// <param name="designation"></param>
            /// <param name="experience"></param>
            public Employee(long empId, string name, string designation, string experience)
            {
                this.empId = empId;
                this.name = name;
                this.designation = designation;
                this.experience = experience;
            }

            /// <summary>
            /// Display employee details
            /// </summary>
            public void DisplayEmployeeDetails()
            {
                Console.WriteLine(string.Format("Emp Id: {0}, Employee Name: {1}, Designation: {2}, Experience: {3}\n", empId, name, designation, experience));
            }
        }

        /// <summary>
        /// 'Composite' Class
        /// </summary>
        class Administrator : IEmployee
        {
            private List<IEmployee> employeeList = new List<IEmployee>();

            /// <summary>
            /// Add new employee
            /// </summary>
            /// <param name="emp"></param>
            public void addEmployee(IEmployee emp)
            {
                employeeList.Add(emp);
            }

            /// <summary>
            /// Remove existing employee
            /// </summary>
            /// <param name="emp"></param>
            public void removeEmployee(IEmployee emp)
            {
                employeeList.Remove(emp);
            }

            /// <summary>
            /// display entire employee details
            /// </summary>
            public void DisplayEmployeeDetails()
            {
                foreach(IEmployee emp in employeeList)
                {
                    emp.DisplayEmployeeDetails();
                }
            }
        }

        //client or owner
        static void Main(string[] args)
        {
            Administrator administrator = new Administrator();
            
            //add ceo information
            Employee ceo = new Employee(100, "Kumar", "CEO", "24 Years");
            administrator.addEmployee(ceo);

            //add director information
            Employee hrDirector = new Employee(101, "Vimal", "HR Director", "20 Years");
            Employee itDirector = new Employee(102, "Naveen", "IT Director", "18 Years");
            Employee salesDirector = new Employee(103, "Pavan", "Sales Director", "22 Years");
            administrator.addEmployee(hrDirector);
            administrator.addEmployee(itDirector);
            administrator.addEmployee(salesDirector);

            //add manager information
            Employee manager_1 = new Employee(104, "Ravi", "Manager", "15 Years");
            Employee manager_2 = new Employee(105, "Mani", "Manager", "13 Years");
            administrator.addEmployee(manager_1);
            administrator.addEmployee(manager_2);

            //add team leader information
            Employee teamleader_1 = new Employee(106, "Kannan", "Team Leader", "10 Years");
            Employee teamleader_2 = new Employee(107, "Kumaran", "Team Leader", "8 Years");
            administrator.addEmployee(teamleader_1);
            administrator.addEmployee(teamleader_2);

            //add developer information
            Employee developer_1 = new Employee(108, "Kathir", "Developer", "7 Years");
            Employee developer_2 = new Employee(109, "Arun Pandiyan", "Developer", "5 Years");
            administrator.addEmployee(developer_1);
            administrator.addEmployee(developer_2);

            administrator.DisplayEmployeeDetails();
            Console.Write("Press any key to exist...");
            Console.ReadKey();
        }
    }
}
