using System;
namespace GondorsLegacy.CrossCuttingCorners.MessageBrokers.Rabbit
{
    public interface IConsumer<T>
    {
        void Consume(Action<T> messageHandler);
    }
}

