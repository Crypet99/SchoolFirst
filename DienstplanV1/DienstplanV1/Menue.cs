using Employee_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienstplanV1
{
    internal class Menue
    {

        private char Switch_Menue;

        public Menue() { Switch_Menue = ' '; }
        EmployeeManager EmployeeManager = new EmployeeManager();
        Employee Employee =  new Employee();
        

        public void StartMenue()
        {
            Switch_Menue = Console.ReadKey().KeyChar;

            switch(Switch_Menue)
            {

            // Mitarbeiter Hinzufügen
                case 'H':

                    EmployeeManager.AddEmployee(Employee);
                    break;

            //Mitarbeiter Entfernen
                case 'E':
                    EmployeeManager.RemoveEmployee(Employee);
                    break;

            // DienstPlan Erstellen
                case 'N':
                    break;
                

            // Dienstplan Anzeigen
                case 'A':
                    break;
            }


        } 


    }
}
