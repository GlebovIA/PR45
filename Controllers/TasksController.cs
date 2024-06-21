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
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод добавляет задачу в базу данных</remarks>
        ///<response code="200">Задача успешно добавлена</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Tasks task, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    TasksContext tasksContext = new TasksContext();
                    tasksContext.Tasks.Add(task);
                    tasksContext.SaveChanges();
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
        ///Метод изменения задачи
        ///</summary>
        ///<param name="task">Данные о задаче</param>
        ///<param name="id">Код изменяемой задачи</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет задачу в базе данных</remarks>
        ///<response code="200">Задача успешно изменена</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Edit(int id, [FromForm] Tasks task, [FromForm] string token)
        {
            //try
            //{
            if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
            {
                TasksContext tasksContext = new TasksContext();
                Tasks tasks = tasksContext.Tasks.Where(x => x.Id == id).FirstOrDefault();
                tasks.Name = task.Name;
                tasks.Comment = task.Comment;
                tasks.Priority = task.Priority;
                tasks.DateExecute = task.DateExecute;
                tasks.Done = task.Done;
                tasksContext.SaveChanges();
                return StatusCode(200);
            }
            else return StatusCode(401);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500);
            //}
        }
        ///<summary>
        ///Метод удаления задачи
        ///</summary>
        ///<param name="id">Код удаляемой задачи</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод удаляет задачу из базы данных</remarks>
        ///<response code="204">Задача успешно удалена</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Delete")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v4")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public ActionResult Delete(int id, string token)
        {
            if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
            {
                TasksContext tasksContext = new TasksContext();
                if (tasksContext.Tasks.Where(x => x.Id == id).First() != null)
                {
                    tasksContext.Remove(tasksContext.Tasks.Where(x => x.Id == id).First());
                }
                else return StatusCode(500);
                tasksContext.SaveChanges();
                return StatusCode(204);
            }
            else return StatusCode(401);
        }
        ///<summary>
        ///Метод удаления всех задач
        ///</summary>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод удаляет все задачи из базы данных</remarks>
        ///<response code="204">Задачи успешно удалены</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("DeleteAll")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v4")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public ActionResult Delete(string token)
        {
            if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
            {
                TasksContext tasksContext = new TasksContext();
                tasksContext.Tasks.RemoveRange(tasksContext.Tasks);
                tasksContext.SaveChanges();
                return StatusCode(204);
            }
            else return StatusCode(401);
        }
    }
}
