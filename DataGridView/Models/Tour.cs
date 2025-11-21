using System;
using System.ComponentModel.DataAnnotations;

namespace DataGridView.Models
{
    /// <summary>
    /// Модель данных тура
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Уникальный идентификатор тура
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Направление тура
        /// </summary>
        [Display(Name = "Направление")]
        [Required(ErrorMessage = "Выберите направление")]
        public Direction Direction { get; set; } = Direction.Turkey;

        /// <summary>
        /// Дата вылета
        /// </summary>
        [Display(Name = "Дата вылета")]
        [Required(ErrorMessage = "Укажите дату вылета")]
        [DepartureDateValidation]
        public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(7);

        /// <summary>
        /// Количество ночей
        /// </summary>
        [Display(Name = "Количество ночей")]
        [Range(ValidationConsts.MinNights, ValidationConsts.MaxNights,
               ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int Nights { get; set; } = 7;

        /// <summary>
        /// Стоимость за одного отдыхающего
        /// </summary>
        [Display(Name = "Стоимость за отдыхающего")]
        [Range(ValidationConsts.MinPrice, ValidationConsts.MaxPrice,
               ErrorMessage = "{0} должна быть от {1} до {2}")]
        public decimal PricePerPerson { get; set; } = 10000m;

        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        [Display(Name = "Количество отдыхающих")]
        [Range(ValidationConsts.MinNumberOfPeople, ValidationConsts.MaxNumberOfPeople,
               ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int NumberOfPeople { get; set; } = 2;

        /// <summary>
        /// Наличие Wi-Fi
        /// </summary>
        [Display(Name = "Wi-Fi")]
        public bool HasWiFi { get; set; } = true;

        /// <summary>
        /// Дополнительные платежи
        /// </summary>
        [Display(Name = "Доплаты")]
        [Range(ValidationConsts.MinSurcharges, ValidationConsts.MaxSurcharges,
               ErrorMessage = "{0} не могут быть отрицательными")]
        public decimal Surcharges { get; set; }

        /// <summary>
        /// Создает копию текущего тура
        /// </summary>
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