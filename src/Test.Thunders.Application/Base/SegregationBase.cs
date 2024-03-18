using MediatR;
using Test.Thunders.Domain.Base;

namespace Test.Thunders.Application.Base;

public abstract class SegregationBase<TRequest> : Paginate<Result>, IRequest<Result>
    where TRequest : SegregationBase<TRequest>
{
}