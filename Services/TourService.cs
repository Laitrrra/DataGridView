using DataGridView.Entities.Models;
using DataGridView.Services;
using DataGridView.Services.Contracts;

namespace DataGridView.Services
{
    /// <summary>
    /// Сервис для доступа к турам, хранящимся в памяти
    /// </summary>
    public class TourService : ITourService
    {
        private readonly List<Tour> _tours;
        private int _nextId;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TourService" />
        /// </summary>
        public TourService()
        {
            // Начальные данные
            _tours = new List<Tour>
            {
                new Tour
                {
                    Id = 1,
                    Direction = Direction.Turkey,
                    DepartureDate = DateTime.Now.AddDays(7),
                    Nights = 10,
                    PricePerPerson = 45000,
                    NumberOfPeople = 2,
                    HasWiFi = true,
                    Surcharges = 5000
                },
                new Tour
                {
                    Id = 2,
                    Direction = Direction.Spain,
                    DepartureDate = DateTime.Now.AddDays(14),
                    Nights = 7,
                    PricePerPerson = 65000,
                    NumberOfPeople = 3,
                    HasWiFi = true,
                    Surcharges = 8000
                },
                new Tour
                {
                    Id = 3,
                    Direction = Direction.Italy,
                    DepartureDate = DateTime.Now.AddDays(21),
                    Nights = 8,
                    PricePerPerson = 55000,
                    NumberOfPeople = 2,
                    HasWiFi = false,
                    Surcharges = 3000
                }
            };
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Tour>> GetAllTours()
            => await Task.FromResult<IEnumerable<Tour>>(_tours);

        /// <inheritdoc />
        public async Task AddTour(Tour tour)
        {
            tour.Id = _tours.Count > 0 ? _tours.Max(t => t.Id) + 1 : 1;
            _tours.Add(tour);
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task UpdateTour(Tour tour)
        {
            var existingTour = _tours.FirstOrDefault(t => t.Id == tour.Id);
            if (existingTour != null)
            {
                existingTour.Direction = tour.Direction;
                existingTour.DepartureDate = tour.DepartureDate;
                existingTour.Nights = tour.Nights;
                existingTour.PricePerPerson = tour.PricePerPerson;
                existingTour.NumberOfPeople = tour.NumberOfPeople;
                existingTour.HasWiFi = tour.HasWiFi;
                existingTour.Surcharges = tour.Surcharges;
            }
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task DeleteTour(int id)
        {
            var existingTour = _tours.FirstOrDefault(t => t.Id == id);
            if (existingTour == null)
            {
                return;
            }
            _tours.Remove(existingTour);
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task<Tour?> GetTourById(int id)
            => await Task.FromResult(_tours.FirstOrDefault(t => t.Id == id));

        /// <inheritdoc />
        public async Task<decimal> GetTourTotalCost(int id)
        {
            var tour = _tours.FirstOrDefault(t => t.Id == id);
            if (tour == null)
            {
                return 0;
            }
            return await Task.FromResult(tour.CalculateTotalCost());
        }

        /// <inheritdoc />
        public async Task<TourStatistics> GetStatistics()
        {
            var tours = await GetAllTours();
            return new TourStatistics
            {
                TourCount = tours.Count(),
                TotalCost = tours.Sum(t => t.CalculateTotalCost()),
                ToursWithSurcharges = tours.Count(t => t.Surcharges > 0),
                TotalSurcharges = tours.Sum(t => t.Surcharges)
            };
        }
    }
}