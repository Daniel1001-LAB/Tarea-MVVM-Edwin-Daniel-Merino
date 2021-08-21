using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM02MVVM.Models
{
    public class Personas
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(250)]
        public string name { get; set; }
        [MaxLength(250)]
        public string apellido { get; set; }
        public double edad { get; set; }
        [MaxLength(100), Unique]
        public string correo { get; set; }
        [MaxLength(300)]
        public string direccion { get; set; }
        [MaxLength(100)]
        public string puesto { get; set; }




    }
}
