using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

var nessage = new
{
	Name = "John Doe",
	Age = 30
};

var snsClient = new AmazonSimpleNotificationServiceClient();

var topicArnResponse = await snsClient.FindTopicAsync("customers");

var publishRequest = new PublishRequest
{
	TopicArn = topicArnResponse.TopicArn,
	Message = System.Text.Json.JsonSerializer.Serialize(nessage),
	MessageAttributes = new Dictionary<string, MessageAttributeValue>
	{
		{
			"MessageType", new MessageAttributeValue
			{
				DataType = "String",
				StringValue = "User"
			}
		}
	}
};

var resonse = await snsClient.PublishAsync(publishRequest);