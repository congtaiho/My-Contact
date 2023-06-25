using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modell
{
    public class Contact
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Courriel { get; set; }
        public Contact()
        {

        }

        public Contact(string nom, string prenom, string telephone)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Telephone = telephone;
        }

        public override string ToString()
        {
            string st = string.Format($"{Id} - {Nom} {Prenom} - {Telephone} - {Courriel}");
            return st;
        }
    }
}
