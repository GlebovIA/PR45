using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/LiteratureSourcesController")]
    public class LiteratureSourcesController : Controller
    {
        /// <summary>
        /// Список носителей литературы
        /// </summary>
        /// <returns>Возвращает список носителей литературы из базы данных</returns>
        /// <response code="200">Успешное выполнение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(Literature_sources), 200)]
        [ProducesResponseType(500)]
        public ActionResult List() => Json(new LiteratureSourcesContext().Literature_sources);
        /// <summary>
        /// Тип литературы по коду
        /// </summary>
        /// <param name="id">Код выбранного типа литературы</param>
        /// <returns>Возвращает выбранный тип литературы из базы данных</returns>
        /// <response code="200">Успешное выполнение запроса</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Literature_sources), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(int id) => Json(new LiteratureSourcesContext().Literature_sources.Where(x => x.Id_source == id));
        /// <summary>
        /// Сортированный список носителей литературы
        /// </summary>
        /// <param name="key">Параметр сортировки</param>
        /// <returns>Данный метод возвращает отсортированный список носителей литературы из базы данных</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Sort")]
        [HttpGet]
        [ProducesResponseType(typeof(Literature_sources), 200)]
        [ProducesResponseType(500)]
        public ActionResult Sort(string key)
        {
            switch (key)
            {
                case "Id":
                    return Json(new LiteratureSourcesContext().Literature_sources.OrderBy(x => x.Id_source).ToList());
                case "Name":
                    return Json(new LiteratureSourcesContext().Literature_sources.OrderBy(x => x.Source_name).ToList());
                default:
                    return Json(new LiteratureSourcesContext().Literature_sources.OrderBy(x => x.Id_source).ToList());
            }
        }
    }
}
