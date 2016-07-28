using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIsession5.Models
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