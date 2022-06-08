using System;
using System.Collections.Generic;
using System.Text;
using Lab03Mobile.Models;

namespace Lab03Mobile.Data
{
    public class CarDbContext
    {
        public static List<Car> CarList = new List<Car>
        {
            new Car()
            {
                Id = 0,
                Modele = "Mazda 3",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Est placerat in egestas erat imperdiet sed euismod.",
                Immatriculation = "0A0 A0A",
                Kilometrage = 50000,
                Disponible = true,
                Categorie = "Sedan",
                PrixJours = 100.00,
                UrlImage = "mazda3.png"
            },
            new Car()
            {
                Id = 1,
                Modele = "Tesla Model 3",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Est placerat in egestas erat imperdiet sed euismod.",
                Immatriculation = "0B0 B0B",
                Kilometrage = 0,
                Disponible = true,
                Categorie = "Sedan",
                PrixJours = 300.00,
                UrlImage = "teslaModel3.png"
            },
            new Car()
            {
                Id = 2,
                Modele = "Honda CR-V",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Est placerat in egestas erat imperdiet sed euismod.",
                Immatriculation = "0C0 C0C",
                Kilometrage = 50000,
                Disponible = true,
                Categorie = "SUV",
                PrixJours = 200.00,
                UrlImage = "hondaCRV.png"
            },
            new Car()
            {
                Id = 3,
                Modele = "Jeep Wrangler",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Est placerat in egestas erat imperdiet sed euismod.",
                Immatriculation = "0D0 D0D",
                Kilometrage = 50000,
                Disponible = true,
                Categorie = "SUV",
                PrixJours = 250.00,
                UrlImage = "jeepWrangler.png"
            },
        };

        public static Invoice invoice = new Invoice() { Amount = 0 };
    }
}
