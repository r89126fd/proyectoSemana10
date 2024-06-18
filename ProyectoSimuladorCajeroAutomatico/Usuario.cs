using System;

namespace Grupo8
{

    class Usuario
    {
        public string nombre;
        public string apellido;
        public string username;
        public string password;
        public string rol;

        public Usuario() { }

        public Usuario(string nombre, string apellido, string username, string password)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.username = username;
            this.password = password;
            this.rol = rol;
        }

    }

}