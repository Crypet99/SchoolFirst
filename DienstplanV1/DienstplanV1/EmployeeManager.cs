using Employee_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienstplanV1
{
    internal class EmployeeManager
    {
        
        Employee Employee = new Employee();
        List<Employee> EmployeeList= new List<Employee>();



        public void AddEmployee(Employee Employee)
        {
            
            EmployeeList.Add(Employee); 
        }

        public void RemoveEmployee( Employee employee) 
        {
            Employee = SearchEmployee();
            EmployeeList.Remove(employee);
        }

        public Employee SearchEmployee()
        {
            do
            {
                try
                {
                    Console.WriteLine("Möchtest du Nach 1. Mitarbeiter Nummer oder 2. Namen Suchen");
                    ushort switch_Searching = 0;
                    switch_Searching = Convert.ToUInt16(Console.ReadLine());

                    if(switch_Searching == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Bitte Gib die Mitarbeiternummer ein :");
                        int employeeNumber = Convert.ToInt32(Console.ReadLine());

                        foreach (Employee e in EmployeeList)
                        {
                            if (e.Get_EmployeeID() == employeeNumber)
                            {
                                return e;
                            }
                        }

                    }

                    else if (switch_Searching == 2)
                    {

                        Console.Clear();
                        Console.WriteLine("Bitte Gib die Mitarbeiternamen ein :");
                        string? employeeName = Console.ReadLine();

                        foreach (Employee e in EmployeeList)
                        {
                            if (e.Get_FirstName() == employeeName || e.Get_LastName() == employeeName)
                            {
                                return e;
                            }
                        }


                    }
                    // Ungültig

                    else
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        continue;
                    }
                }

                catch(Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                    continue;
                }

            } while (true);

            

        }


    }
}
