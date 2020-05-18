using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.IO;
namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Empresa GG = new Empresa();
            Personas nadie = new Personas();
            string resp = "";
            int asd;
            bool aux = false; 
            while (resp != "SI" && resp != "NO" && resp != "si" && resp != "no")
            {
                Console.WriteLine("Quiere cargar la informacion de la empresa? (SI/NO)");
                resp = Console.ReadLine();
            }
            if (resp == "SI" || resp == "si")
            {
                 asd = Empresa.des_serializar(GG);
                if (asd == 1)
                    aux = true;
                else
                    aux = false;
            }
            if (resp == "NO" || resp == "no" || aux == true)
            {
                Empresa.serialisar(GG,nadie);

            }

            for (int i = 0; i < GG.Get_Empresas().Count(); i++)
            {
                Console.WriteLine("Nombre de la empresa: "+GG.Get_Empresas()[i].GET_nombre());
                Console.WriteLine("Rut de la empresa: "+GG.Get_Empresas()[i].GET_RUT());
                Console.WriteLine("");
            }
            for (int i = 0; i < GG.Get_Divi().Count(); i++)
            {
                Console.WriteLine(GG.Get_Divi()[i].get_nombre());
                for (int k = 0; k < GG.Get_Divi()[i].People.Count(); k++)
                {
                    Console.WriteLine(GG.Get_Divi()[i].People[k].get_nombre() +" "+ GG.Get_Divi()[i].People[k].get_apellido() + " " + GG.Get_Divi()[i].People[k].get_run() + " " + GG.Get_Divi()[i].People[k].get_cargo());
                }
                Console.WriteLine("");
            }
            Console.ReadLine();




        }
    }
}
