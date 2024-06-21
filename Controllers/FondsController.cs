using Microsoft.AspNetCore.Mvc;
using PR45.Context;
using PR45.Model;
using System;
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
        ///<summary>
        ///Метод добавления фонда
        ///</summary>
        ///<param name="fonds">Данные о фонде</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод добавляет фонд в базу данных</remarks>
        ///<response code="200">Фонд успешно добавлен</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Fonds fonds, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    FondsContext fondsContext = new FondsContext();
                    fondsContext.Fonds.Add(fonds);
                    fondsContext.SaveChanges();
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
        ///Метод изменения фонда
        ///</summary>
        ///<param name="fond">Данные о фонде</param>
        ///<param name="id">Код изменяемой фонда</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет фонд в базе данных</remarks>
        ///<response code="200">Фонд успешно изменен</response>
        ///<response code="401">Пользователь не авторизован</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Edit([FromForm] int id, [FromForm] Fonds fond, [FromForm] string token)
        {
            try
            {
                if (new UsersContext().Users.Where(x => x.token.ToString() == token).First() != null)
                {
                    FondsContext fondsContext = new FondsContext();
                    Fonds fonds = fondsContext.Fonds.Where(x => x.Id_fond == id).First();
                    fonds.Fond_name = fond.Fond_name;
                    fonds.Library = fond.Library;
                    fonds.Book_count = fond.Book_count;
                    fonds.Journal_count = fond.Journal_count;
                    fonds.Newspaper_count = fond.Newspaper_count;
                    fonds.Collection_count = fond.Collection_count;
                    fonds.Dissertation_count = fond.Dissertation_count;
                    fonds.Report_count = fond.Report_count;
                    fondsContext.SaveChanges();
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
        ///Метод удаления фонда
        ///</summary>
        ///<param name="id">Код удаляемого фонла</param>
        ///<param name="token">Токен пользователя</param>
        ///<returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод удаляет фонд из базы данных</remarks>
        ///<response code="204">Фонд успешно удален</response>        
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
                FondsContext fondsContext = new FondsContext();
                if (fondsContext.Fonds.Where(x => x.Id_fond == id).First() != null)
                {
                    fondsContext.Remove(fondsContext.Fonds.Where(x => x.Id_fond == id).First());
                }
                else return StatusCode(500);
                fondsContext.SaveChanges();
                return StatusCode(204);
            }
            else return StatusCode(401);
        }
    }
}
