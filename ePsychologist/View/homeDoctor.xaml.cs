using ePsychologist.Models;
using System.Diagnostics;
using System.Windows.Controls;

namespace ePsychologist.View
{
    /// <summary>
    /// Interaction logic for homeDoctor.xaml
    /// </summary>
    public partial class homeDoctor : Page
    {
        public homeDoctor()
        {
            InitializeComponent();
            Connection cn = Connection.DbConnection;
            int test = cn.GetUserID();
            Debug.WriteLine("id: " + test);
        }
    }
}
