using EMP_Manager_Libary;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMP_Manager_Libary
{
    public class List_Manager
    {
        Employee employee = new Employee();
        Addresses addresses = new Addresses();
       // Dienstplan Timeplan = new Dienstplan();
        private List<Employee> Manager = new List<Employee>();


        #region Employees

        // Mitarbeiter Hinzufügen
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
            Console.ForegroundColor = ConsoleColor.Red;
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
                        Console.Clear();
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
                        Console.Clear();
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
                            Console.Clear();

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
                            Console.WriteLine("Mitarbeiter wurde Gelöscht.");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mitarbeiternummer : " + e.Get_EmployeeID());
            Console.WriteLine("Mitarbeitername : " + e.Get_FirstName() + " " + e.Get_LastName());
            Console.WriteLine("Geburtsdatum : " + e.Get_Birthdate().ToLongDateString());
            Console.WriteLine("Alter : " + e.Get_Age());
            Console.WriteLine("Anzahl Freier Urlaubstage : " + e.Get_HolidaysAvailable());
            Console.WriteLine("Anzahl Verbrauchter Urlaubstage : " + e.Get_UsedHolidays());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
        }

        #endregion

        #region Holidays
        public void HolidayOff()
        {
            Employee e = SearchEmployee();
            DateTime holidaybegin;
            DateTime holidayends;

            if (e.Get_EmployeeID() < 9999)
            {

                do
                {
                    Thread.Sleep(1000);
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

                    int index = 0;

                    foreach (DateTime d in e._Holidays)
                    {

                        if (d.Year > 2000) { index++; }
                    }
                    for (DateTime d1 = holidaybegin; d1 <= holidayends; d1 = d1.AddDays(1))
                    {
                        e._Holidays[index] = d1;
                        index++;
                    }

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


            if (holidayBegin < DateTime.Now || holidayEnd < DateTime.Now) { Console.WriteLine("Der Urlaub kann nicht rückwirkend beantragt werden."); return false; }
            if (e.Get_HolidaysAvailable() - holiDays < 0) { Console.WriteLine("Zu wenig Urlaubstage Verfügbar."); return false; }
            return true;

        }
        #endregion

        #region Save and Read Contacts  
        public void saveData(string path)
        {
            try
            {
                if (path != null || path != "")
                {

                    StringBuilder sb = new StringBuilder();
                    foreach (Employee e in Manager)
                    {




                        sb.Append(e.Get_FirstName() + ";" + e.Get_LastName() + ";" + e.Get_Birthdate().ToShortDateString() + ";" + e.Get_UsedHolidays() + ";" + e.Get_HolidaysAvailable() + ";");
                        for (int i = 0; i < e._Workdays.Length; i++)
                        {
                            if (e._Workdays[i].Year > 2000) { sb.Append(e._Workdays[i].ToShortDateString() + ";"); }
                        }

                        sb.Append("split" + ";");
                        for (int i = 0; i < e._Holidays.Length; i++)
                        {
                            if (e._Holidays[i].Year > 2000) { sb.Append(e._Holidays[i].ToShortDateString() + ";"); }
                        }
                        sb.Append(Environment.NewLine);


                    }
                    string EncodeData = sb.ToString();
                    byte[] bytes = Encoding.UTF8.GetBytes(EncodeData);
                    string CodedData = Convert.ToBase64String(bytes);

                    // if (CodedData == "" || CodedData == null) { return; }

                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine(CodedData);
                    };




                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public ushort ReadContacts(string Path, ushort PersonnelNumber)
        {

            if (File.Exists(Path))
            {

                string Base64Data = File.ReadAllText(Path);
                if (Base64Data != "" || Base64Data.Length != 0)
                {
                    Addresses addresses = new Addresses();

                    byte[] Base64bytes = Convert.FromBase64String(Base64Data);
                    string Datastring = Encoding.UTF8.GetString(Base64bytes);
                    string[] Dataarray = Datastring.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < Dataarray.Length; i++)
                    {
                        int temp = 0;
                        Employee employee = new Employee();
                        string[] con = Dataarray[i].Split(';');
                        employee.Set_EmployeeID(PersonnelNumber);
                        employee.SET_FirstName(con[0]);
                        employee.SET_LastName(con[1]);
                        employee.Set_Birthdate(Convert.ToDateTime(con[2]));
                        employee.Set_Age(addresses.SetAge(employee, Convert.ToDateTime(con[2])));
                        employee.Set_UsedHolidays(Convert.ToUInt16(con[3]));
                        employee.Set_HolidaysAvailable(Convert.ToUInt16(con[4]));
                        for (int y = 5; y < con.Length - 1; y++)
                        {
                            if (con[y] == "split") { temp = y + 1; break; }
                            employee._Workdays[temp] = Convert.ToDateTime(con[y]);
                            temp++;
                        }
                        int temp_2 = 0;
                        for (int y = temp; y < con.Length - 1; y++)
                        {

                            employee._Holidays[temp_2] = Convert.ToDateTime(con[y]);
                            temp_2++;
                        }
                        AddEmployee(employee);

                        PersonnelNumber++;
                    }

                }
                return PersonnelNumber;


            }
            return PersonnelNumber;



        }

        #endregion

        #region Timeplan

        public void TimePlanMenue()
        {
           // Timeplan.TimePlanMenue(Manager);
        }

        public void ShowTimePlan()
        {
            //Timeplan.ShowTimePlans(Manager);


        }

        public void ChangeEmployee()
        {
            Employee employee = SearchEmployee();
            Console.WriteLine("Bitte geben sie einen neuen Vornamen ein");
            string? new_FName = Console.ReadLine(); //addresses.changeName(employee, "Bitte geben sie einen neuen Vornamen ein : ");
            Console.WriteLine("Bitte geben sie einen neuen Nachnamen ein");
            string? new_LName = Console.ReadLine(); //addresses.changeName(employee, "Bitte geben sie einen neuen Nachnamen ein : ");
            if (new_FName != null || new_FName != "") { employee.SET_FirstName(new_FName); }
            if (new_LName != null && new_LName != "") { employee.SET_LastName(new_LName); }


        }



        #endregion




    }
}



