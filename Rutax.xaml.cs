using Microsoft.Win32;
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

namespace GUI_RutaOrnitologica
{
    /// <summary>
    /// Lógica de interacción para RutaX.xaml
    /// </summary>
    public partial class RutaX : Window
    {
        private EditarRuta anadirRuta;
        private Home home;
        private GuiasTuristicos guiaTuristico;
        private GymkanaPromocion compartir;
        private ModificarRuta puntosAvistamiento;
        private Documentacion.AbandonarAplicacion abandonarAplicacion;
        private Documentacion.InformaciónAutor infoAutor;
        private Documentacion.Borrar borrar;
        public RutaX()
        {
            InitializeComponent();
            FechaUltimaVez();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            cambiarBandera("es-ES");
        }

        private void IrAHome(object sender, RoutedEventArgs e)
        {
            home = new Home();
            home.Show();
            Close();
        }

        private void IrAGuiasTuristicos(object sender, RoutedEventArgs e)
        {
            guiaTuristico = new GuiasTuristicos();
            guiaTuristico.Show();
            Close();
        }

        private void EditarRuta(object sender, RoutedEventArgs e)
        {
            anadirRuta = new EditarRuta(lblNombreRutaBRespuesta, 
                lblSentidoRutaBRespuesta, lblInicioRutaBRespuesta, lblFinRutaBRespuesta, 
                lblFechaRutaBRespuesta, lblTiempoEstimadoRutaBRespuesta, lblTiempoMovimientoRutaBRespuesta, 
                lblInformacionRutaBRespuesta, lblDificultadRutaBRespuesta, lblEpocaRutaBRespuesta, 
                lblRecomendacionesRutaBRespuesta);
            anadirRuta.Show();
        }

        private void IrAGymkanaPromocion(object sender, RoutedEventArgs e)
        {
            compartir = new GymkanaPromocion();
            compartir.Show();
            Close();
        }

        private void IrAPuntosAvistamiento(object sender, RoutedEventArgs e)
        {
            puntosAvistamiento = new ModificarRuta();
            puntosAvistamiento.Show();
            Close();
        }

        private void opciones(object sender, RoutedEventArgs e)
        {
            lbPerfil.Visibility = Visibility.Visible;
            user.Visibility = Visibility.Visible;
            lbInformacion.Visibility = Visibility.Visible;
            btnInformacion.Visibility = Visibility.Visible;
            lbAyuda.Visibility = Visibility.Visible;
            ayuda.Visibility = Visibility.Visible;
            lbIdioma.Visibility = Visibility.Visible;
            idioma.Visibility = Visibility.Visible;
            lbSalida.Visibility = Visibility.Visible;
            salir.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Visible;
            lbAutor.Visibility = Visibility.Visible;
            btnAutor.Visibility = Visibility.Visible;
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

        private void colocarImagen(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    ImgPaisaje.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
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
