using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    [Serializable()]
    public class Personas
    {
        private string Nombre;
        private string Apellido;
        private string Rut;
        private string Cargo;

        public Personas(string nom, string ape, string run, string cargo)
        {
            Nombre = nom;
            Apellido = ape;
            Rut = run;
            Cargo = cargo;
        }
        public Personas()
        {

        }

        public Personas crear_Persona()
        {
            Console.WriteLine("ingrese nombre de la persona");
            string nom = Console.ReadLine();
            Console.WriteLine("ingrese apellido de la persona");
            string ape = Console.ReadLine();
            Console.WriteLine("ingrese rut de la persona");
            string run = Console.ReadLine();
            Console.WriteLine("ingre cargo de la persona");
            string cargo = Console.ReadLine();
            Personas tu = new Personas(nom, ape, run, cargo);

            return tu;
        }
            public string get_nombre()
            {
            return Nombre;
            }
            public string get_apellido()
            {
            return Apellido;
            }
            public string get_run()
            {
            return Rut;
            }
            public string get_cargo()
            {
            return Cargo;
            }


    }
}
