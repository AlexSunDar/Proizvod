using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proizvod.Model
{
    [Table("Proizvod")]
    public class ProizvodModel
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Kategorija { get; set; }
        public string Proizvodjac { get; set; }
        public string Dobavljac { get; set; }
        [Required]
        public double Cena { get; set; }
    }
}