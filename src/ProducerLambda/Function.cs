using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.SQS;
using Amazon.SQS.Model;

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace ProducerLambda;

public class Function
{
    private readonly IAmazonSQS _sqs;

    public Function()
    {
        _sqs = new AmazonSQSClient();
    }

    public async Task<string> FunctionHandler()
    {
        var queueUrl = Environment.GetEnvironmentVariable("QUEUE_URL");

        var message = new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageBody = $"Message generated at {DateTime.UtcNow}"
        };

        await _sqs.SendMessageAsync(message);

        return "Message sent successfully";
    }
}