using Microsoft.AspNetCore.Mvc;
using PR45.Context;
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
        [ProducesResponseType(typeof(Model.Libraries), 200)]
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
        [ProducesResponseType(typeof(Model.Libraries), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id) => Json(new LibrariesContext().Libraries.Where(x => x.Id_library == id).First());
    }
}
