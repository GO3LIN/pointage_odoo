using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Pointage.client
{

    public partial class MainPage : UserControl
    {
        odooNS.odooWSClient cli = new odooNS.odooWSClient();
        //Odoo.odooSoapClient cli = new Odoo.odooSoapClient();
        public MainPage()
        {
            InitializeComponent();
            dateToday.Content += DateTime.UtcNow.ToString("dd MMM yyyy");
            cli.pointerCompleted += cli_pointerCompleted;
            //cli.GetUserOdooCompleted += new EventHandler<Odoo.GetUserOdooCompletedEventArgs>(cli_GetUserOdooCompleted);
            //cli.pointerCompleted += new EventHandler<Odoo.pointerCompletedEventArgs>(cli_pointerCompleted);
            //cli.pointerLogCompleted += cli_pointerLogCompleted;
        }

        void cli_pointerCompleted(object sender, odooNS.pointerCompletedEventArgs e)
        {
            Output.Content = e.Result.ToString();
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Odoo web services consumption
            cli.pointerAsync(login.Text, pass.Text);
            //cli.GetUserOdooAsync(login.Text, pass.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
