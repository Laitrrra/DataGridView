using System.Collections.Generic;
using DataGridView.Entities;

namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для работы с турами
    /// </summary>
    public interface ITourService
    {
        /// <summary>
        /// Получить все туры
        /// </summary>
        IReadOnlyList<Tour> GetAllTours();

        /// <summary>
        /// Добавить новый тур
        /// </summary>
        void AddTour(Tour tour);

        /// <summary>
        /// Обновить существующий тур
        /// </summary>
        void UpdateTour(Tour tour);

        /// <summary>
        /// Удалить тур по идентификатору
        /// </summary>
        void DeleteTour(int id);

        /// <summary>
        /// Получить статистику по турам
        /// </summary>
        TourStatistics GetStatistics();
    }
}