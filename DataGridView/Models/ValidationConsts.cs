using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Models
{
    /// <summary>
    /// Константы для валидации
    /// </summary>
    public static class ValidationConsts
    {
        /// <summary>
        /// Минимальное количество ночей
        /// </summary>
        public const int MinNights = 1;

        /// <summary>
        /// Максимальное количество ночей
        /// </summary>
        public const int MaxNights = 365;

        /// <summary>
        /// Минимальная стоимость тура
        /// </summary>
        public const double MinPrice = 0.01;

        /// <summary>
        /// Максимальная стоимость тура
        /// </summary>
        public const double MaxPrice = 10000000;

        /// <summary>
        /// Минимальное количество людей
        /// </summary>
        public const int MinNumberOfPeople = 1;

        /// <summary>
        /// Максимальное количество людей
        /// </summary>
        public const int MaxNumberOfPeople = 100;

        /// <summary>
        /// Минимальная сумма доплат
        /// </summary>
        public const double MinSurcharges = 0;

        /// <summary>
        /// Максимальная сумма доплат
        /// </summary>
        public const double MaxSurcharges = 1000000;
    }
}