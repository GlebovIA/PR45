using System.ComponentModel.DataAnnotations;

namespace PR45.Model
{
    /// <summary>
    /// Типы литературы
    /// </summary>
    public class Literature_types
    {
        /// <summary>
        /// Код типа литературы
        /// </summary>
        [Key]
        public int Id_type { get; set; }
        /// <summary>
        /// Наименование типа
        /// </summary>
        public string Type_name { get; set; }
    }
}
