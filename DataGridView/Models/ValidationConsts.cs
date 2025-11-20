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
        public const int MinNights = 1;
        public const int MaxNights = 365;

        public const double MinPrice = 0.01;
        public const double MaxPrice = 10000000;

        public const int MinNumberOfPeople = 1;
        public const int MaxNumberOfPeople = 100;

        public const double MinSurcharges = 0;
        public const double MaxSurcharges = 1000000;
    }
}