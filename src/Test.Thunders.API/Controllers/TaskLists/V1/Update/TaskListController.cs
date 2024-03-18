using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Thunders.API.Controllers.TaskLists.V1.Update;
using Test.Thunders.API.Presenters;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.Person.V1.Commands.Update;

namespace Test.Thunders.API.Controllers.TaskLists.V1;

public partial class TaskListController
{
    /// <summary>
    /// Update person
    /// </summary>
    /// <param name="id">Unique identifier of Person</param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <response code="204">Person update</response>
    /// <response code="400">Bad Request</response>
    /// <response code="422">Business rules violated</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdatePersonV1Async([FromRoute] Guid id,
        [FromBody] UpdateTaskListRequest request)
    {
        var command = (UpdateTaskListCommand)request;
        command.Id = id;

        var result = await _mediator.Send(command);
        var response = BasePresenter.Cast(result, HttpStatusCode.NoContent);

        return response;
    }
}
