using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Thunders.API.Controllers.TaskLists.V1.Create;
using Test.Thunders.API.Presenters;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.TaskLists.V1.Commands.Create;

namespace Test.Thunders.API.Controllers.TaskLists.V1;

public partial class TaskListController
{
    /// <summary>
    /// Create TaskList
    /// </summary>
    /// <returns></returns>
    /// <response code="201">TaskList created</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateTaskListResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateTaskListV1Async([FromBody] CreateTaskListRequest request)
    {
        CreateTaskListCommand command = request;
        var result = await _mediator.Send(command);
        var response = BasePresenter.Cast(result, HttpStatusCode.Created);

        return response;
    }
}
