using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
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
    }
}