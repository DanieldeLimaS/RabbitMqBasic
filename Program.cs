using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace RabbitMqBasic
{
    class Program
    {
        public static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory() { HostName = "localhost" };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            // Create Exchange
            model.ExchangeDeclare("demoExchange", ExchangeType.Direct);
            Console.WriteLine("Creating Exchange");

            //Create Queue
            model.QueueDeclare("demoqueue", true, false, false, null);
            Console.WriteLine("Creating Queue");

            // Bind Queue to Exchange
            model.QueueBind("demoqueue", "demoExchange", "directexchange_key");
            Console.WriteLine("Creating Binding");
            var properties = model.CreateBasicProperties();

            properties.Persistent = false;
            long numero = 134;
            while (true)
            {
                // Console.WriteLine("Digite a mensagem:");
                var message = $"Mensagem publicada numero {numero}";
                byte[] messagebuffer = Encoding.Default.GetBytes(message);

                model.BasicPublish("demoExchange", "directexchange_key", properties, messagebuffer);
                Console.WriteLine(message);
                Thread.Sleep(5000);
                numero++;
            }
        }

    }

}
