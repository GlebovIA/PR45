using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System;
using System.Linq;

namespace PR45.Controllers
{
    [Route("api/LiteratureSourcesController")]
    [ApiExplorerSettings(GroupName = "v1")]
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
        ///<summary>
        ///Метод добавления носителя литературы
        ///</summary>
        ///<param name="sources">Данные о носителе литературы</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод добавляет носитель литературы в базу данных</remarks>
        ///<response code="200">Носитель литературы успешно добавлен</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Literature_sources sources, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    LiteratureSourcesContext literatureSourcesContext = new LiteratureSourcesContext();
                    literatureSourcesContext.Literature_sources.Add(sources);
                    literatureSourcesContext.SaveChanges();
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
        ///Метод изменения носителя литературы
        ///</summary>
        ///<param name="source">Данные о носителе литературы</param>
        ///<param name="id">Код изменяемого носителя литературы</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет носитель литературы в базе данных</remarks>
        ///<response code="200">Носитель литературы успешно изменен</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Edit([FromForm] int id, [FromForm] Literature_sources source, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    LiteratureSourcesContext literaturesourcesContext = new LiteratureSourcesContext();
                    Literature_sources sources = literaturesourcesContext.Literature_sources.Where(x => x.Id_source == id).First();
                    sources.Source_name = source.Source_name;
                    literaturesourcesContext.SaveChanges();
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
        ///Метод удаления носителя литературы
        ///</summary>
        ///<param name="id">Код удаляемого носителя литературы</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод удаляет носитель литературы из базы данных</remarks>
        ///<response code="204">Носитель литературы успешно удален</response>
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
                LiteratureSourcesContext literatureSourcesContext = new LiteratureSourcesContext();
                if (literatureSourcesContext.Literature_sources.Where(x => x.Id_source == id).First() != null)
                {
                    literatureSourcesContext.Remove(literatureSourcesContext.Literature_sources.Where(x => x.Id_source == id).First());
                }
                else return StatusCode(500);
                literatureSourcesContext.SaveChanges();
                return StatusCode(204);
            }
            else return StatusCode(401);
        }
    }
}
