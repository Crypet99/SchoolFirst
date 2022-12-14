using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Manager
{
    internal class Employee_Manager
    {
        Employee employee = new Employee();
        private List<Employee> Manager = new List<Employee>();


        //Mitarbeiter Hinzufügen
        public void AddEmployee(Employee e)
        {
            Manager.Add(e);

        }

        public Employee SearchEmployee()
        {
            Console.Clear();
            char select = ' ';


           
            Console.WriteLine("Möchten sie den Mitarbeiter nach der (P)ersonalnummer (N)amen oder (G)eburtsdatum suchen ?");
            select = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (select)
            {
                case 'N':
                case 'n':
                    {
                        Console.WriteLine("Bitte den Namen der Person eingeben ");
                        string searchValue = Console.ReadLine();
                        foreach (Employee em in Manager)
                        {
                            if (em.Get_LastName() == searchValue || em.Get_FirstName() == searchValue)
                            {
                                ShowEmployee(em);
                                return em;
                            }
                       
                        }
                        Console.WriteLine("Person konnte nicht gefunden werden");

                    }
                    break;

                case 'P':
                case 'p':
                    {
                        Console.WriteLine("Bitte die Personalnummer des Mitarbeiters eingeben : ");
                        ushort searchValue = Convert.ToUInt16(Console.ReadLine());

                        foreach (Employee em in Manager)
                        {

                            if (em.Get_EmployeeID() == searchValue)
                            {
                                ShowEmployee(em);
                                return em;
                            }
                           
                        }
                        Console.WriteLine("Person konnte nicht gefunden werden");
                    }
                    break;

                case 'G':
                case 'g':
                    {
                        try
                        {
                            Console.WriteLine("Bitte das Geburtsdatum des Mitarbeiters eingeben : ");
                            DateTime searchValue = Convert.ToDateTime(Console.ReadLine());

                            foreach (Employee em in Manager)
                            {

                                if (em.Get_Birthdate() == searchValue)
                                {
                                    ShowEmployee(em);
                                    return em;
                                }

                            }
                            Console.WriteLine("Person konnte nicht gefunden werden");
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                    break;

                default:
                    Console.WriteLine("Ungültige Eingabe"); break;

            }
          
          
            return employee;


        }

        public void DeleteEmployee()
        {
           Employee employee = SearchEmployee();
            Console.WriteLine("Sicher das sie den Mitarbeiter Löschen Wollen ? J/N");
            char select = Console.ReadKey().KeyChar;
            switch(select)
            {
                case 'j':
                case 'J':
                    {
                        Manager.Remove(employee);
                    }
                    break;

                case 'n':
                case 'N':
                    {
                        Console.WriteLine("Vorgang Wird abgebrochen.");
                    }break;

                     default: Console.WriteLine("Ungültige Eingabe"); break;
            }
            

        }

        // Zeige Alle Mitarbeiter
        public void ShowAllEmployees()
        {

            if (Manager.Count < 1)
            {
                Console.WriteLine("Keine Daten Vorhanden");
            }

            foreach (Employee e in Manager)
            {
                ShowEmployee(e);
                

            }

            

        }

        private void ShowEmployee(Employee e)
        {
            Console.WriteLine("Mitarbeiternummer : " + e.Get_EmployeeID());
            Console.WriteLine("Mitarbeitername : " + e.Get_FirstName() + " " + e.Get_LastName());
            Console.WriteLine("Geburtsdatum : " + e.Get_Birthdate().ToLongDateString());
            Console.WriteLine("Alter : " + e.Get_Age());
            Console.WriteLine("Anzahl Freier Urlaubstage : " + e.Get_HolidaysAvailable());
            Console.WriteLine("Anzahl Verbrauchter Urlaubstage : " + e.Get_UsedHolidays());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public  ushort ReadContacts(string Path , ushort Personnelnumber)
        {
            string[] contacts;
            if (File.Exists(Path))
            {
                
                Addresses addresses= new Addresses();   
                contacts = File.ReadAllLines(Path);

                for (int i = 0; i < contacts.Length; i++)
                {
                    Employee employee = new Employee();
                    string[] con = contacts[i].Split(';');
                    employee.Set_EmployeeID(Personnelnumber);
                    employee.SET_FirstName(con[0]);
                    employee.SET_LastName(con[1]);
                    employee.Set_Birthdate(Convert.ToDateTime(con[2]));
                    employee.Set_Age(addresses.SetAge(employee, Convert.ToDateTime(con[2])));
                    employee.Set_HolidaysAvailable(addresses.SetHolidays(employee, Convert.ToDateTime(con[2])));
                    Manager.Add(employee);

                    Personnelnumber++;
                }
                return Personnelnumber;

            }
            return 0;
        }



    }
}
