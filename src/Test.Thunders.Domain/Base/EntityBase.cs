using System;

namespace Test.Thunders.Domain.Base;

public abstract class EntityBase<TEntity> where TEntity : class
{
    /// <summary>
    /// Unique identifier of entity
    /// </summary>
    public virtual Guid Id { get; set; }
}