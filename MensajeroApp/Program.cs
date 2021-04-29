using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    class Program
    {
        //1. Crear Menu
        static bool Menu()
        {
            Boolean continuar = true;
            Console.WriteLine("Elija una opcion mi washa");
            Console.WriteLine("1. Ingresar Mensajes \n2. Mostrar Mensajes \n0. Cerrar");
            String opcion = Console.ReadLine().Trim();
            switch(opcion)
            {
                case "1": IngresarMensaje();
                    break;
                case "2": MostrarMensaje();
                    break;
                case "0": continuar = false;
                    break;
                default: Console.WriteLine("Ingrese una de las opciones washin :T");
                    break;
            }
            return continuar;
        }
        //2. Dos metodos IngresarMensajes y MostrarMensajes
        static IMensajesDAL dal = MensajesDALFactory.CreateDal();

        static void IngresarMensaje()
        {
            string nombre, detalle;
            do
            {
                Console.WriteLine("Ingrese nombre");
                nombre = Console.ReadLine().Trim();

            } while (nombre == string.Empty);

            do
            {
                Console.WriteLine("Ingrese mensaje:");
                detalle = Console.ReadLine().Trim();
            } while (detalle == string.Empty || detalle.Length > 20);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "Aplicacion"
            };
            dal.Save(m);
        }
 
        static void MostrarMensaje()
        {
            List<Mensaje> mensajes = dal.GetAll();
            mensajes.ForEach(m =>
            {
                Console.WriteLine("Nombre:{0} Detalle:{1} Tipo:{2}", m.Nombre, m.Detalle, m.Tipo);
            }
            );
        }
        //3. Al ingresar un mensaje definir el tipo como Aplicacion
        static void Main(string[] args)
        {
            while (Menu()) ;
        }
    }
}
