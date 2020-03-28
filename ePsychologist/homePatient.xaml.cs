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

namespace ePsychologist
{
    /// <summary>
    /// Logika interakcji dla klasy homePatient.xaml
    /// </summary>
    public partial class homePatient : Page
    {
        public homePatient()
        {
            InitializeComponent();
        }

        private void sicknessInfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (sickInfoFrame.Content.Equals(""))
                sickInfoFrame.Content = new sicknessInfPage();
            else
                sickInfoFrame.Content = "";

        }

        private void editPersonalInfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (editPersonalInfoFrame.Content.Equals(""))
                editPersonalInfoFrame.Content = new changePersonalData();
            else
                editPersonalInfoFrame.Content = "";
        }
    }
}
