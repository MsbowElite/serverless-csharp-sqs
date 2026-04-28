// src/ProducerLambda/Function.cs
using Amazon.Lambda.Core;
using Amazon.SQS;
using Amazon.SQS.Model;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ProducerLambda;

public class Function
{
    private readonly AmazonSQSClient _sqs = new();

    public async Task<string> FunctionHandler(object input, ILambdaContext context)
    {
        var queueUrl = Environment.GetEnvironmentVariable("QUEUE_URL");

        await _sqs.SendMessageAsync(new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageBody = $"message created at {DateTime.UtcNow:O}"
        });

        return "sent";
    }
}