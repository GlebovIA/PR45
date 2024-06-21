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
        /// <summary>
        /// Сортированный список сотрудников
        /// </summary>
        /// <param name="key">Параметр сортировки</param>
        /// <returns>Данный метод возвращает отсортированный список сотрудников из базы данных</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Sort")]
        [HttpGet]
        [ProducesResponseType(typeof(Workers), 200)]
        [ProducesResponseType(500)]
        public ActionResult Sort(string key)
        {
            switch (key)
            {
                case "Id":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Id_worker).ToList());
                case "Surname":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Worker_surname).ToList());
                case "Name":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Worker_name).ToList());
                case "Patronymic":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Worker_patronymic).ToList());
                case "Library":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Library).ToList());
                case "Job":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Job).ToList());
                case "Birth_date":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Birth_date).ToList());
                case "Admission_date":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Admission_date).ToList());
                case "Education":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Education).ToList());
                case "Salary":
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Salary).ToList());
                default:
                    return Json(new WorkersContext().Workers.OrderBy(x => x.Id_worker).ToList());
            }
        }
    }
}
