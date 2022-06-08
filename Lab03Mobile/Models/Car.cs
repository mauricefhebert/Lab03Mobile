using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03Mobile.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Modele { get; set; }
        public string Description { get; set; }
        public string Immatriculation { get; set; }
        public int Kilometrage { get; set; }
        public bool Disponible { get; set; }
        public string Categorie { get; set; }
        public double PrixJours { get; set; }
        public string UrlImage { get; set; }
    }
}
