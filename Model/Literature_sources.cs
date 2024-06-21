using System.ComponentModel.DataAnnotations;

namespace PR45.Model
{
    /// <summary>
    /// Носителей литературы
    /// </summary>
    public class Literature_sources
    {
        /// <summary>
        /// Код носителя
        /// </summary>
        [Key]
        public int Id_source { get; set; }
        /// <summary>
        /// Наименование носителя
        /// </summary>
        public string Source_name { get; set; }
    }
}
