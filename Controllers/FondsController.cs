using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/FondsController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class FondsController : Controller
    {
        /// <summary>
        /// Список фондов
        /// </summary>
        /// <returns>Возвращает список фондов из базы данных</returns>
        /// <response code="200">Успешное выполение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(Fonds), 200)]
        [ProducesResponseType(500)]
        public ActionResult List() => Json(new FondsContext().Fonds);
        /// <summary>
        /// Фонд по коду
        /// </summary>
        /// <param name="id">Код выбранного фонда</param>
        /// <returns>Возвращает выбранный фонд из базы данных</returns>
        /// <response code="200">Успешное выполение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Fonds), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id) => Json(new FondsContext().Fonds.Where(x => x.Id_fond == id).First());
    }
}
