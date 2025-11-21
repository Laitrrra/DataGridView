using System.Collections.Generic;
using DataGridView.Entities;

namespace DataGridView.Services
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
        /// Общее количество туров
        /// </summary>
        int GetTotalTours();

        /// <summary>
        /// Общая стоимость всех туров
        /// </summary>
        decimal GetTotalCost();

        /// <summary>
        /// Количество туров с доплатами
        /// </summary>
        int GetToursWithSurcharges();

        /// <summary>
        /// Общая сумма доплат
        /// </summary>
        decimal GetTotalSurcharges();
    }
}