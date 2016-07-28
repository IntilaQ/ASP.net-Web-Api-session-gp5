using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientmobile
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public String Name { get; set; }

        public int Age { get; set; }
        //Employee --> Departement
        public Departement Departement { get; set; }
    }
}
