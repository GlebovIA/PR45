using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/LiteratureTypesController")]
    [ApiExplorerSettings(GroupName = "v1")]
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
        /// <summary>
        /// Сортированный список типов литературы
        /// </summary>
        /// <param name="key">Параметр сортировки</param>
        /// <returns>Данный метод возвращает отсортированный список типов литературы из базы данных</returns>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <response code="500">Ошибка выполнения запроса</response>
        [Route("Sort")]
        [HttpGet]
        [ProducesResponseType(typeof(Literature_types), 200)]
        [ProducesResponseType(500)]
        public ActionResult Sort(string key)
        {
            switch (key)
            {
                case "Id":
                    return Json(new LiteratureTypesContext().Literature_types.OrderBy(x => x.Id_type).ToList());
                case "Name":
                    return Json(new LiteratureTypesContext().Literature_types.OrderBy(x => x.Type_name).ToList());
                default:
                    return Json(new LiteratureTypesContext().Literature_types.OrderBy(x => x.Id_type).ToList());
            }
        }
        ///<summary>
        ///Метод добавления типа литературы
        ///</summary>
        ///<param name="types">Данные о типе литературы</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод добавляет тип литературы в базу данных</remarks>
        ///<response code="200">Тип литературы успешно добавлен</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Literature_types types, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    LiteratureTypesContext literatureTypesContext = new LiteratureTypesContext();
                    literatureTypesContext.Literature_types.Add(types);
                    literatureTypesContext.SaveChanges();
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
        ///Метод изменения типа литературы
        ///</summary>
        ///<param name="type">Данные о типе литературы</param>
        ///<param name="id">Код изменяемого типа литературы</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет тип литературы в базе данных</remarks>
        ///<response code="200">Тип литературы успешно изменен</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Edit([FromForm] int id, [FromForm] Literature_types type, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    LiteratureTypesContext literatureTypesContext = new LiteratureTypesContext();
                    Literature_types types = literatureTypesContext.Literature_types.Where(x => x.Id_type == id).First();
                    types.Type_name = type.Type_name;
                    literatureTypesContext.SaveChanges();
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
        ///Метод удаления типа литературы
        ///</summary>
        ///<param name="id">Код удаляемого типа литературы</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод удаляет тип литературы из базы данных</remarks>
        ///<response code="204">Тип литературы успешно удален</response>
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
                LiteratureTypesContext literatureTypesContext = new LiteratureTypesContext();
                if (literatureTypesContext.Literature_types.Where(x => x.Id_type == id).First() != null)
                {
                    literatureTypesContext.Remove(literatureTypesContext.Literature_types.Where(x => x.Id_type == id).First());
                }
                else return StatusCode(500);
                literatureTypesContext.SaveChanges();
                return StatusCode(204);
            }
            else return StatusCode(401);
        }
    }
}
