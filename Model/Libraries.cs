using System.ComponentModel.DataAnnotations;

namespace PR45.Model
{
    /// <summary>
    /// Библиотеки
    /// </summary>
    public class Libraries
    {
        /// <summary>
        /// Код библиотеки
        /// </summary>
        [Key]
        public int Id_library { get; set; }
        /// <summary>
        /// Наименование библиотеки
        /// </summary>
        public string Library_name { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
    }
}
