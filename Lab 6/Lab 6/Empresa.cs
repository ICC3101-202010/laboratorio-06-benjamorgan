using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_6
{
    [Serializable()]
    class Empresa
    {
        private string Nombre;
        private string Rut;
        private List<Empresa> TodasLasEmpresas = new List<Empresa>();
        private List<Divisiones> DivisionesDeLaEmpresa = new List<Divisiones>();

        public Empresa()
        {

        }
        public Empresa(string nom, string run)
        {
            this.Nombre = nom;
            this.Rut = run;
        }
        public void nombre(string nom)
        {
             this.Nombre = nom;
        }
        public void RUT(string run)
        {
            this.Rut = run;
        }
        public string GET_nombre()
        {
            return Nombre;
        }
        public string GET_RUT()
        {
            return Rut;
        }
        public void Añadirempresa(Empresa x)
        {
            TodasLasEmpresas.Add(x);
        }
        public List<Empresa> Get_Empresas()
        {
            return TodasLasEmpresas;
        }
        public List<Divisiones> Get_Divi()
        {
            return DivisionesDeLaEmpresa;
        }

        public static int des_serializar(Empresa gg)
        {
            string path_empresas = @System.IO.Directory.GetCurrentDirectory() + "\\empresas.bin";
            if (File.Exists(path_empresas))
            {
                IFormatter formatter2 = new BinaryFormatter();
                Stream stream2 = new FileStream("empresas.bin", FileMode.Open, FileAccess.Read, FileShare.Read);

                try
                {

                    int p = (int)formatter2.Deserialize(stream2);

                    for (int i = 0; i < p; i++)
                    {

                        Empresa obj = (Empresa)formatter2.Deserialize(stream2);
                        gg.Añadirempresa(obj);
                        
                    }
                    p = (int)formatter2.Deserialize(stream2);
                    for (int i = 0; i < p; i++)
                    {
                        Divisiones obj2 = (Divisiones)formatter2.Deserialize(stream2);
                        gg.DivisionesDeLaEmpresa.Add(obj2);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    stream2.Close();

                }
                return 0;
            }
            else
            {
                Console.WriteLine("No hay empresas en el sistema, por favor ingrese una");
                return 1; 
            }
        }



        public static void serialisar(Empresa gg, Personas yo)
        {
            Console.WriteLine("Ingresa el nombre de la empresa");
            string nom = Console.ReadLine();
            Console.WriteLine("Ingresa el rut de la empresa");
            string run = Console.ReadLine();
            gg.nombre(nom);
            gg.RUT(run);
            Empresa k = new Empresa(nom, run);
            gg.Añadirempresa(k);
            IFormatter formatter = new BinaryFormatter();
            List<Personas> vacio = new List<Personas>();
            List<Personas> vacio2 = new List<Personas>();
            List<Personas> vacio3 = new List<Personas>();
            List<Personas> vacio4 = new List<Personas>();
            List<Personas> vacio5 = new List<Personas>();
            List<Personas> vacio6 = new List<Personas>();
            Console.WriteLine(  "ingrese el nombre del area ");
            string area = Console.ReadLine();
            Area A = new Area("Area: "+area, vacio);
            gg.DivisionesDeLaEmpresa.Add(A);
            Console.Clear();



            Console.WriteLine("ingrese el nombre del departamento");
            string dep = Console.ReadLine();
            Departamento B = new Departamento("Departamento: " + dep, vacio2);
            Console.WriteLine( "ingrese al encargado del departamento");
            Personas encargadodep = yo.crear_Persona();
            B.People.Add(encargadodep);
            gg.DivisionesDeLaEmpresa.Add(B);
            Console.Clear();



            Console.WriteLine("ingrese el nombre de la seccion");
            string secc = Console.ReadLine();
            Seccion C = new Seccion("Seccion: " + secc, vacio3);
            Console.WriteLine("ingrese al encargado de esta seccion");
            Personas encargadosecc = yo.crear_Persona();
            C.People.Add(encargadosecc);
            gg.DivisionesDeLaEmpresa.Add(C);
            Console.Clear();


            Console.WriteLine("ingrese el nombre del bloque 1");
            string blok1 = Console.ReadLine();
            Bloque D = new Bloque("Bloque 1: " + blok1,vacio4);
            Console.WriteLine("ingrese a los trabajadores del blocke 1");
            bool seguir = true;
            while (seguir)
            {
                Personas encargadoblock1 = yo.crear_Persona();
                D.People.Add(encargadoblock1);
                string resp = "";
                while (resp != "SI" && resp != "NO" && resp != "si" && resp != "no")
                {
                    Console.WriteLine("quiere agregar otro empleado? (si/no)");
                    resp = Console.ReadLine();
                    if (resp == "no" || resp == "NO")
                        seguir = false;
                }
            }

            gg.DivisionesDeLaEmpresa.Add(D);
            Console.Clear();

            Console.WriteLine("ingrese el nombre del bloque 2");
            string bloc2 = Console.ReadLine();
            Bloque E = new Bloque("Bloque 2: " + bloc2, vacio5);
            Console.WriteLine("ingrese a los trabajadores del blocke 2");


            seguir = true;
            while (seguir)
            {
                Personas encargadoblock2 = yo.crear_Persona();
                E.People.Add(encargadoblock2);
                string resp = "";
                while (resp != "SI" && resp != "NO" && resp != "si" && resp != "no")
                {
                    Console.WriteLine("quiere agregar otro empleado? (si/no)");
                    resp = Console.ReadLine();
                    if (resp == "no" || resp == "NO")
                        seguir = false;
                }
            }
            gg.DivisionesDeLaEmpresa.Add(E);
            Console.Clear();


            Stream stream = new FileStream("empresas.bin", FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, gg.Get_Empresas().Count());
            for (int i = 0; i < gg.Get_Empresas().Count(); i++)
            {
                formatter.Serialize(stream, gg.Get_Empresas()[i]);

            }
            formatter.Serialize(stream, gg.DivisionesDeLaEmpresa.Count());
            for (int i = 0; i < gg.DivisionesDeLaEmpresa.Count(); i++)
            {
                formatter.Serialize(stream, gg.DivisionesDeLaEmpresa[i]);
            }
            stream.Close();
        }



    }
}
