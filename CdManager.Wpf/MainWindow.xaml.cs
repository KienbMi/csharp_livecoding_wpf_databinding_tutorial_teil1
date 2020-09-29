using System.Collections.Generic;
using System.Windows;
using CdManager.Model;
using CdManager.Wpf.Windows;

namespace CdManager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cd> _cds;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repository = Repository.GetInstance();
            _cds = repository.GetAllCds();
            lbxCds.ItemsSource = _cds;

            btnNew.Click += BtnNew_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Herausfinden, welche Cd markiert ist
            Cd selectedCd = lbxCds.SelectedItem as Cd;
            if(selectedCd == null)
            {
                MessageBox.Show("Sie müssen eine Cd ausgewählt haben!");
                return;
            }

            // Repository erweitern -> DeleteCd-Methode

            // Alle übrig gebliebenen Cds aus Repository laden und als ItemsSource setzen
            Repository repository = Repository.GetInstance();
            _cds = repository.GetAllCds();
            lbxCds.ItemsSource = _cds;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            AddCdWindow addCdWindow = new AddCdWindow();
            addCdWindow.ShowDialog();

            Repository repository = Repository.GetInstance();
            _cds = repository.GetAllCds();
            lbxCds.ItemsSource = _cds;
        }
    }
}
