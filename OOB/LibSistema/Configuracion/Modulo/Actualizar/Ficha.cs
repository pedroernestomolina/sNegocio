﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Configuracion.Modulo.Actualizar
{
    
    public class Ficha
    {

        public string claveNivMaximo { get; set; }
        public string claveNivMedio { get; set; }
        public string claveNivMinimo { get; set; }
        public string visualizarPrdInactivos { get; set; }
        public int cantDocVisualizar { get; set; }


        public Ficha()
        {
            claveNivMaximo = "";
            claveNivMedio = "";
            claveNivMinimo = "";
            visualizarPrdInactivos = "";
            cantDocVisualizar = 0;
        }

    }

}