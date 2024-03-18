using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Thunders.API.Controllers.TaskLists.V1;

[ApiVersion("1")]
public partial class TaskListController : BaseController
{
    private readonly IMediator _mediator;

    public TaskListController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
