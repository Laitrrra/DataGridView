using System;
using System.Collections.Generic;
using System.Linq;
using DataGridView.Entities;
using DataGridView.Services.Contracts;

namespace DataGridView.Services
{
    /// <summary>
    /// In-memory реализация сервиса для работы с турами
    /// </summary>
    public class InMemoryTourService : ITourService
    {
        private readonly List<Tour> tours = new();
        private int nextId = 1;

        public IReadOnlyList<Tour> GetAllTours()
        {
            return tours.AsReadOnly();
        }

        public void AddTour(Tour tour)
        {
            if (tour == null)
            {
                throw new ArgumentNullException(nameof(tour));
            }

            tour.Id = nextId++;
            tours.Add(tour);
        }

        public void UpdateTour(Tour tour)
        {
            if (tour == null)
            {
                throw new ArgumentNullException(nameof(tour));
            }

            var existingTour = tours.FirstOrDefault(t => t.Id == tour.Id);
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
            tours.RemoveAll(t => t.Id == id);
        }

        public TourStatistics GetStatistics()
        {
            return new TourStatistics
            {
                TotalTours = tours.Count,
                TotalCost = tours.Sum(t => (t.PricePerPerson * t.NumberOfPeople) + t.Surcharges),
                ToursWithSurcharges = tours.Count(t => t.Surcharges > 0),
                TotalSurcharges = tours.Sum(t => t.Surcharges)
            };
        }
    }
}