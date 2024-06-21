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
        /// <summary>
        /// Сортированный список пополнений фондов
        /// </summary>
        /// <param name="key">Параметр сортировки</param>
        /// <returns>Данный метод возвращает отсортированный список пополнений фондов из базы данных</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Sort")]
        [HttpGet]
        [ProducesResponseType(typeof(Replenishments), 200)]
        [ProducesResponseType(500)]
        public ActionResult Sort(string key)
        {
            switch (key)
            {
                case "Id":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Id_replenishment).ToList());
                case "Fond":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Fond).ToList());
                case "Worker":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Worker).ToList());
                case "Date":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Date).ToList());
                case "Source":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Literature_source).ToList());
                case "Type":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Literature_type).ToList());
                case "PublishingCompany":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Publishing_company).ToList());
                case "PublishingDate":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Publishing_date).ToList());
                case "CopyCount":
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Copy_count).ToList());
                default:
                    return Json(new ReplenishmentsContext().Replenishments.OrderBy(x => x.Id_replenishment).ToList());
            }
        }
    }
}
