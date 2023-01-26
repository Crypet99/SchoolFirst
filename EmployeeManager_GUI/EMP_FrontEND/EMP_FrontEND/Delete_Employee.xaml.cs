using EMP_Manager_Libary;
using System;
using System.Collections.Generic;
using System.Linq;
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

        string SearchValue;
        Employee_Manager employee = EmployeeManager.Instance;

        public Delete_Employee()
        {
            
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             SearchValue = Value.Text;
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            Employee[] temp = new Employee[0];
            Employee[] emp = employee.ReturnALLEmployees();
            int foundEmployees = 0;
            for (int i = 0; i < emp.Length; i++)
            {
                if (emp[i].Get_FirstName().Contains(SearchValue) ||
                   emp[i].Get_LastName().Contains(SearchValue) ||
                   emp[i].Get_EmployeeID().ToString().Contains(SearchValue))
                {
                    Array.Resize(ref temp, temp.Length+1);
                    temp[foundEmployees] = emp[i];   
                    foundEmployees++;
                }
            }
            

            if(temp.Length > 0) 
            
            {
                foreach(Employee employee in temp) 
                {
                    GridEmployee gridEmployee= new GridEmployee();
                    gridEmployee.employeeID = Convert.ToString(employee.Get_EmployeeID());
                    gridEmployee.FirstName = employee.Get_FirstName();
                    gridEmployee.LastName = employee.Get_LastName();
                    gridEmployee.BirthDate = employee.Get_Birthdate().ToLongDateString();
                    DataGridDelete.Items.Add(gridEmployee);

                }
            
            
            }
            
           

            
        }


        public class GridEmployee
        {
            public string? employeeID { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? BirthDate { get; set; }

        }

    }
}
