namespace Test.Thunders.Application.Base;

public abstract class CommandBase<TRequest> : SegregationBase<TRequest>
    where TRequest : SegregationBase<TRequest>
{
}