﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.TablaPrecio.Editar
{


    public class Ficha
    {

        public int id { get; set; }
        public string descripcion { get; set; }


        public Ficha() 
        {
            id = -1;
            descripcion = "";
        }

    }

}