using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Thunders.API.Presenters;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.TaskLists.V1.Commands.Delete;

namespace Test.Thunders.API.Controllers.TaskLists.V1;

public partial class TaskListController
{
    /// <summary>
    /// Delete TaskList
    /// </summary>
    /// <param name="id">Unique identifier of Value</param>
    /// <returns></returns>
    /// <response code="204">TaskList deleted</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteTaskListV1Async([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new DeleteTaskListCommand
        {
            Id = id
        });

        var response = BasePresenter.Cast(result, HttpStatusCode.NoContent);

        return response;
    }
}
