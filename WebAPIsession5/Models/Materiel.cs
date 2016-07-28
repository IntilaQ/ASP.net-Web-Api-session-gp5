using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPIsession5.Models
{
    public class Materiel
    {

        public int MaterielId { get; set; }

        public string Libille { get; set; }

        public int Number { get; set; }


        public int DepartementId { get; set; }
        [ForeignKey("DepartementId")]
        public Departement Departement { get; set; }

    }
}