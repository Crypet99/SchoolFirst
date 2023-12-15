using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP_FrontEND
{
    public sealed class EmployeeManager
    {
        private EmployeeManager() { }

        private static Employee_Manager instance = null;
        private static readonly object padlock = new object();

        public static Employee_Manager Instance
        { 
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new Employee_Manager();
                }

                return instance;

            }
        }
    }
}
