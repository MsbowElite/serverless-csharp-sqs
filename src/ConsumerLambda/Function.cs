// src/ConsumerLambda/Function.cs
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ConsumerLambda;

public class Function
{
    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        foreach (var record in evnt.Records)
        {
            context.Logger.LogInformation($"Received: {record.Body}");
        }

        await Task.CompletedTask;
    }
}