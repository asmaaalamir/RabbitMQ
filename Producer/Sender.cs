using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string message = "Getting started with .net core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("sent message", message);
            }
            Console.WriteLine("press enter to exist");
            Console.ReadLine();
        }
    }
}
