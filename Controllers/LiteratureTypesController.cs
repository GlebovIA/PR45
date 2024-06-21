using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/LiteratureTypesController")]
    public class LiteratureTypesController : Controller
    {
        /// <summary>
        /// Список типов литературы
        /// </summary>
        /// <returns>Возвращает список типов литературы из базы данных</returns>
        /// <response code="200">Успешное выполнение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(Literature_types), 200)]
        [ProducesResponseType(500)]
        public ActionResult List() => Json(new LiteratureTypesContext().Literature_types);
        /// <summary>
        /// Тип литературы по коду
        /// </summary>
        /// <param name="id">Код выбранного типа литературы</param>
        /// <returns>Возвращает выбранный тип литературы из базы данных</returns>
        /// <response code="200">Успешное выполнение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Literature_types), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(int id) => Json(new LiteratureTypesContext().Literature_types.Where(x => x.Id_type == id));
    }
}
