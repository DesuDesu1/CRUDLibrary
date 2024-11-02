using Application.Authors.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUDLibrary.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        IMediator _mediator;
        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Возвращает всех авторов из системы
        /// </summary>
        /// <response code = "200">Возвращает всех авторов  из системы</response>
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllAuthorsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
