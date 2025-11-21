using DataGridView.App.Forms;
using DataGridView.Services;

namespace DataGridView
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var tourService = new TourService();
            Application.Run(new MainForm(tourService));
        }
    }
}