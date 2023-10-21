using System.Text;
using GondorsLegacy.CrossCuttingCorners.MessageBrokers.Rabbit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GondorsLegacy.Infrastructure.MessagesBrokers.Rabbit;

public class RabbitMQService<T> : IPublisher<T>, IConsumer<T>
{
    private readonly string _hostName;
    private readonly string _queueName;

    public RabbitMQService(string hostName, string queueName)
    {
        _hostName = hostName;
        _queueName = queueName;
    }

    public void Publish(T message)
    {
        var factory = new ConnectionFactory() { HostName = _hostName };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            byte[] messageBytes = GetMessageBytes(message).ToArray();
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 mandatory: false,
                                 basicProperties: properties,
                                 body: messageBytes);

            Console.WriteLine($"Sent: {message}");
        }
    }

    public void Consume(Action<T> messageHandler)
    {
        var factory = new ConnectionFactory() { HostName = _hostName };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                ReadOnlyMemory<byte> messageBytes = ea.Body.ToArray();
                T message = GetMessageFromBytes(messageBytes);
                messageHandler(message);
            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("Waiting for messages. Press [Enter] to exit.");
            Console.ReadLine();
        }
    }

    private ReadOnlyMemory<byte> GetMessageBytes(T message)
    {
        string jsonMessage = Newtonsoft.Json.JsonConvert.SerializeObject(message);
        return Encoding.UTF8.GetBytes(jsonMessage).AsMemory();
    }

    private T GetMessageFromBytes(ReadOnlyMemory<byte> messageBytes)
    {
        string jsonMessage = Encoding.UTF8.GetString(messageBytes.ToArray());
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonMessage);
    }
}