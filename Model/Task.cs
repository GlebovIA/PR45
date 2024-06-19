using System;

namespace PR45.Model
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Код
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public string Priority { get; set; }
        /// <summary>
        /// Дата выполнения
        /// </summary>
        public DateTime DateExecute { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Состояние готовности
        /// </summary>
        public bool Done { get; set; }
    }
}
