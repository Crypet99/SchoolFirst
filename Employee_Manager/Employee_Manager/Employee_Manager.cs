using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee_Manager
{
    internal class Employee_Manager
    {
        Employee employee = new Employee();
        Addresses addresses = new Addresses();
        private List<Employee> Manager = new List<Employee>();


        //Mitarbeiter Hinzufügen
        public void AddEmployee(Employee e)
        {
            foreach (Employee em in Manager)
            {
                if (em == e)
                {
                    Console.WriteLine("Person existiert Bereits, Mitarbeiter wird nicht Hinzugefügt.");
                    return;
                }
            }
            Manager.Add(e);
            Console.WriteLine("Mitarbeiter mit der PersonalNummer : {0} hinzugefügt", e.Get_EmployeeID());


        }

        // Suche Mitarbeiter
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
                        Console.WriteLine("Person {0} konnte nicht gefunden werden", searchValue);

                    }
                    break;

                case 'P':
                case 'p':
                    {
                        Console.WriteLine("Bitte die Personalnummer des Mitarbeiters eingeben : ");
                        string searchValue = Console.ReadLine();
                        if (addresses.IsNumeric(searchValue) || searchValue != "")
                        {
                            foreach (Employee em in Manager)
                            {

                                if (em.Get_EmployeeID() == Convert.ToUInt16(searchValue))
                                {
                                    ShowEmployee(em);
                                    return em;
                                }

                            }
                            Console.WriteLine("Person mit der Personalnummer : {0} konnte nicht gefunden werden", searchValue);
                        }
                        else { Console.WriteLine("Personalnummer Ungültig"); break; }
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
            Employee employee = new Employee();
            return employee;


        }

        //Lösche Mitarbeiter
        public void DeleteEmployee()
        {
            Employee employee = SearchEmployee();
            if (employee.Get_EmployeeID() < 9999)
            {
                Console.WriteLine("Sicher das sie den Mitarbeiter Löschen Wollen ? J/N");

                char select = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (select)
                {
                    case 'j':
                    case 'J':
                        {
                            Manager.Remove(employee);
                            Console.WriteLine("MMitarbeiter wurde Gelöscht.");
                        }
                        break;

                    case 'n':
                    case 'N':
                        {
                            Console.WriteLine("Vorgang Wird abgebrochen.");
                        }
                        break;

                    default: Console.WriteLine("Ungültige Eingabe"); break;
                }
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

        // Gib den Mitarbeiter aus
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

        //Kontakte aus TXT Datei Auslesen
        public ushort ReadContacts(string Path, ushort Personnelnumber)
        {
            string[] contacts;
            if (File.Exists(Path))
            {

                Addresses addresses = new Addresses();
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
                    AddEmployee(employee);

                    Personnelnumber++;
                }
                return Personnelnumber;

            }
            return 0;
        }

        //Urlaub Beantragen
        public void HolidayOff()
        {
            Employee e = SearchEmployee();
            DateTime holidaybegin;
            DateTime holidayends;

            if (e.Get_EmployeeID() < 9999)
            {

                do
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    ShowEmployee(e);
                    holidaybegin = addresses.SetSpecificDate("Wann soll ihr Urlaub Beginnen ?");
                    if (!ValidHoliday(holidaybegin, holidayends = DateTime.Now.AddDays(1), e)) { continue; }
                    holidayends = addresses.SetSpecificDate("Und Wann soll der Urlaub Enden ?");
                    if (!ValidHoliday(holidaybegin, holidayends, e)) { continue; }
                    break;
                } while (true);

                Console.WriteLine("Dein Urlaub geht vom {0} bis zum {1} Richtig ? J/N Verbrauchte Tage: {2}", holidaybegin.ToLongDateString(), holidayends.ToLongDateString(), holidayends.Subtract(holidaybegin).Days);

                char J_N = Console.ReadKey().KeyChar;
                Console.Clear();
                if (J_N == 'J' || J_N == 'j')
                {
                    int UsedDays = holidayends.Subtract(holidaybegin).Days;
                    if (UsedDays == 0) { UsedDays = 1; }
                    int CurrentHollidays = e.Get_HolidaysAvailable();
                    int HolidaysAvailable = CurrentHollidays - UsedDays;
                    e.Set_HolidaysAvailable((ushort)HolidaysAvailable);
                    e.Set_UsedHolidays((ushort)holidayends.Subtract(holidaybegin).Days);

                }

                else if (J_N == 'N' || J_N == 'n')
                {
                    return;
                }
                else { return; }


            }

        }

        private bool ValidHoliday(DateTime holidayBegin, DateTime holidayEnd, Employee e)
        {
            int holiDays = holidayEnd.Subtract(holidayBegin).Days;

            System.Threading.Thread.Sleep(1);
            if (holidayBegin < DateTime.Now || holidayEnd < DateTime.Now) { Console.WriteLine("Der Urlaub kann nicht rückwirkend beantragt werden."); return false; }
            if (e.Get_HolidaysAvailable() - holiDays < 0) { Console.WriteLine("Zu wenig Urlaubstage Verfügbar."); return false; }
            return true;

        }



    }
}
