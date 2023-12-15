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
using System.Xml;


namespace EMP_FrontEND
{
    /// <summary>
    /// Interaktionslogik für Show_Employees.xaml
    /// </summary>
    public partial class Show_Employees : Window
    {
        public Show_Employees()
        {
            InitializeComponent();

            Employee_Manager emp = EmployeeManager.Instance;
            GridEmployee EmployeeGrid = new GridEmployee();

            foreach (Employee e in emp.ReturnALLEmployees())
            {
                EmployeeGrid = new GridEmployee();
                EmployeeGrid.employeeID = e.Get_EmployeeID().ToString();
                EmployeeGrid.FirstName = e.Get_FirstName();
                EmployeeGrid.LastName = e.Get_LastName();
                EmployeeGrid.BirthDate = e.Get_Birthdate().ToLongDateString();


                DataGridEmployee.Items.Add(EmployeeGrid);
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

