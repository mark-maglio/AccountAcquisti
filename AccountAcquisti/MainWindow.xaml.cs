using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginAcquisti
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtnome.Focus();
            txtPrezzo.IsEnabled = false;
            txtQuant.IsEnabled = false;
            cmbProd.IsEnabled = false;
            btnPulisci.IsEnabled = false;
            btnStampa.IsEnabled = false;

        }
        private const string PASSW = "5Luglio";
        private string[] prodotti = new string[] { "Felpa", "Maglietta","Canottiera", " Jeans", "Mutande ", "Calzettoni" };

        private void BtnAccedi_Click(object sender, RoutedEventArgs e)
        {
            if (txtnome.Text != "" && txtpass.Text != "")
            {
                if (txtpass.Text == PASSW)
                {
                    txtnome.IsEnabled = false;
                    txtpass.IsEnabled = false;
                    btnAccedi.IsEnabled = false;

                    txtPrezzo.IsEnabled = true;
                    txtQuant.IsEnabled = true;
                    cmbProd.IsEnabled = true;
                    btnPulisci.IsEnabled = true;
                    btnStampa.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Password errata", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtpass.Text = "";
                    txtpass.Focus();
                }

            }
            else
            {
                MessageBox.Show("Devi inserire tutte le credenziali per accedere", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Information);
                txtnome.Text = "";
                txtpass.Text = "";
                txtnome.Focus();
            }

        }

        private void CmbProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var prod in prodotti)
            {
                cmbProd.Items.Add(prod);
            }
        }

        private void BtnPulisci_Click(object sender, RoutedEventArgs e)
        {
            txtQuant.Text = "";
            txtPrezzo.Text = "";
            cmbProd.SelectedItem = -1;
        }

        private void BtnStampa_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuant.Text != "" && txtPrezzo.Text != "" && cmbProd.SelectedIndex != -1)
            {
                try
                {
                    double quantita = Convert.ToDouble(txtQuant.Text);
                    double prezzo = Convert.ToDouble(txtPrezzo.Text);

                    double tot = quantita * prezzo;
                    string stampa = $"il cliente {txtnome.Text} ha acquistato il prodotto {cmbProd.SelectedItem}, spendendo {txtPrezzo.Text} euro";
                    lblAcquisti.Items.Add(stampa);

                    txtQuant.Text = "";
                    txtPrezzo.Text = "";
                    cmbProd.SelectedIndex = -1;
                    lblAcquisti.IsEnabled = true;
                    btnRimuovi.IsEnabled = true;

                }
                //lancia l'eccezione
                catch (Exception)
                {
                    MessageBox.Show("Ci sono degli errori nell'immissione dei dati", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Non sono stati immessi tutti i dati", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        //rimuovi
        private void BtnRimuovi_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}