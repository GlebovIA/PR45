using System.ComponentModel.DataAnnotations;

namespace PR45.Model
{
    /// <summary>
    /// Фонды
    /// </summary>
    public class Fonds
    {
        /// <summary>
        /// Код фонда
        /// </summary>
        [Key]
        public int Id_fond { get; set; }
        /// <summary>
        /// Наименование фонда
        /// </summary>
        public string Fond_name { get; set; }
        /// <summary>
        /// Библиотека в которой находится фонд
        /// </summary>
        public int Library { get; set; }
        /// <summary>
        /// Кол-во книг в фонде
        /// </summary>
        public int Book_count { get; set; }
        /// <summary>
        /// Кол-во журналов в фонде
        /// </summary>
        public int Journal_count { get; set; }
        /// <summary>
        /// Кол-во газетв фонде
        /// </summary>
        public int Newspaper_count { get; set; }
        /// <summary>
        /// Кол-во сборников в фонде
        /// </summary>
        public int Collection_count { get; set; }
        /// <summary>
        /// Кол-во диссертаций в фонде
        /// </summary>
        public int Dissertation_count { get; set; }
        /// <summary>
        /// Кол-во рефератов в фонде
        /// </summary>
        public int Report_count { get; set; }
    }
}