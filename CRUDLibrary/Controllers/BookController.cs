using Application.Authors.GetAll;
using Application.Book.Create;
using Application.Book.Delete;
using Application.Book.Get;
using Application.Book.Update;
using CRUDLibrary.Contracts.Requests;
using Domain.Author;
using Domain.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CRUDLibrary.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Возвращает cписок всех книг из системы
        /// </summary>
        /// <response code = "200">Возвращает cписок всех книг из системы</response>
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        /// <summary>
        /// Возвращает книгу из системы с совпадающим Id
        /// </summary>
        /// <response code = "200">Возвращает книгу</response>
        /// <response code = "404">Книга не была найдена</response>
        [HttpGet(ApiRoutes.BookRoutes.IdRoute)]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var query = new GetBookQuery(new Domain.Book.BookId(id));
            var response = await _mediator.Send(query);
            if (response is null) return NotFound();
            return Ok(response);
        }
        /// <summary>
        /// Создает новую книгу в системе
        /// </summary>
        /// <response code = "200">Создает новую книгу в системе</response>
        /// <response code = "400">Не может создать новую книгу из-за ошибки валидации</response>
        [HttpPost]
        public async Task<IActionResult> CreateNewBookAsync([FromBody] CreateUpdateBookRequest request)
        {
            Guid id = Guid.NewGuid();
            var command = new CreateBookCommand(
                id,
                request.Title,
                request.AuthorId,
                request.PublishedYear,
                request.Genre);
            await _mediator.Send(command);
            return Ok(id);
        }
        /// <summary>
        /// Обновляет информацию о книге в системе
        /// </summary>
        /// <response code = "200">Информация о книге успешно обновлена</response>
        /// <response code = "400">Невозможно обновить информацию из-за ошибки валидации</response>
        /// <response code = "404">Книга не была найдена</response>
        [HttpPut(ApiRoutes.BookRoutes.IdRoute)]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] CreateUpdateBookRequest request)
        {
            var command = new UpdateBookCommand(
                id,
                request.Title,
                request.AuthorId,
                request.PublishedYear,
                request.Genre);
            try
            {
                await _mediator.Send(command);
            }
            catch (BookNotFoundException e) 
            {
                return NotFound(e.Message);
            }
            return Ok(id);
        }
        /// <summary>
        /// Удаляет книгу из системы
        /// </summary>
        /// <response code = "200">Книга успешно удалена</response>
        /// <response code = "404">Книга не была найдена</response>
        [HttpDelete(ApiRoutes.BookRoutes.IdRoute)]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteBookCommand(id);
            try 
            {
                await _mediator.Send(command);
            }
            catch (BookNotFoundException e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }
    }
}
