using System;
using System.ComponentModel.DataAnnotations;

namespace PR45.Model
{
    /// <summary>
    /// Сотрудники библиотек
    /// </summary>
    public class Workers
    {
        /// <summary>
        /// Код сотрудника
        /// </summary>
        [Key]
        public int Id_worker { get; set; }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Worker_surname { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Worker_name { get; set; }
        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string Worker_patronymic { get; set; }
        /// <summary>
        /// Библиотека 
        /// </summary>
        public int Library { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birth_date { get; set; }
        /// <summary>
        /// Дата поступления на работу
        /// </summary>
        public DateTime Admission_date { get; set; }
        /// <summary>
        /// Образование
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// Зарплата
        /// </summary>
        public decimal Salary { get; set; }
    }
}
