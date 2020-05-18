using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable()]
    public class Divisiones
    {
        protected string Nombre;

        protected List<Personas> people = new List<Personas>();

        public List<Personas> People { get => people; set => people = value; }
        public Divisiones(string nom, List<Personas> personas)
        {
            Nombre = nom;


        }


        public string get_nombre()
        {
            return Nombre;
        }



    }
}
