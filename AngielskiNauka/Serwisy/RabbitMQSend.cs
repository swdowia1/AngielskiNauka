namespace AngielskiNauka.Serwisy
{
    using RabbitMQ.Client;
    using System;
    using System.Text;

    public class RabbitMQSend
    {
        string uri = "amqps://ueocdobs:Y32aJSVQ-Qk9VTvrRzyiNfSyt0Lqq1uY@ostrich.lmq.cloudamqp.com/ueocdobs";
        private readonly string _queueName = "testQueue";

        public void SendMessage(string message)
        {
            // message += " Data:" + classFun.DateToString();
            // Create connection factory
            var factory = new ConnectionFactory
            {
                Uri = new Uri(uri)
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                durable: true, // Make sure this matches the existing queue
        exclusive: false,
        autoDelete: false,
        arguments: null);// Ensure this matches existing settings);



            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);

        }
    }

}
