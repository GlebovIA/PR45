using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/ReplenishmentsController")]
    public class ReplenishmentsController : Controller
    {
        /// <summary>
        /// Список пополнений фондов
        /// </summary>
        /// <returns>Возвращает список пополнений фондов из базы данных</returns>
        /// <response code="200">Успешное выполнение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(Replenishments), 200)]
        [ProducesResponseType(500)]
        public ActionResult List() => Json(new ReplenishmentsContext().Replenishments);
        /// <summary>
        /// Пополнение фонда по коду
        /// </summary>
        /// <param name="id">Код выбранного пополнения фонда</param>
        /// <returns>Возвращает выбранное пополнение фонда из базы данных</returns>
        /// <response code="200">Успешное выполнение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Replenishments), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(int id) => Json(new ReplenishmentsContext().Replenishments.Where(x => x.Id_replenishment == id));
    }
}
