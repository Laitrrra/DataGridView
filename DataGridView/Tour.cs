using DataGridView.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataGridView
{
    public class Tour
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Выберите направление")]
        public Direction Direction { get; set; } = Direction.Turkey;

        [Required(ErrorMessage = "Укажите дату вылета")]
        [CustomValidation(typeof(Tour), nameof(ValidateDepartureDate))]
        public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(7); 

        [Range(1, 365, ErrorMessage = "Количество ночей должно быть от 1 до 365")]
        public int Nights { get; set; } = 7;

        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
        public decimal PricePerPerson { get; set; } = 10000m; 

        [Range(1, 100, ErrorMessage = "Количество людей должно быть от 1 до 100")]
        public int NumberOfPeople { get; set; } = 2;

        public bool HasWiFi { get; set; } = true;

        [Range(0, double.MaxValue, ErrorMessage = "Доплаты не могут быть отрицательными")]
        public decimal Surcharges { get; set; }

        public decimal TotalCost => (PricePerPerson * NumberOfPeople) + Surcharges;

        public static string GetDirectionDisplay(Direction direction)
        {
            return direction switch
            {
                Direction.Turkey => "Турция",
                Direction.Spain => "Испания",
                Direction.Italy => "Италия",
                Direction.France => "Франция",
                Direction.Shushary => "Шушары",
                Direction.Unknown => "Неизвестно",
                _ => "Неизвестно"
            };
        }

        public static ValidationResult ValidateDepartureDate(DateTime date, ValidationContext context)
        {
            if (date < DateTime.Today)
            {
                return new ValidationResult("Дата вылета не может быть в прошлом");
            }
            return ValidationResult.Success;
        }

        public Tour Clone()
        {
            return new Tour
            {
                Id = this.Id,
                Direction = this.Direction,
                DepartureDate = this.DepartureDate,
                Nights = this.Nights,
                PricePerPerson = this.PricePerPerson,
                NumberOfPeople = this.NumberOfPeople,
                HasWiFi = this.HasWiFi,
                Surcharges = this.Surcharges
            };
        }
    }
}