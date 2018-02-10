using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDA;

namespace Lab1_ED.DBContext
{
    public class DefaultConnection
    {
        private static volatile DefaultConnection Instance;
        private static object syncRoot = new Object();

        public int IdActual { get; set; }

        private DefaultConnection()
        {
            IdActual = 0;
        }

        public List<Models.Persona> Personas = new List<Models.Persona>();
        public ListaOriginal<string> Ids = new ListaOriginal<string>();

        public static DefaultConnection getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new DefaultConnection();
                        }
                    }
                }

                return Instance;
            }
        }

    }
}