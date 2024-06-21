using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/WorkersController")]
    [ApiExplorerSettings(GroupName = "v1")]
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
        ///<summary>
        ///Метод добавления сотрудника
        ///</summary>
        ///<param name="workers">Данные о сотруднике</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод добавляет сотрудника в базу данных</remarks>
        ///<response code="200">Сотрудник успешно добавлен</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Workers workers, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    WorkersContext workersContext = new WorkersContext();
                    workersContext.Workers.Add(workers);
                    workersContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        ///<summary>
        ///Метод изменения сотрудника
        ///</summary>
        ///<param name="type">Данные о сотруднике</param>
        ///<param name="id">Код изменяемого сотрудника</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет сотрудника в базе данных</remarks>
        ///<response code="200">Сотрудник успешно изменен</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Edit([FromForm] int id, [FromForm] Workers worker, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    WorkersContext workersContext = new WorkersContext();
                    Workers workers = workersContext.Workers.Where(x => x.Id_worker == id).First();
                    workers.Worker_surname = worker.Worker_surname;
                    workers.Worker_name = worker.Worker_name;
                    workers.Worker_patronymic = worker.Worker_patronymic;
                    workers.Job = worker.Job;
                    workers.Library = worker.Library;
                    workers.Birth_date = worker.Birth_date;
                    workers.Admission_date = worker.Admission_date;
                    workers.Education = worker.Education;
                    workers.Salary = worker.Salary;
                    workersContext.SaveChanges();
                    return StatusCode(200);
                }
                else return StatusCode(401);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        ///<summary>
        ///Метод удаления сотрудника
        ///</summary>
        ///<param name="id">Код удаляемого сотрудника</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод удаляет сотрудника из базы данных</remarks>
        ///<response code="204">Сотрудник успешно удален</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Delete")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v4")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Delete(int id, string token)
        {
            if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
            {
                WorkersContext workersContext = new WorkersContext();
                if (workersContext.Workers.Where(x => x.Id_worker == id).First() != null)
                {
                    workersContext.Remove(workersContext.Workers.Where(x => x.Id_worker == id).First());
                }
                else return StatusCode(500);
                workersContext.SaveChanges();
                return StatusCode(204);
            }
            else return StatusCode(401);
        }
    }
}
