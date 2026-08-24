using System.ComponentModel.DataAnnotations;

namespace DeliveryOrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Город отправителя обязателен")]
        public string SenderCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Адрес отправителя обязателен")]
        public string SenderAdress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Город получателя обязателен")]
        public string RecipientCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Адрес получателя обязателен")]
        public string RecipientAdress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Вес груза обязателен")]
        [Range(0.1, 100000, ErrorMessage = "Вес должен быть больше 0")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Дата забора груза обязательна")]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }
    }
}