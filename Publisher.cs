using RabbitMQ.Client;
using System;

namespace RabbitMqBasic
{
    class Publisher 
    {
        IModel model;
        public Publisher(IModel _model)
        {
            model = _model;
            configure();
          
        }
        private void configure()
        {
            // Create Exchange
            model.ExchangeDeclare("demoExchange", ExchangeType.Direct);
            Console.WriteLine("Creating Exchange");

            //Create Queue
            model.QueueDeclare("demoqueue", true, false, false, null);
            Console.WriteLine("Creating Queue");

            // Bind Queue to Exchange
            model.QueueBind("demoqueue", "demoExchange", "directexchange_key");
            Console.WriteLine("Creating Binding");
        }
    }
}
