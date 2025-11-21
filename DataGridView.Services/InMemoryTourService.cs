using System;
using System.Collections.Generic;
using System.Linq;
using DataGridView.Entities;

namespace DataGridView.Services
{
    /// <summary>
    /// In-memory реализация сервиса для работы с турами
    /// </summary>
    public class InMemoryTourService : ITourService
    {
        private readonly List<Tour> _tours = new List<Tour>();
        private int _nextId = 1;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса с тестовыми данными
        /// </summary>
        public InMemoryTourService()
        {
            InitializeTestData();
        }

        /// <summary>
        /// Инициализирует новый экземпляр сервиса с указанными данными
        /// </summary>
        public InMemoryTourService(IEnumerable<Tour> initialTours)
        {
            if (initialTours != null)
            {
                foreach (var tour in initialTours)
                {
                    AddTour(tour);
                }
            }
        }

        private void InitializeTestData()
        {
            var testTours = new[]
            {
                new Tour
                {
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
                    Direction = Direction.Italy,
                    DepartureDate = DateTime.Now.AddDays(21),
                    Nights = 8,
                    PricePerPerson = 55000,
                    NumberOfPeople = 2,
                    HasWiFi = false,
                    Surcharges = 3000
                },
                new Tour
                {
                    Direction = Direction.France,
                    DepartureDate = DateTime.Now.AddDays(30),
                    Nights = 6,
                    PricePerPerson = 70000,
                    NumberOfPeople = 4,
                    HasWiFi = true,
                    Surcharges = 12000
                },
                new Tour
                {
                    Direction = Direction.Shushary,
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
                AddTour(tour);
            }
        }

        public IReadOnlyList<Tour> GetAllTours()
        {
            return _tours.AsReadOnly();
        }

        public void AddTour(Tour tour)
        {
            if (tour == null)
                throw new ArgumentNullException(nameof(tour));

            tour.Id = _nextId++;
            _tours.Add(tour);
        }

        public void UpdateTour(Tour tour)
        {
            if (tour == null)
                throw new ArgumentNullException(nameof(tour));

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
        }

        public void DeleteTour(int id)
        {
            _tours.RemoveAll(t => t.Id == id);
        }

        public int GetTotalTours()
        {
            return _tours.Count;
        }

        public decimal GetTotalCost()
        {
            return _tours.Sum(t => (t.PricePerPerson * t.NumberOfPeople) + t.Surcharges);
        }

        public int GetToursWithSurcharges()
        {
            return _tours.Count(t => t.Surcharges > 0);
        }

        public decimal GetTotalSurcharges()
        {
            return _tours.Sum(t => t.Surcharges);
        }
    }
}