using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;


namespace GUI_RutaOrnitologica
{
    class Controlador
    {
        public List<GuiaTuristico> CargarContenidoListaXML(List<GuiaTuristico> listadoGuiaTuristico)
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/guiasTuristicos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            listadoGuiaTuristico = new List<GuiaTuristico>();
            foreach (XmlNode nodo in doc.DocumentElement.ChildNodes)
            {
                var guiaTuristico = new GuiaTuristico(null, "", "", "", "", null);
                guiaTuristico.Perfil = new Uri(nodo.Attributes["Perfil"].Value, UriKind.Relative);
                guiaTuristico.Nombre = nodo.Attributes["Nombre"].Value;
                guiaTuristico.Apellido = nodo.Attributes["Apellidos"].Value;
                guiaTuristico.Telefono = nodo.Attributes["Telefono"].Value;
                guiaTuristico.CorreoElectronico = nodo.Attributes["CorreoElectronico"].Value;
                guiaTuristico.Idiomas = new Uri(nodo.Attributes["Idiomas"].Value, UriKind.Relative);
                listadoGuiaTuristico.Add(guiaTuristico);
            }
            return listadoGuiaTuristico;
        }
    }
   
}
