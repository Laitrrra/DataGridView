using DataGridView.Entities;
using DataGridView.Services.Contracts;

public class InMemoryTourService : ITourService
{
    private readonly List<Tour> tours = new();
    private int nextId = 1;

    public IReadOnlyList<Tour> GetAllTours() => tours.AsReadOnly();

    public void AddTour(Tour tour)
    {
        tour.Id = nextId++;
        tours.Add(tour);
    }

    public void UpdateTour(Tour tour)
    {
        var existing = tours.FirstOrDefault(t => t.Id == tour.Id);
        if (existing != null)
        {
            existing.Direction = tour.Direction;
            existing.DepartureDate = tour.DepartureDate;
            existing.Nights = tour.Nights;
            existing.PricePerPerson = tour.PricePerPerson;
            existing.NumberOfPeople = tour.NumberOfPeople;
            existing.HasWiFi = tour.HasWiFi;
            existing.Surcharges = tour.Surcharges;
        }
    }

    public void DeleteTour(int id)
    {
        tours.RemoveAll(t => t.Id == id);
    }

    public int GetTotalTours() => tours.Count;

    public decimal GetTotalCost() =>
        tours.Sum(t => (t.PricePerPerson * t.NumberOfPeople) + t.Surcharges);

    public int GetToursWithSurcharges() =>
        tours.Count(t => t.Surcharges > 0);

    public decimal GetTotalSurcharges() =>
        tours.Sum(t => t.Surcharges);
}
