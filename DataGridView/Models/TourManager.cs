using System.Collections.Generic;
using System.Linq;

namespace DataGridView.Models
{
    /// <summary>
    /// Менеджер для управления коллекцией туров
    /// </summary>
    public class TourManager
    {
        private List<Tour> tours = new List<Tour>();
        private int nextId = 1;

        /// <summary>
        /// Коллекция туров (только для чтения)
        /// </summary>
        public IReadOnlyList<Tour> Tours => tours;

        /// <summary>
        /// Добавляет новый тур
        /// </summary>
        public void Add(Tour tour)
        {
            tour.Id = nextId++;
            tours.Add(tour);
        }

        /// <summary>
        /// Обновляет существующий тур
        /// </summary>
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

        /// <summary>
        /// Удаляет тур по идентификатору
        /// </summary>
        public void Remove(int id)
        {
            tours.RemoveAll(t => t.Id == id);
        }

        /// <summary>
        /// Общее количество туров
        /// </summary>
        public int TotalTours => tours.Count;

        /// <summary>
        /// Общая стоимость всех туров
        /// </summary>
        public decimal TotalCost => tours.Sum(t => CalculateTotalCost(t));

        /// <summary>
        /// Количество туров с доплатами
        /// </summary>
        public int ToursWithSurcharges => tours.Count(t => t.Surcharges > 0);

        /// <summary>
        /// Общая сумма доплат
        /// </summary>
        public decimal TotalSurcharges => tours.Sum(t => t.Surcharges);

        /// <summary>
        /// Вычисляет общую стоимость тура
        /// </summary>
        private decimal CalculateTotalCost(Tour tour)
        {
            return (tour.PricePerPerson * tour.NumberOfPeople) + tour.Surcharges;
        }
    }
}