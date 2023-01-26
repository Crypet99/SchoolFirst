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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EMP_FrontEND
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Employee_Manager employee_Manager = EmployeeManager.Instance;
       public ushort PersonnelNumber;
        string path;

        public MainWindow()
        {
            InitializeComponent();
             path = "C:\\Users\\Student\\CHSU\\SchoolFirst\\Contacts.TXT";
            PersonnelNumber = employee_Manager.ReadContacts(path, PersonnelNumber);


        }

        private void Click_NewEmployee(object sender, RoutedEventArgs e)
        {
            NewEmployee newEmployee = new NewEmployee();
            newEmployee.ShowDialog();

        }

        private void Click_Show_Employee(object sender, RoutedEventArgs e)
        {
            Show_Employees show_Employees = new Show_Employees();
            show_Employees.ShowDialog();
        }

        private void Click_Save(object sender, RoutedEventArgs e )
        {
            employee_Manager.saveData(path);
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            Delete_Employee delete_Employee= new Delete_Employee();
            delete_Employee.ShowDialog();
        }
    }
}
