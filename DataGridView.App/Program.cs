using DataGridView.Services;
using DataGridView.Services.Contracts;

namespace DataGridView.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ITourService tourService = new InMemoryTourService();
            AddTestData(tourService);

            Application.Run(new MainForm(tourService));
        }

        private static void AddTestData(ITourService tourService)
        {
            var testTours = new[]
            {
                new DataGridView.Entities.Tour
                {
                    Direction = DataGridView.Entities.Direction.Turkey,
                    DepartureDate = DateTime.Now.AddDays(7),
                    Nights = 10,
                    PricePerPerson = 45000,
                    NumberOfPeople = 2,
                    HasWiFi = true,
                    Surcharges = 5000
                },
                new DataGridView.Entities.Tour
                {
                    Direction = DataGridView.Entities.Direction.Spain,
                    DepartureDate = DateTime.Now.AddDays(14),
                    Nights = 7,
                    PricePerPerson = 65000,
                    NumberOfPeople = 3,
                    HasWiFi = true,
                    Surcharges = 8000
                },
                new DataGridView.Entities.Tour
                {
                    Direction = DataGridView.Entities.Direction.Italy,
                    DepartureDate = DateTime.Now.AddDays(21),
                    Nights = 8,
                    PricePerPerson = 55000,
                    NumberOfPeople = 2,
                    HasWiFi = false,
                    Surcharges = 3000
                },
                new DataGridView.Entities.Tour
                {
                    Direction = DataGridView.Entities.Direction.France,
                    DepartureDate = DateTime.Now.AddDays(30),
                    Nights = 6,
                    PricePerPerson = 70000,
                    NumberOfPeople = 4,
                    HasWiFi = true,
                    Surcharges = 12000
                },
                new DataGridView.Entities.Tour
                {
                    Direction = DataGridView.Entities.Direction.Shushary,
                    DepartureDate = DateTime.Now.AddDays(2),
                    Nights = 2,
                    PricePerPerson = 5000,
                    NumberOfPeople = 1,
                    HasWiFi = false,
                    Surcharges = 0
                }
            };

            foreach (var tour in testTours)
            {
                tourService.AddTour(tour);
            }
        }
    }
}
