using System;
using System.Configuration;

namespace Bobson.Core.Base
{
    public static class Config
    {
        private static String DefaultConnectionKey
        {
            get
            {
                return "MYSQL_CONNECTION";
            }
        }


        public static ConnectionStringSettings DefaultConnectionSettings
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[DefaultConnectionKey];
            }
        }


        public static String EmailFromAdress
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["mail_from"]);
            }
        }

        public static String EmailFromName
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["mail_name"]);
            }
        }

        public static class Roles
        {
            public const string Administrador = "Admin";
            public const string Gerente = "Gerente";
            public const string Cliente = "Cliente";
            public const string Comercial = "Comercial,Admin";
            public const string Escritorio = "Escritorio,Admin";
            public const string Tecnico = "Tecnico,Admin";

            //Trocar isto por Policies depois
            public const string GerenteMaisComercial = Gerente + "," + Comercial;
            public const string GerenteMaisTecnico = Gerente + "," + Tecnico;
            public const string GerenteMaisEscritorio = Gerente + "," + Escritorio;
        }

    }
}
