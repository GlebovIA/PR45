using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/ReplenishmentsController")]
    [ApiExplorerSettings(GroupName = "v1")]
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
        ///<summary>
        ///Метод добавления пополнения фонда
        ///</summary>
        ///<param name="replenishments">Данные о пополнении фонда</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод добавляет пополнение фонда в базу данных</remarks>
        ///<response code="200">Пополнение фонда успешно добавлено</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Replenishments replenishments, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    ReplenishmentsContext replenishmentsContext = new ReplenishmentsContext();
                    replenishmentsContext.Replenishments.Add(replenishments);
                    replenishmentsContext.SaveChanges();
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
        ///Метод изменения пополнения фонда
        ///</summary>
        ///<param name="replenishment">Данные о пополнении фонда</param>
        ///<param name="id">Код изменяемого пополнения фонда</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет пополнение фонда в базе данных</remarks>
        ///<response code="200">Пополнение фонда успешно изменено</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Edit([FromForm] int id, [FromForm] Replenishments replenishment, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    ReplenishmentsContext replenishmentsContext = new ReplenishmentsContext();
                    Replenishments replenishments = replenishmentsContext.Replenishments.Where(x => x.Id_replenishment == id).First();
                    replenishments.Fond = replenishment.Fond;
                    replenishments.Worker = replenishment.Worker;
                    replenishments.Date = replenishment.Date;
                    replenishments.Literature_source = replenishment.Literature_source;
                    replenishments.Literature_type = replenishment.Literature_type;
                    replenishments.Publishing_company = replenishment.Publishing_company;
                    replenishments.Publishing_date = replenishment.Publishing_date;
                    replenishments.Copy_count = replenishment.Copy_count;
                    replenishmentsContext.SaveChanges();
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
        ///Метод удаления пополнения фонда
        ///</summary>
        ///<param name="id">Код удаляемого пополнения фонда</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод удаляет пополнение фонда из базы данных</remarks>
        ///<response code="204">Пополнение фонда успешно удалено</response>
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
                ReplenishmentsContext replenishmentsContext = new ReplenishmentsContext();
                if (replenishmentsContext.Replenishments.Where(x => x.Id_replenishment == id).First() != null)
                {
                    replenishmentsContext.Remove(replenishmentsContext.Replenishments.Where(x => x.Id_replenishment == id).First());
                }
                else return StatusCode(500);
                replenishmentsContext.SaveChanges();
                return StatusCode(204);
            }
            else return StatusCode(401);
        }
    }
}
