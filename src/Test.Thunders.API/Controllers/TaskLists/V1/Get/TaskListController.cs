using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Thunders.API.Extensions;
using Test.Thunders.API.Presenters;
using Test.Thunders.Application.Base.Error;
using Test.Thunders.Application.Person.V1.Queries.Get;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.API.Controllers.TaskLists.V1;

public partial class TaskListController
{
    /// <summary>
    /// Get taskList
    /// </summary>
    /// <param name="endDate"></param>
    /// <param name="pageNumber"> Number of page</param>
    /// <param name="pageSize"> Max 10</param>
    /// <param name="description"></param>
    /// <param name="status"></param>
    /// <param name="startDate"></param>
    /// <returns></returns>
    /// <response code="200">List of values</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetTaskListQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetTaskListV1Async(
        [FromQuery] string description,
        [FromQuery] Status? status,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate,
        [FromHeader(Name = "x-page-number")] int pageNumber = 1,
        [FromHeader(Name = "x-page-size")] int pageSize = 10)
    {
        var queryRequest = new GetTaskListQuery(description, status, startDate, endDate)
            .WithPaginated(pageSize, pageNumber);
        var result = await _mediator.Send(queryRequest);

        var dataPaginate = (Paginate<GetTaskListQueryResponse>)result.Data;

        Response.Headers.AddPaginationData(dataPaginate);

        var response = BasePresenter.Cast(dataPaginate.PageData, HttpStatusCode.OK);

        return response;
    }
}
