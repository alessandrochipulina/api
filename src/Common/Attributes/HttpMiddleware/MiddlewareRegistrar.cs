using System;

namespace Common.Attributes.HttpMiddleware
{
    public abstract class MiddlewareRegistrar<T> : IMiddlwareRegistrar
    {
        public Type Type => typeof(T);
        public int Order { get; set; } = int.MaxValue;
        public MiddlewareScope Scope { get; set; } = MiddlewareScope.Scoped;
    }

    public interface IMiddlwareRegistrar : IMiddlewareInformation
    {
    }
}
