using System.ComponentModel.DataAnnotations;

namespace DeliveryOrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Город отправителя обязателен")]
        [Display(Name = "Город")]
        public string SenderCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Адрес отправителя обязателен")]
        [Display(Name = "Адрес отправителя")]
        public string SenderAdress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Город получателя обязателен")]
        [Display(Name = "Город получателя")]
        public string RecipientCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Адрес получателя обязателен")]
        [Display(Name = "Адрес получателя")]
        public string RecipientAdress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Вес груза обязателен")]
        [Range(0.1, 100000, ErrorMessage = "Вес должен быть больше 0")]
        [Display(Name = "Вес груза (кг)")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Дата забора груза обязательна")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата забора груза")]
        public DateTime PickupDate { get; set; }
    }
}