﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Entities;
using TP2.Utils;

namespace TP2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var item in FakeDb.Instance.Users)
            {
                Console.WriteLine(item);
            }

            #region Q1
            Console.WriteLine("Question 1");
            // Afficher le nombre de personne s'appelant Dupond ou Dupont.
            var r1 = FakeDb.Instance.Users.Count(x => x.Lastname == "Dupont" || x.Lastname == "Dupond");
            Console.WriteLine(r1);
            
            #endregion
            #region Q2
            Console.WriteLine("Question 2");
            // Afficher les personnes enregistré avec le role Automobiliste.
            var r2 = FakeDb.Instance.Users.Where(x => x.Roles.Any(p => p.Name == "Automobiliste"));
            foreach (var item in r2)
            {
                Console.WriteLine(item);
            }

            #endregion
            #region Q3
            Console.WriteLine("Question 3");
            // Afficher les plaques d'immatriculation de toutes les voitures (une seule fois par voiture) liées à au moins un utilisateur.
            var r3 = FakeDb.Instance.Users.SelectMany(x => x.Cars).Select(c => c.Registration).Distinct();
            foreach (var item in r3){
            Console.WriteLine(item);            
            }
            
            #endregion
            #region Q4
            Console.WriteLine("Question 4");
            // Afficher la ou les voiture(s) avec le plus de kilomètre
            var r4 = FakeDb.Instance.Users.SelectMany(x => x.Cars)
                                .Distinct()
                                .Where(x => x.Mileage == FakeDb.Instance.Users
                                .SelectMany(y => y.Cars)
                                .Distinct()
                                .Max(y => y.Mileage));
            foreach (var item in r4){
                Console.WriteLine( item.Id + " " + item.Mileage + " " + item.Registration);            
            }
            #endregion
            #region Q5
            Console.WriteLine("Question 5");
            // Afficher le classement des types de voiture par nombre de voiture unique présentes du plus grand au plus petit.
            var r5 = FakeDb.Instance.Users.SelectMany(x => x.Cars).GroupBy(x => x.Type).OrderByDescending(x => x.Count()).Distinct();
            foreach (var item in r5){
                Console.WriteLine( item.Key.Name + " " + item.Count() );            
            }
            #endregion
            #region Q6
            Console.WriteLine("Question 6");
            // Afficher les "Garagiste" liés à 4 voitures ou plus.

            #endregion
            #region Q7
            Console.WriteLine("Question 7");
            // Afficher les "Controlleur" et la liste des voitures aux quelles ils sont liés.

            #endregion
            Console.ReadKey();
        }
    }
}
