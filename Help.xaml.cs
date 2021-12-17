using System.Windows;
using System.Windows.Navigation;

namespace TP_2
{
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
            Logger.Log("Info","Help page start");

        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}