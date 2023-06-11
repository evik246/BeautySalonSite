﻿using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.ServiceModels
{
    public class ServiceCreate
    {
        [Required(ErrorMessage = "Укажите название услуги")]
        [StringLength(100, ErrorMessage = "Имя должно быть меньше или равно 100 символам")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите цену услуги")]
        [Range(0.01, 9999.99, ErrorMessage = "Цена услуги недействительна")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Укажите время выполнения услуги")]
        [Range(typeof(TimeSpan), "00:00:01", "23:59:59", ErrorMessage = "Время выполнения услуги должно быть менее 24 часов")]
        public TimeSpan ExecutionTime { get; set; }

        [Required(ErrorMessage = "Укажите категорию услуги")]
        public int CategoryId { get; set; }
    }
}
