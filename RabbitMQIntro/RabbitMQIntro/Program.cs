using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting rabbitmq queue creator");
            Console.WriteLine();
            Console.WriteLine();

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory() // create new conenction factory
            {
                Password = "guest", // default settings
                UserName = "guest",
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel(); // create a model to declare queues and exchanges

            model.QueueDeclare("MyQueue", true, false, false, null); // declare queue
            Console.WriteLine("Queue created");

            model.ExchangeDeclare("MyExchange", ExchangeType.Topic); // declare exchange
            Console.WriteLine("Exchange created");

            model.QueueBind("MyQueue", "MyExchange", "cars"); // bind queue and exchange together
            Console.WriteLine("Exchane and queue bound");

            Console.ReadLine();

        }
    }
}
