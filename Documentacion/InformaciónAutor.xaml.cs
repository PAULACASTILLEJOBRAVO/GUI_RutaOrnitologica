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
    /// Lógica de interacción para InformaciónAutor.xaml
    /// </summary>
    public partial class InformaciónAutor : Window
    {
        public InformaciónAutor()
        {
            InitializeComponent();
            infoGUI();
        }

        private void infoGUI()
        {
           string datosGUI = "Data from the GUI management of ornithological routes in the province of Toledo:\n";
           datosGUI += "Author/s: Paula Castillejo Bravo and Virginia López Marcos.\n" +
                    "Date: 03-11-2022.\n" +
                    "Version: 2.0.0.\n" +
                    "Date of publication: 15-12-2022.\n" +
                    "Provided by: Digital Solutions.\n" +
                    "Date of update: 13-01-2023.\n";
           txtContenido.Text = datosGUI;    
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
