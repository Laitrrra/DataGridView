using System.ComponentModel.DataAnnotations;
using DataGridView.Constants;

namespace DataGridView.Entities.Models
{
    /// <summary>
    /// Модель тура
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Идентификатор тура
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Направление тура
        /// </summary>
        [Display(Name = "Направление")]
        [Required(ErrorMessage = "{0} обязательно для выбора")]
        public Direction Direction { get; set; } = Direction.Turkey;

        /// <summary>
        /// Дата вылета
        /// </summary>
        [Display(Name = "Дата вылета")]
        [Required(ErrorMessage = "{0} обязательна для заполнения")]
        public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(7);

        /// <summary>
        /// Количество ночей
        /// </summary>
        [Display(Name = "Количество ночей")]
        [Range(ValidationConsts.MinNights, ValidationConsts.MaxNights,
               ErrorMessage = "{0} должно быть между {1} и {2}")]
        public int Nights { get; set; } = 7;

        /// <summary>
        /// Стоимость за человека
        /// </summary>
        [Display(Name = "Стоимость за человека")]
        [Range(ValidationConsts.MinPrice, ValidationConsts.MaxPrice,
               ErrorMessage = "{0} должна быть в диапазоне от {1} до {2}")]
        public decimal PricePerPerson { get; set; } = 10000m;

        /// <summary>
        /// Количество людей
        /// </summary>
        [Display(Name = "Количество людей")]
        [Range(ValidationConsts.MinNumberOfPeople, ValidationConsts.MaxNumberOfPeople,
               ErrorMessage = "{0} должно быть между {1} и {2}")]
        public int NumberOfPeople { get; set; } = 2;

        /// <summary>
        /// Наличие Wi-Fi
        /// </summary>
        [Display(Name = "Wi-Fi")]
        public bool HasWiFi { get; set; } = true;

        /// <summary>
        /// Доплаты
        /// </summary>
        [Display(Name = "Доплаты")]
        [Range(ValidationConsts.MinSurcharges, ValidationConsts.MaxSurcharges,
               ErrorMessage = "{0} не могут быть отрицательными")]
        public decimal Surcharges { get; set; }

        /// <summary>
        /// Рассчитать общую стоимость тура
        /// </summary>
        public decimal CalculateTotalCost() => (PricePerPerson * NumberOfPeople) + Surcharges;

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