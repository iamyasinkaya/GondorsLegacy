using System;
namespace GondorsLegacy.CrossCuttingCorners.MessageBrokers.Rabbit
{
    public interface IPublisher<T>
    {
        void Publish(T message);
    }
}

