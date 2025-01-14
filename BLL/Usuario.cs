using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {
        public string Email { get; set; }
        public string NombreCompleto { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public char Estado { get; set; }
        public string Rol { get; set; }
        public string Foto { get; set; }

        // Metodo para confirmar clave
        public bool ConfirmarPassword(string ps)
        {
            bool autorizado = false;

            if (string.IsNullOrEmpty(ps))
            {
                return false;
            }
            else
            {
                if (Password.Equals(ps))
                {
                    autorizado = true;
                }
            }
            return autorizado;
        }//Fin metodo confirmarPass
    }//Fin clase
}//Fin Name space