﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    public class MensajesDALFactory
    {
        //Larman UML Patterns
        public static IMensajesDAL CreateDal()
        {
            return MensajesDALArchivos.GetInstancia();
        }
    }
}
