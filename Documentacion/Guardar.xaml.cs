using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_RutaOrnitologica.Documentacion
{
    /// <summary>
    /// Lógica de interacción para Guardar.xaml
    /// </summary>
    public partial class Guardar : Window
    {
        public Guardar()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            cambiarBandera("es-ES");
        }
        private void Cancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Aceptar(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)Idioma.SelectedItem;
            string selectedText = cbi.Content.ToString();
            if ((selectedText.Equals("ES") || selectedText.Equals("SP"))
                && !CultureInfo.CurrentCulture.Name.Equals("es-ES"))
            {
                Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
                cambiarBandera("es-ES");
            }
            else if (selectedText.Equals("EN") || selectedText.Equals("IN")
                && !CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                Resources.MergedDictionaries.Add(App.SelectCulture("en-US"));
                cambiarBandera("en-US");
            }
        }
        private void cambiarBandera(string idioma)
        {
            imgIdioma.Source = idioma.Equals("en-US")
            ? new BitmapImage(new Uri("/GUI_RutaOrnitologica;component/Imagenes/BanderaInglesa.png",
            UriKind.Relative))
            : new BitmapImage(new Uri("/GUI_RutaOrnitologica;component/Imagenes/BanderaEspañola.png",
            UriKind.Relative));
        }
    }
}
