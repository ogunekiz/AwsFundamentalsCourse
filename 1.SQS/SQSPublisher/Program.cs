using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;

string accessKey = "";
string secretKey = "";
var region = Amazon.RegionEndpoint.EUWest3; //Paris

var sqslClient = new AmazonSQSClient(region);

var customer = new
{
	FirstName = "John",
	LastName = "Doe",
	Age = 30
};

var queueUrlResponse = await sqslClient.GetQueueUrlAsync("customers");

var sendMessageRequest = new SendMessageRequest
{
	QueueUrl = queueUrlResponse.QueueUrl,
	MessageBody = JsonSerializer.Serialize(customer),
	MessageAttributes = new Dictionary<string, MessageAttributeValue>
	{
		{
			"MessageType", new MessageAttributeValue
			{
				DataType = "String",
				StringValue = "Customer"
			}
		}
	}
};

var response = await sqslClient.SendMessageAsync(sendMessageRequest);

Console.ReadLine();