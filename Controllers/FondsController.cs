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
        /// <summary>
        /// Сортированный список фондов
        /// </summary>
        /// <param name="key">Параметр сортировки</param>
        /// <returns>Данный метод возвращает отсортированный список фондов из базы данных</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Sort")]
        [HttpGet]
        [ProducesResponseType(typeof(Fonds), 200)]
        [ProducesResponseType(500)]
        public ActionResult Sort(string key)
        {
            switch (key)
            {
                case "Id":
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Id_fond).ToList());
                case "Name":
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Fond_name).ToList());
                case "Book":
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Book_count).ToList());
                case "Journal":
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Journal_count).ToList());
                case "Newspapper":
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Newspaper_count).ToList());
                case "Collection":
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Collection_count).ToList());
                case "Dissertation":
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Dissertation_count).ToList());
                case "Report":
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Report_count).ToList());
                default:
                    return Json(new FondsContext().Fonds.OrderBy(x => x.Id_fond).ToList());
            }
        }
    }
}
