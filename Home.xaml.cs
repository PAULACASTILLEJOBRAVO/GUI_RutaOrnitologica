using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_RutaOrnitologica
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private RutaX rutaDeterminada;
        private GuiasTuristicos guiaTuristico;
        private GymkanaPromocion compartir;
        private EditarRuta añadirRuta;
        private RutaX rutax;
        private Documentacion.AbandonarAplicacion abandonarAplicacion;
        private Documentacion.InformaciónAutor infoAutor;
        private Documentacion.Borrar borrar;
        public Home()
        {
            InitializeComponent();
            FechaUltimaVez();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            cambiarBandera("es-ES");
        }

        private void IrAGymkanaPromocion(object sender, RoutedEventArgs e)
        {
            compartir = new GymkanaPromocion();
            compartir.Show();
            Close();
        }

        private void IrAGuiasTuristicos(object sender, RoutedEventArgs e)
        {
            guiaTuristico = new GuiasTuristicos();
            guiaTuristico.Show();
            Close();
        }
        private void opciones(object sender, RoutedEventArgs e)
        {
            RecuadroOpciones.Visibility = Visibility.Visible;
            btnInformacion.Visibility = Visibility.Visible;
            lbPerfil.Visibility = Visibility.Visible;
            user.Visibility = Visibility.Visible;
            lbInformacion.Visibility = Visibility.Visible;
            lbAyuda.Visibility = Visibility.Visible;
            ayuda.Visibility = Visibility.Visible;
            lbIdioma.Visibility = Visibility.Visible;
            idioma.Visibility = Visibility.Visible;
            lbAutor.Visibility = Visibility.Visible;
            btnAutor.Visibility = Visibility.Visible;
            lbSalida.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Visible;
        }

        private void IrARutaDeterminada(object sender, MouseButtonEventArgs e)
        {
            rutaDeterminada = new RutaX();
            rutaDeterminada.Show();
        }

        private void IrAAñadirRuta(object sender, RoutedEventArgs e)
        {
            añadirRuta = new EditarRuta(null, null, null, null, null, null, null, null, null, null, null);
            añadirRuta.Show();
        }

        private void abrirRutax(object sender, RoutedEventArgs e)
        {
            rutax = new RutaX();
            rutax.Show();
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
            ? new BitmapImage(new Uri("Imagenes/BanderaInglesa.png",
            UriKind.Relative))
            : new BitmapImage(new Uri("Imagenes/BanderaEspañola.png",
            UriKind.Relative));
        }

        private void AbandonarAplicacion(object sender, RoutedEventArgs e)
        {
            abandonarAplicacion = new Documentacion.AbandonarAplicacion();
            abandonarAplicacion.Show();
        }

        public void FechaUltimaVez()
        {
            lbUltimaVez.Content = DateTime.Now.ToShortDateString();
        }

        private void enviarPromocionGymkana(object sender, RoutedEventArgs e)
        {
            compartir = new GymkanaPromocion();
            compartir.Show();
            Close();
        }

        private void mostrarInformacionTotal(object sender, RoutedEventArgs e)
        {
            svInfoRuta.Visibility = Visibility.Visible;
            svInfoGymkana.Visibility = Visibility.Visible;
            svInfoPromocion.Visibility = Visibility.Visible;
        }
        private void mostrarInformacionRuta(object sender, RoutedEventArgs e)
        {
            svInfoRuta.Visibility = Visibility.Visible;
        }
        public void mostrarInformacionPromocion(object sender, RoutedEventArgs e)
        {
            svInfoPromocion.Visibility = Visibility.Visible;
        }
        public void mostrarInformacionGymkana(object sender, RoutedEventArgs e)
        {
            svInfoGymkana.Visibility = Visibility.Visible;
        }

        private void AcercaDe(object sender, RoutedEventArgs e)
        {
            infoAutor = new Documentacion.InformaciónAutor();
            infoAutor.Show();
        }

        private void Borrar(object sender, RoutedEventArgs e)
        {
            borrar = new Documentacion.Borrar();
            borrar.Show();
        }
    }
}
