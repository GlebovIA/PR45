using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/WorkersController")]
    public class WorkersController : Controller
    {
        /// <summary>
        /// Список сотрудников
        /// </summary>
        /// <returns>Возвращает список сотрудников из базы данных</returns>
        /// <response code="200">Успешное выполнение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(Workers), 200)]
        [ProducesResponseType(500)]
        public ActionResult List() => Json(new WorkersContext().Workers);
        /// <summary>
        /// Сотрудник по коду
        /// </summary>
        /// <param name="id">Код выбранного сотрудника</param>
        /// <returns>Возвращает выбранного сотрудника из базы данных</returns>
        /// <response code="200">Успешное выполнение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Workers), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(int id) => Json(new WorkersContext().Workers.Where(x => x.Id_worker == id));
    }
}
