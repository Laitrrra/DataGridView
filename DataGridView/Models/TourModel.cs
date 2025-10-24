using System.Collections.Generic;
using System.Linq;

namespace DataGridView.Models
{
    public class TourModel
    {
        private List<Tour> tours = new List<Tour>();
        private int nextId = 1;

        public List<Tour> Tours => tours;

        public void Add(Tour tour)
        {
            tour.Id = nextId++;
            tours.Add(tour);
        }

        public void Update(Tour updatedTour)
        {
            var existingTour = tours.FirstOrDefault(t => t.Id == updatedTour.Id);
            if (existingTour != null)
            {
                existingTour.Direction = updatedTour.Direction;
                existingTour.DepartureDate = updatedTour.DepartureDate;
                existingTour.Nights = updatedTour.Nights;
                existingTour.PricePerPerson = updatedTour.PricePerPerson;
                existingTour.NumberOfPeople = updatedTour.NumberOfPeople;
                existingTour.HasWiFi = updatedTour.HasWiFi;
                existingTour.Surcharges = updatedTour.Surcharges;
            }
        }

        public void Remove(int id)
        {
            tours.RemoveAll(t => t.Id == id);
        }

        public int TotalTours => tours.Count;
        public decimal TotalCost => tours.Sum(t => t.TotalCost);
        public int ToursWithSurcharges => tours.Count(t => t.Surcharges > 0);
        public decimal TotalSurcharges => tours.Sum(t => t.Surcharges);
    }
}