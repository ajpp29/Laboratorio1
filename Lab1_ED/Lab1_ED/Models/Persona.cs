﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1_ED.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public int CompareTo(Object persona)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Persona persona)
        {
            return this.PersonaID.CompareTo(persona.PersonaID);
        }
    }
}