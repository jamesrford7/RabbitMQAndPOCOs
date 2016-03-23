using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

using Items;
using RabbitMQ.Client;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = new Item1() { Email = "test@hotmail.com", FirstName = "James" };
            var item2 = new Item2() { Password = "password", Address = "my house", Poo = "poopie" };

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("jamestestyo", false, false, false, null);

                Console.WriteLine("Producer!! - 1 for Item 1, 2 for Item 2");

                while (true)
                {
                    var input = Console.ReadLine();

                    var stream = new MemoryStream();
                    var streamReader = new StreamReader(stream);
                    DataContractJsonSerializer serializer;

                    var basicProperties = channel.CreateBasicProperties();

                    if (input == "1")
                    {
                        serializer = new DataContractJsonSerializer(typeof(Item1));
                        serializer.WriteObject(stream, item);
                        basicProperties.Type = typeof(Item1).AssemblyQualifiedName;
                    }

                    else
                    {
                        serializer = new DataContractJsonSerializer(typeof(Item2));
                        serializer.WriteObject(stream, item2);
                        basicProperties.Type = typeof(Item2).AssemblyQualifiedName;
                    }

                    stream.Position = 0;

                    var message = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());

                    channel.BasicPublish("", "jamestestyo", basicProperties, message);
                    Console.WriteLine("Sent message: {0}", Encoding.UTF8.GetString(message));
                }
            }
        }
    }
}
