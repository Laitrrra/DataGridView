using DataGridView.Services;

namespace DataGridView.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ITourService tourService = new InMemoryTourService();
            Application.Run(new MainForm(tourService));
        }
    }
}