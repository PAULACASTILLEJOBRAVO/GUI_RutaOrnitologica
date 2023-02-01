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
    /// Lógica de interacción para GuiasTuristicos.xaml
    /// </summary>
    public partial class GuiasTuristicos : Window
    {
        private Home home;
        private GymkanaPromocion compartir;
        private Documentacion.AbandonarAplicacion abandonarAplicacion;
        private List<GuiaTuristico> listadoGuiaTuristico;
        private Controlador control;
        private Documentacion.InformaciónAutor infoAutor;

        public GuiasTuristicos()
        {
            InitializeComponent();
            FechaUltimaVez();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            cambiarBandera("es-ES");
            control = new Controlador();
            listadoGuiaTuristico = control.CargarContenidoListaXML(listadoGuiaTuristico);
            cargarDatosBase();
        }
        public void cargarDatosBase()
        {
            int elementoListaSeleccionado;
            for (elementoListaSeleccionado = 0; elementoListaSeleccionado < listadoGuiaTuristico.Count; elementoListaSeleccionado++)
            {
                spPanelDinamicoGuiasTuristicos.Children.Add(new ControrPersonalizadoGuia(listadoGuiaTuristico[elementoListaSeleccionado], ImgIdiomaGuia, lblNombreGuia, lblApellidoGuia, lblTelefonoGuia, lblCorreoElectronicoGuia));

            }
        }
        private void btnAniadir_Click(object sender, RoutedEventArgs e)
        {    
            spPanelDinamicoGuiasTuristicos.Children.Add(new ControrPersonalizadoGuia(null, null, null, null, null, null));
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (spPanelDinamicoGuiasTuristicos.Children.Count >= 1)
            {
                spPanelDinamicoGuiasTuristicos.Children.RemoveAt(spPanelDinamicoGuiasTuristicos.Children.Count - 1);
            }
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
        private void AcercaDe(object sender, RoutedEventArgs e)
        {
            infoAutor = new Documentacion.InformaciónAutor();
            infoAutor.Show();
        }
    }
}
