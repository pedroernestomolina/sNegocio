﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Sucursal
{

    public class Agregar
    {

        public string autoGrupo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estatusFactMayor { get; set; }


        public Agregar() 
        {
            autoGrupo = "";
            codigo = "";
            nombre = "";
            estatusFactMayor = "";
        }

    }

}