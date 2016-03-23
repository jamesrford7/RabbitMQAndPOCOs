using System;
using System.IO;
using System.Runtime.Serialization.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("jamestestyo", false, false, false, null);

                Console.WriteLine("Consumer!! - Enter to exit");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var type = Type.GetType(ea.BasicProperties.Type);
                    var stream = new MemoryStream(ea.Body);

                    if (type == null)
                    {
                        throw new Exception("Ya message is screwed up bro");
                    }

                    var serializer = new DataContractJsonSerializer(type);

                    var item = serializer.ReadObject(stream);

                    var itemProcessor = ItemProcessorFactory.Build(item);
                    itemProcessor.Process();

                    stream.Position = 0;
                };

                channel.BasicConsume("jamestestyo", true, consumer);

                Console.ReadLine();
            }
        }
    }
}
