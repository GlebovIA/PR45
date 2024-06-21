namespace PR45.Model
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Код
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Токен пользователя
        /// </summary>
        public int? token { get; set; }
        /// <summary>
        /// Полученый от базы данных токен
        /// </summary>
        public static int? Token { get; set; }
    }
}
