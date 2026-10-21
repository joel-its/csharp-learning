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

namespace SystemInternalsWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
			//Code analog zum Struktogramm
            string eingabe, ausgabe;
           //...
           //switch(cboAuswahl.Text)...
           //...

           eingabe = cboAuswahl.Text;
           
           switch (eingabe)
           {
               case ("Systembenutzer"):
                    ausgabe = Systeminternals.GetUserInfo();
                    break;
               case ("Systemlaufzeit"):
                   ausgabe  = Systeminternals.GetUpTime();
                   break;
               case ("Freigaben"):
                   ausgabe  = Systeminternals.GetAllShares();
                   break;
               case ("Seriennummer"):
                   ausgabe  = Systeminternals.GetSerialnumber();
                   break;
               case ("DriveInfo"):
                   ausgabe  = Systeminternals.GetStorageInfo();
                   break;
               default:
                   ausgabe = "Fehler";
                   break;
           }

           txbAusgabe.Text = ausgabe;
        }
    }
}
