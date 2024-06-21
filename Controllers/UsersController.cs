using Microsoft.AspNetCore.Mvc;
using PR45.Classes;
using PR45.Context;
using PR45.Model;
using System;
using System.Linq;

namespace PR45.Controllers
{

    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class UsersController : Controller
    {
        ///<summary>
        ///Авторизация пользователя
        ///</summary>
        ///<param name="Login">Логин пользователя</param>
        ///<param name="Password">Пароль пользователя</param>
        ///<returns>Данный метод предназначен для авторизации пользователя на сайте</returns>
        ///<response code="200">Пользователь успешно авторизован</response>
        ///<response code="403">Ошибка запроса, данные не указаны</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("SignIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult SignIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null) return StatusCode(403);
            try
            {
                UsersContext usersContext = new UsersContext();
                Users User = usersContext.Users.Where(x => x.Login == Login && x.Password == Hasher.GetHash(Password)).First();
                Random random = new Random();
                User.token = random.Next(int.MinValue, int.MaxValue);
                Users.Token = User.token;
                usersContext.SaveChanges();
                return Json(User);
            }
            catch (Exception ex) { return StatusCode(500); }
        }
        ///<summary>
        ///Регистрация пользователя
        ///</summary>
        ///<param name="Login">Логин пользователя</param>
        ///<param name="Password">Пароль пользователя</param>
        ///<returns>Данный метод предназначен для регистрации пользователя на сайте</returns>
        ///<response code="200">Пользователь успешно зарегистрирован</response>
        ///<response code="403">Ошибка запроса, данные не указаны</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("RegIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult RegIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null) return StatusCode(403);
            try
            {
                UsersContext usersContext = new UsersContext();
                string password = Hasher.GetHash(Password);
                Users User = new Users { Login = Login, Password = password };
                usersContext.Users.Add(User);
                usersContext.SaveChanges();
                return Json(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
