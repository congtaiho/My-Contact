using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modell
{
    public class utilisateur
    {
        public string MotDePass { get; set; }
        public string CourrielUtilisateur { get; set; }

        public override string ToString()
        {
            string st = string.Format($"Mot de pass: {MotDePass} - Courriel: {CourrielUtilisateur}");
            return st;
        }
    }
}
