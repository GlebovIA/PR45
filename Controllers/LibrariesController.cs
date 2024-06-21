using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/LibrariesController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class LibrariesController : Controller
    {
        /// <summary>
        /// Список библиотек
        /// </summary>
        /// <returns>Данный метод возвращает список библиотек из базы данных</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(Libraries), 200)]
        [ProducesResponseType(500)]
        public ActionResult List() => Json(new LibrariesContext().Libraries);
        /// <summary>
        /// Библиотека по коду
        /// </summary>
        /// <param name="id">Код выбранной библиотеки</param>
        /// <returns>Данный метод возвращает библиотеку с указанным кодом из базы данных</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Libraries), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id) => Json(new LibrariesContext().Libraries.Where(x => x.Id_library == id).First());
        /// <summary>
        /// Сортированный список библиотек
        /// </summary>
        /// <param name="key">Параметр сортировки</param>
        /// <returns>Данный метод возвращает отсортированный список библиотек из базы данных</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Sort")]
        [HttpGet]
        [ProducesResponseType(typeof(Libraries), 200)]
        [ProducesResponseType(500)]
        public ActionResult Sort(string key)
        {
            switch (key)
            {
                case "Id":
                    return Json(new LibrariesContext().Libraries.OrderBy(x => x.Id_library).ToList());
                case "Name":
                    return Json(new LibrariesContext().Libraries.OrderBy(x => x.Library_name).ToList());
                case "City":
                    return Json(new LibrariesContext().Libraries.OrderBy(x => x.City).ToList());
                case "Address":
                    return Json(new LibrariesContext().Libraries.OrderBy(x => x.Address).ToList());
                default:
                    return Json(new LibrariesContext().Libraries.OrderBy(x => x.Id_library).ToList());
            }
        }
        ///<summary>
        ///Метод добавления библиотеки
        ///</summary>
        ///<param name="library">Данные о задаче</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод добавляет библиотеку в базу данных</remarks>
        ///<response code="200">Библиотека успешно добавлена</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Libraries library, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    LibrariesContext librariesContext = new LibrariesContext();
                    librariesContext.Libraries.Add(library);
                    librariesContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        ///<summary>
        ///Метод изменения библиотеки
        ///</summary>
        ///<param name="library">Данные о библиотеке</param>
        ///<param name="id">Код изменяемой библиотеки</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет библиотеку в базе данных</remarks>
        ///<response code="200">Библиотека успешно изменена</response>        
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Edit([FromForm] int id, [FromForm] Libraries library, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    LibrariesContext librariesContext = new LibrariesContext();
                    Libraries libraries = librariesContext.Libraries.Where(x => x.Id_library == id).First();
                    libraries.Library_name = library.Library_name;
                    libraries.Address = library.Address;
                    libraries.City = library.City;
                    librariesContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        ///<summary>
        ///Метод удаления библиотеки
        ///</summary>
        ///<param name="id">Код удаляемой библиотеки</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод удаляет библиотеку из базы данных</remarks>
        ///<response code="204">Библиотеку успешно удалена</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Delete")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v4")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Delete(int id, string token)
        {
            if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
            {
                LibrariesContext librariesContext = new LibrariesContext();
                if (librariesContext.Libraries.Where(x => x.Id_library == id).First() != null)
                {
                    librariesContext.Remove(librariesContext.Libraries.Where(x => x.Id_library == id).First());
                }
                else return StatusCode(500);
                librariesContext.SaveChanges();
                return StatusCode(204);
            }
            else return StatusCode(401);
        }
    }
}