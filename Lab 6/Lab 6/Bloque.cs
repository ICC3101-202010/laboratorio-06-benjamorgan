using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable()]
    public class Bloque : Divisiones
    {


        public Bloque(string nom, List<Personas> personas) : base(nom, personas)
        {
            Nombre = nom;
            People = personas;
        }
        public List<Personas> get_lista()
        {
            return People;
        }

    }
}
