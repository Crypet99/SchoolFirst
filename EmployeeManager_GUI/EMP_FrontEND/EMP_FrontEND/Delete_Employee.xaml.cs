using EMP_Manager_Libary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EMP_FrontEND
{
    /// <summary>
    /// Interaktionslogik für Delete_Employee.xaml
    /// </summary>
    public partial class Delete_Employee : Window
    {
        public static int Readonly = 0;
        string SearchValue;
        Employee_Manager employee = EmployeeManager.Instance;
        List<GridEmployee> PersonToDelete = new List<GridEmployee>();
        List<Employee> EmployeeToDelete = new List<Employee>();

        public Delete_Employee()
        {

            InitializeComponent();

            DataGridDelete.DataContext = employees;



        }

        ObservableCollection<GridEmployee> employees = new ObservableCollection<GridEmployee>
        {

        };

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchValue = Value.Text;
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {


            // Mitarbeiter Suchen
            Employee[] temp = new Employee[0];
            Employee[] emp = employee.ReturnALLEmployees();
            int foundEmployees = 0;
            for (int i = 0; i < emp.Length; i++)
            {
                if (emp[i].Get_FirstName().ToLower().Contains(SearchValue.ToLower()) ||
                   emp[i].Get_LastName().ToLower().Contains(SearchValue.ToLower()) ||
                   emp[i].Get_EmployeeID().ToString().ToLower().Contains(SearchValue.ToLower()))
                {
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[foundEmployees] = emp[i];
                    foundEmployees++;
                }
            }


            if (temp.Length > 0)

            {
                foreach (Employee employee in temp)
                {
                    GridEmployee gridEmployee = new GridEmployee();
                    gridEmployee.employeeID = Convert.ToString(employee.Get_EmployeeID());
                    gridEmployee.FirstName = employee.Get_FirstName();
                    gridEmployee.LastName = employee.Get_LastName();
                    gridEmployee.BirthDate = employee.Get_Birthdate().ToLongDateString();

                    foreach (GridEmployee a in employees)
                    {
                        bool IsDouble = a.FirstName.ToLower() == gridEmployee.FirstName.ToLower() && a.LastName.ToLower() == gridEmployee.LastName.ToLower() && a.employeeID == gridEmployee.employeeID && a.BirthDate.ToLower() == gridEmployee.BirthDate.ToLower();
                        if (IsDouble)
                        {
                            return;
                        }


                    }

                    employees.Add(gridEmployee);


                }






            }





        }

        public class GridEmployee
        {
            public string? employeeID { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? BirthDate { get; set; }

            public bool Delete { get; set; }

        }



        private void ValueChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            GridEmployee gridEmployee = new GridEmployee();

            if (DataGridDelete.SelectedItems.Count > 0)
            {

                foreach (var obj in DataGridDelete.Items)
                {
                    gridEmployee = obj as GridEmployee;

                    if (gridEmployee != null && gridEmployee.Delete == true)
                    {
                        if (!IsDouble(gridEmployee)) PersonToDelete.Add(gridEmployee);
                    }

                    else if (gridEmployee != null && gridEmployee.Delete == false)
                    {
                        if (!IsDouble(gridEmployee)) PersonToDelete.Remove(gridEmployee);
                    }
                }
            }

        }



        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            foreach (GridEmployee gridEmployee in PersonToDelete)
            {
                foreach (Employee emp in employee.ReturnALLEmployees())
                {
                    bool Test = DiffIsDouble(gridEmployee, emp);
                    if (Test == true)
                    {
                        EmployeeToDelete.Add(emp);
                    }

                    else if(Test == false)
                    {
                        EmployeeToDelete.Remove(emp);,

                    }

                }
            }


            foreach (Employee _employee in EmployeeToDelete)
            {
                employee.DeleteEmployee(_employee);

            }

        }




        private bool IsDouble(GridEmployee gridEmployee)
        {

            foreach (GridEmployee e in PersonToDelete)
            {
                if (gridEmployee.FirstName == e.FirstName &&
                     gridEmployee.LastName == e.LastName &&
                      gridEmployee.employeeID == e.employeeID &&
                          gridEmployee.BirthDate == e.BirthDate)
                {
                    return true;
                }


            }
            return false;
        }

        private void Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool DiffIsDouble(GridEmployee gridEmployee, Employee emp)



        {
            bool Value = false;
            if (gridEmployee.FirstName == emp.Get_FirstName() &&
                       gridEmployee.LastName == emp.Get_LastName() &&
                        gridEmployee.employeeID == emp.Get_EmployeeID().ToString()
                          )
            {
                Value = true;
            }

            return Value;

        }



    }
}
