using System;
using System.ComponentModel.DataAnnotations;

namespace PR45.Model
{
    /// <summary>
    /// Пополнения фондов
    /// </summary>
    public class Replenishments
    {
        /// <summary>
        /// Код пополнения
        /// </summary>
        [Key]
        public int Id_replenishment { get; set; }
        /// <summary>
        /// Пополняемый фонд
        /// </summary>
        public int Fond { get; set; }
        /// <summary>
        /// Ответственный за пополнение сотрудник
        /// </summary>
        public int Worker { get; set; }
        /// <summary>
        /// Дата пополнения
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Тип носителя литературы
        /// </summary>
        public int Literature_source { get; set; }
        /// <summary>
        /// Тип литературы
        /// </summary>
        public int Literature_type { get; set; }
        /// <summary>
        /// Издательство
        /// </summary>
        public string Publishing_company { get; set; }
        /// <summary>
        /// Дата издания
        /// </summary>
        public DateTime Publishing_date { get; set; }
        /// <summary>
        /// Кол-во копий
        /// </summary>
        public int Copy_count { get; set; }
    }
}
