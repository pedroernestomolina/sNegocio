﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.SucursalGrupo.Agregar
{
    

    public class Ficha
    {

        public int idPrecio { get; set; }
        public string nombre { get; set; }


        public Ficha() 
        {
            idPrecio = -1;
            nombre = "";
        }

    }

}