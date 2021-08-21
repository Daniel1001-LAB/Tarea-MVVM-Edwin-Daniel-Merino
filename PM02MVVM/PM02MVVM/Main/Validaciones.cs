using System;
using System.Collections.Generic;
using System.Text;

namespace PM02MVVM.Main
{
    public class ValidarDatos
    {
        bool respuesta;
        public bool validarPersona(string name, string apellido, int edad, string correo, string direccion)
        {

            respuesta = (name == null || apellido == null || edad.Equals("") || correo == null || direccion == null) ? false : true;

            return respuesta;
        }




    }
}
