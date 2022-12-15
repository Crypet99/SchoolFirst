using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Manager
{
    internal class Addresses
    {

        // Setze Eigenschaften zur Person
        public Employee settingValues(ushort PersonnelNumber, string optionial = "")
        {
            Employee employee = new Employee();



            employee.Set_EmployeeID(PersonnelNumber);
            employee.SET_FirstName(Setname("Vornamen"));
            employee.SET_LastName(Setname("Nachnamen"));
            employee.Set_Birthdate(SetSpecificDate("Nenne das Geburtsdatum in dem Format 'YYYY.MM.TT oder TT.MM.YYYY': "));
            employee.Set_Age(SetAge(employee));
            employee.Set_HolidaysAvailable(SetHolidays(employee));


            return employee;
        }


        // Setting Funktionen
        private string Setname(string template)
        {


            string value;
            while (true)
            {
                try
                {
                    Console.WriteLine("Sehr geehrter User bitte geben sie uns den {0} ihres Mitarbeiters :", template);
                    value = Console.ReadLine();
                    if (IsNumeric(value))
                    {
                        Console.Clear();
                        Console.WriteLine("Bitte einen Gültigen Namen eingeben");
                        continue;

                    }
                    else if (!IsNumeric(value))
                    {
                        Console.Clear();
                        return value;
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }

            }

        }
        public DateTime SetSpecificDate(string Template)
        {

            while (true)
            {
                try
                {
                    DateTime Birthdate;
                    Console.WriteLine(Template);
                    Birthdate = Convert.ToDateTime(Console.ReadLine());

                    if (!ValidBirth(Birthdate)) { continue; }
                    else { return Birthdate; }
                }


                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }

        }
        public bool IsNumeric(string text)
        {
            return text.All(char.IsNumber);
        }

        private bool ValidBirth(DateTime Birthdate)
        {
            if (Birthdate.Year <= 1900 || (Birthdate.Month > DateTime.Now.Month && Birthdate.Year >= DateTime.Now.Year)) { Console.WriteLine("Alter ist nicht Pausible."); return false; }
            return true;
        }

        public ushort SetAge(Employee employee, DateTime? optional = null)
        {
            DateTime Today = DateTime.Today;
            ushort value;
            if (optional != null)
            {
                value = Convert.ToUInt16(Today.Subtract(optional.Value).Days / 365);
            }
            else
            {
                value = Convert.ToUInt16(Today.Subtract(employee.Get_Birthdate()).Days / 365);
            }

            return value;
        }
        public ushort SetHolidays(Employee employee, DateTime? optional = null)
        {
            DateTime Check_Age = new DateTime(DateTime.Now.Year, 01, 01);

            if (optional != null)
            {
                if (Check_Age.Subtract(optional.Value).Days / 365 > 51)
                {
                    return 32;
                }

                else
                    return 30;

            }


            if (Check_Age.Subtract(employee.Get_Birthdate()).Days / 365 > 51)
            {
                return 32;
            }

            else
                return 30;
        }
    }


}
