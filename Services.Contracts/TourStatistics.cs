namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Класс для хранения статистики туров
    /// </summary>
    public class TourStatistics
    {
        /// <summary>
        /// Всего туров
        /// </summary>
        public int TourCount { get; set; }

        /// <summary>
        /// Общая стоимость всех туров
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Количество туров с доплатами
        /// </summary>
        public int ToursWithSurcharges { get; set; }

        /// <summary>
        /// Общая сумма доплат
        /// </summary>
        public decimal TotalSurcharges { get; set; }
    }
}