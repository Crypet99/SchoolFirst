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
    /// Interaktionslogik für NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : Window
    {
        string firstName, lastName, birthday;
        ushort PersonnelNumber;
     

        public NewEmployee()
        {
            InitializeComponent();
            firstName= string.Empty;
            lastName= string.Empty;
            birthday= string.Empty;

            var MainWindow = new MainWindow();
            PersonnelNumber= MainWindow.PersonnelNumber;
            MainWindow.Close();
        }

        private void Textbox_TextChanged_FirstName(object sender, TextChangedEventArgs e)
        {
             firstName = FirstName.Text;
        }

        private void Textbox_TextChanged_LastName(object sender, TextChangedEventArgs e)
        {
             lastName = LastName.Text;
        }

        private void Click_Close(object sender, RoutedEventArgs e)
        {
           DialogResult= false;
        }

        private void Textbox_TextChanged_DateBirth(object sender, TextChangedEventArgs e)
        {
             birthday = Birthday.Text;
        }

        private void Click_AddEmployee(object sender, RoutedEventArgs e)
        {
            
            
            Employee employee = new Employee();
            Addresses addresses= new Addresses();
            
            employee = addresses.settingValues(PersonnelNumber, "", firstName, lastName,Convert.ToDateTime(birthday));
            Employee_Manager employeeManager = EmployeeManager.Instance;
            employeeManager.AddEmployee(employee);

            AddEmployee.Content= "Erfolgreich Hinzugefügt";

           
          

        }
    }
}
