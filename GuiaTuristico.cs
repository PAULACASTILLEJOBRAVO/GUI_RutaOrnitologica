using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_RutaOrnitologica
{
    public class GuiaTuristico
    {
        public Uri Perfil { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Telefono { set; get; }
        public string CorreoElectronico { set; get; }
        public Uri Idiomas { set; get; }
        public GuiaTuristico(Uri perfil, string nombre, string apellido, string telefono, string 
        correoelectronico, Uri idiomas)
        {
            Perfil = perfil;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            CorreoElectronico = correoelectronico;
            Idiomas = idiomas;
        }
    }
}
