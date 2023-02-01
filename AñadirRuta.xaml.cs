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
    /// Lógica de interacción para EditarRuta.xaml
    /// </summary>
    public partial class EditarRuta : Window
    {
        private RutaX rutaDeterminada;
        private Home home;
        private GymkanaPromocion compartir;
        private GuiasTuristicos guiaTuristico;
        private Documentacion.AbandonarAplicacion abandonarAplicacion;
        private Documentacion.InformaciónAutor infoAutor;
        private Documentacion.Guardar guardar;
        private Label nombreRutaBRespuesta;
        private Label sentidoRutaBRespuesta;
        private Label inicioRutaBRespuesta;
        private Label finRutaBRespuesta;
        private Label fechaRutaBRespuesta;
        private Label tiempoEstimadoRutaBRespuesta;
        private Label tiempoMovimientoRutaBRespuesta;
        private Label informacionRutaBRespuesta;
        private Label dificultadRutaBRespuesta;
        private Label epocaRutaBRespuesta;
        private Label recomendacionesRutaBRespuesta;

        public EditarRuta(Label lblNombreRutaBRespuesta, 
            Label lblSentidoRutaBRespuesta, Label lblInicioRutaBRespuesta,
            Label lblFinRutaBRespuesta, Label lblFechaRutaBRespuesta, Label lblTiempoEstimadoRutaBRespuesta,
            Label lblTiempoMovimientoRutaBRespuesta, Label lblInformacionRutaBRespuesta, 
            Label lblDificultadRutaBRespuesta, Label lblEpocaRutaBRespuesta, 
            Label lblRecomendacionesRutaBRespuesta)
        {
            InitializeComponent();
            nombreRutaBRespuesta = lblNombreRutaBRespuesta;
            sentidoRutaBRespuesta = lblSentidoRutaBRespuesta;
            inicioRutaBRespuesta = lblInicioRutaBRespuesta;
            finRutaBRespuesta = lblFinRutaBRespuesta;
            fechaRutaBRespuesta = lblFechaRutaBRespuesta;
            tiempoEstimadoRutaBRespuesta = lblTiempoEstimadoRutaBRespuesta;
            tiempoMovimientoRutaBRespuesta = lblTiempoMovimientoRutaBRespuesta;
            informacionRutaBRespuesta = lblInformacionRutaBRespuesta;
            dificultadRutaBRespuesta = lblDificultadRutaBRespuesta;
            epocaRutaBRespuesta = lblEpocaRutaBRespuesta;
            recomendacionesRutaBRespuesta = lblRecomendacionesRutaBRespuesta;

            
            if (!(nombreRutaBRespuesta == null && sentidoRutaBRespuesta == null && inicioRutaBRespuesta == null && finRutaBRespuesta == null
                && fechaRutaBRespuesta == null && tiempoEstimadoRutaBRespuesta == null && tiempoMovimientoRutaBRespuesta == null
                && informacionRutaBRespuesta == null && dificultadRutaBRespuesta == null && epocaRutaBRespuesta == null &&
                recomendacionesRutaBRespuesta == null)) { 
                cargarDatos();
            }
            FechaUltimaVez();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            cambiarBandera("es-ES");
        }

        public void cargarDatos()
        {
            TxbNombreRuta.Text = nombreRutaBRespuesta.Content.ToString();
            TxbInicioRuta.Text = inicioRutaBRespuesta.Content.ToString();
            TxbFinalRuta.Text = finRutaBRespuesta.Content.ToString();
            TxbFechaRealizacion.Text = fechaRutaBRespuesta.Content.ToString();
            TxbTiempoEstimado.Text = tiempoEstimadoRutaBRespuesta.Content.ToString();
            TxbTiempoMovimiento.Text = tiempoMovimientoRutaBRespuesta.Content.ToString();
            TxbInformacion.Text = informacionRutaBRespuesta.Content.ToString();
            TxbRecomendaciones.Text = recomendacionesRutaBRespuesta.Content.ToString();
        }

        private void IrARutaDeterminada(object sender, RoutedEventArgs e)
        {
            rutaDeterminada = new RutaX();
            rutaDeterminada.Show();
            Close();
        }

        private void IrAHome(object sender, RoutedEventArgs e)
        {
            home = new Home();
            home.Show();
            Close();
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
            btnInformacion.Visibility = Visibility.Visible;
            lbPerfil.Visibility = Visibility.Visible;
            user.Visibility = Visibility.Visible;
            lbInformacion.Visibility = Visibility.Visible;
            lbAyuda.Visibility = Visibility.Visible;
            ayuda.Visibility = Visibility.Visible;
            lbIdioma.Visibility = Visibility.Visible;
            idioma.Visibility = Visibility.Visible;
            lbSalida.Visibility = Visibility.Visible;
            lbAutor.Visibility = Visibility.Visible;
            btnAutor.Visibility = Visibility.Visible;
            salir.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Visible;
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

        private void cb_sentidoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)CbSentido.SelectedItem;
            String sentido = cbi.Content.ToString();
            if (sentido.Equals("Circular"))
            {
                TxbFinalRuta.IsEnabled = false;
            }else if (sentido.Equals("Lineal"))
            {
                TxbFinalRuta.IsEnabled = true;
            }
        }
        public void FechaUltimaVez()
        {
            lbUltimaVez.Content = DateTime.Now.ToShortDateString();
        }

        private void GuardarRuta(object sender, RoutedEventArgs e)
        {
            guardar = new Documentacion.Guardar();
            guardar.Show();
            DatosActualizados();
            Close();
        }

        private void DatosActualizados()
        {
            if (nombreRutaBRespuesta == null && sentidoRutaBRespuesta == null && inicioRutaBRespuesta == null && finRutaBRespuesta == null
                            && fechaRutaBRespuesta == null && tiempoEstimadoRutaBRespuesta == null && tiempoMovimientoRutaBRespuesta == null
                            && informacionRutaBRespuesta == null && dificultadRutaBRespuesta == null && epocaRutaBRespuesta == null &&
                            recomendacionesRutaBRespuesta == null)
            {
                nombreRutaBRespuesta = new Label();
                sentidoRutaBRespuesta = new Label();
                inicioRutaBRespuesta = new Label();
                finRutaBRespuesta = new Label();
                fechaRutaBRespuesta = new Label();
                tiempoEstimadoRutaBRespuesta = new Label();
                tiempoMovimientoRutaBRespuesta = new Label();
                informacionRutaBRespuesta = new Label();
                dificultadRutaBRespuesta = new Label();
                epocaRutaBRespuesta = new Label();
                recomendacionesRutaBRespuesta = new Label();
            }
            nombreRutaBRespuesta.Content = TxbNombreRuta.Text;
            ComboBoxItem cbiSentido = (ComboBoxItem)CbSentido.SelectedItem;
            if (!(cbiSentido == null))
            {
                sentidoRutaBRespuesta.Content = cbiSentido.Content.ToString();
            }
            inicioRutaBRespuesta.Content = TxbInicioRuta.Text;
            finRutaBRespuesta.Content = TxbFinalRuta.Text;
            fechaRutaBRespuesta.Content = TxbFechaRealizacion.SelectedDate;
            tiempoEstimadoRutaBRespuesta.Content = TxbTiempoEstimado.Text;
            tiempoMovimientoRutaBRespuesta.Content = TxbTiempoMovimiento.Text;
            informacionRutaBRespuesta.Content = TxbInformacion.Text;
            ComboBoxItem cbiDificultad = (ComboBoxItem)CbDificultad.SelectedItem;
            if (!(cbiDificultad == null))
            {
                dificultadRutaBRespuesta.Content = cbiDificultad.Content.ToString();
            }
            ComboBoxItem cbiEpoca = (ComboBoxItem)CbEpoca.SelectedItem;
            if (!(cbiEpoca == null))
            {
                epocaRutaBRespuesta.Content = cbiEpoca.Content.ToString();
            }
            recomendacionesRutaBRespuesta.Content = TxbRecomendaciones.Text;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void AcercaDe(object sender, RoutedEventArgs e)
        {
            infoAutor = new Documentacion.InformaciónAutor();
            infoAutor.Show();
        }
    }
}
