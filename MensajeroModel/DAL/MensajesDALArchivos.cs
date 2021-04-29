﻿using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    public class MensajesDALArchivos : IMensajesDAL
    {
        //Singleton: Una instancia de esta clase por programa
        //1. Un constructor privado
        private MensajesDALArchivos()
        {

        }
        //2. Una referencia estatica a si mismo
        private static IMensajesDAL instancia;
        //3. Un metodo estatico que sea el unico que permite acceder a la instancia
        public static IMensajesDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new MensajesDALArchivos();
            return instancia;
        }

        private string archivo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "mensajes.csv";
        public List<Mensaje> GetAll()
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = null;
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            //Parsear mensaje                            
                            string[] textoArray = texto.Split(';');
                            Mensaje m = new Mensaje()
                            {
                                Nombre = textoArray[0],
                                Detalle = textoArray[1],
                                Tipo = textoArray[2],
                            };
                            mensajes.Add(m);
                        }
                    } while (texto != null);
                }
            }
            catch (IOException ex)
            {
                mensajes = null;
            }
            return mensajes;
        }

        public void Save(Mensaje m)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }

            }
            catch (IOException ex)
            {

            }
        }
    }
}