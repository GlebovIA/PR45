using Microsoft.AspNetCore.Mvc;
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
                Users User = new UsersContext().Users.Where(x => x.Login == Login && x.Password == Password).First();
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
                Users User = new Users { Login = Login, Password = Password };
                new UsersContext().Users.Add(User);
                return Json(User);
            }
            catch (Exception ex) { return StatusCode(500); }
        }
    }
}
