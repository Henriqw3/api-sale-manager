using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// Controller for managing sales operations.
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;
[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
