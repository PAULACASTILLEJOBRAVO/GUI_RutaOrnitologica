using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_RutaOrnitologica
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ResourceDictionary SelectCulture(string idioma)
        {
            var resourceDictionary = new ResourceDictionary();
            switch (idioma)
            {
                case "en-US":
                    resourceDictionary.Source =
                        new Uri("/Recursos/StringResources.en-US.xaml", UriKind.Relative); 
                    break;
                case "es-ES":
                    resourceDictionary.Source =
                        new Uri("/Recursos/StringResources.es-ES.xaml", UriKind.Relative); 
                    break;
                default:
                    resourceDictionary.Source =
                        new Uri("/Recursos/StringResources.es-ES.xaml", UriKind.Relative); 
                    break;
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(idioma);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma);
            return resourceDictionary;
        }
    }
   
}
