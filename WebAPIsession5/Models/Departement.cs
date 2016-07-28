using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIsession5.Models
{
    public class Departement
    {
        public Departement()
        {
                this.Materiels=new HashSet<Materiel>();
        }

        public  int  DepartementId { get; set; }

        public string Name { get; set; }

        public ICollection<Materiel> Materiels { get; set; }

    }
}