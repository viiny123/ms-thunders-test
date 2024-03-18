using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Thunders.API.Presenters;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.Person.V1.Queries.GetById;

namespace Test.Thunders.API.Controllers.TaskLists.V1;

public partial class TaskListController
{
    /// <summary>
    /// Get Person
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Value</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetTaskListByIdQueryResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPersonByIdV1Async([FromRoute] Guid id)
    {
        var queryRequest = new GetTaskListByIdQuery(id);
        var result = await _mediator.Send(queryRequest);
        var response = BasePresenter.Cast(result, HttpStatusCode.OK);

        return response;
    }
}
