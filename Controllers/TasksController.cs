using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/TasksController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TasksController : Controller
    {
        ///<summary>
        ///Получение списка задач
        ///</summary>
        ///<remarks>Данный метод получает список задач, находящийся в базе данных</remarks>
        ///<response code="200">Список успешно получен</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Tasks> Tasks = new TasksContext().Tasks;
                return Json(Tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        ///<summary>
        ///Получение задачи
        ///</summary>
        ///<remarks>Данный метод получает задачу, находящуюся в базе данных</remarks>
        ///<response code="200">Список успешно получен</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Tasks), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Tasks Tasks = new TasksContext().Tasks.Where(x => x.Id == id).First();
                return Json(Tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        ///<summary>
        ///Метод добавления задачи
        ///</summary>
        ///<param name="task">Данные о задаче</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод добавляет задачу в базу данных</remarks>
        ///<response code="200">Задача успешно добавлена</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Tasks task)
        {
            try
            {
                TasksContext tasksContext = new TasksContext();
                tasksContext.Tasks.Add(task);
                tasksContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        ///<summary>
        ///Метод изменения задачи
        ///</summary>
        ///<param name="task">Данные о задаче</param>
        ///<param name="id">Код изменяемой задачи</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет задачу в базе данных</remarks>
        ///<response code="200">Задача успешно изменена</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Edit(int id, [FromForm] Tasks task)
        {
            try
            {
                TasksContext tasksContext = new TasksContext();
                Tasks tasks = tasksContext.Tasks.Where(x => x.Id == id).First();
                tasks = task;
                tasksContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
