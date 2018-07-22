using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proizvod.Models
{
    public class Proizvod
    {
        private int Id { get; set; }
        private string Naziv { get; set; }
        private string Opis { get; set; }
        private string Kategorija { get; set; }
        private double Cena { get; set; }
    }
}