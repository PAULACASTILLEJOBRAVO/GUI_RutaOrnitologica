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
    /// Lógica de interacción para ModificarRuta.xaml
    /// </summary>
    public partial class ModificarRuta : Window
    {
        private RutaX rutaDeterminada;
        private MainWindow inicio;
        private GuiasTuristicos guiasTuristico;
        private GymkanaPromocion compartir;
        private Documentacion.AbandonarAplicacion abandonarAplicacion;
        private Documentacion.InformaciónAutor infoAutor;
        private Documentacion.Guardar guardar;
        public ModificarRuta()
        {
            InitializeComponent();
            FechaUltimaVez();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            cambiarBandera("es-ES");
        }


        private void IrAHome(object sender, RoutedEventArgs e)
        {
            inicio = new MainWindow();
            inicio.Show();
            Close();
        }

        private void IrARutaDeterminada(object sender, RoutedEventArgs e)
        {
            rutaDeterminada = new RutaX();
            rutaDeterminada.Show();
            Close();
        }

        private void IrAGuiasTuristicos(object sender, RoutedEventArgs e)
        {
            guiasTuristico = new GuiasTuristicos();
            guiasTuristico.Show();
            Close();
        }

        private void IrAGymkanaPromocion(object sender, RoutedEventArgs e)
        {
            compartir = new GymkanaPromocion();
            compartir.Show();
            Close();
        }
        private void inicioArrastrar(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject((Image)sender);
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void añadirObjeto(object sender, DragEventArgs e)
        {
            Image imgDragged = (Image)e.Data.GetData(typeof(Image));
            Image imgToUpdate = (Image)e.OriginalSource;
            imgToUpdate.Source = imgDragged.Source;
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

        private void Guardar(object sender, RoutedEventArgs e)
        {
            guardar = new Documentacion.Guardar();
            guardar.Show();
        }
    }
}
