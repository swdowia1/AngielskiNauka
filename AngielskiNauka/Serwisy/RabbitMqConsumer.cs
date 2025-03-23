using AngielskiNauka;
using Microsoft.Data.SqlClient;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class RabbitMqBackgroundConsumer : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;

    private readonly string _queueName = "testQueue";
    private readonly string uri = "amqps://ueocdobs:Y32aJSVQ-Qk9VTvrRzyiNfSyt0Lqq1uY@ostrich.lmq.cloudamqp.com/ueocdobs";

    public RabbitMqBackgroundConsumer()
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri(uri),
            DispatchConsumersAsync = true // Obsługa asynchroniczna
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: _queueName,
                              durable: true,  // Wiadomości będą trwałe
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {

            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"[x] Otrzymano: {message}");


            //zapis do bazy

            string insertQuery = @"INSERT INTO [dbo].[Danes]
           ([Ang]
           ,[Pol]
           ,[Data]
           ,[PoziomId]
           ,[Stan])
     VALUES
           ('" + message + "','',GetDate(),27 ,0)";

            try
            {
                using (SqlConnection conn = new SqlConnection(classFun.Poloczenie()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Add parameters to prevent SQL injection


                        int rowsAffected = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        };

        _channel.BasicConsume(queue: _queueName,
                              autoAck: true,
                              consumer: consumer);

        // Zatrzymanie usługi dopiero po wywołaniu `stoppingToken`
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}
