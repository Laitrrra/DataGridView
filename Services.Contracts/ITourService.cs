using DataGridView.Entities.Models;

namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления информацией о турах
    /// </summary>
    public interface ITourService
    {
        /// <summary>
        /// Получить все туры
        /// </summary>
        Task<IEnumerable<Tour>> GetAllTours();

        /// <summary>
        /// Добавить новый тур
        /// </summary>
        Task AddTour(Tour tour);

        /// <summary>
        /// Обновить тур
        /// </summary>
        Task UpdateTour(Tour tour);

        /// <summary>
        /// Удалить тур по ID
        /// </summary>
        Task DeleteTour(int id);

        /// <summary>
        /// Найти тур по ID
        /// </summary>
        Task<Tour?> GetTourById(int id);

        /// <summary>
        /// Получить общую стоимость тура
        /// </summary>
        Task<decimal> GetTourTotalCost(int id);

        /// <summary>
        /// Получить статистику по турам
        /// </summary>
        Task<TourStatistics> GetStatistics();
    }
}