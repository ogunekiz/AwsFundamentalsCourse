using Amazon.S3;
using Amazon.S3.Model;
using System.Text;

var s3Client = new AmazonS3Client();

#region Upload
//using var inputStream = new FileStream("D:/Projects/NET Projects/Console/AwsFundamentalsCourse/4.S3/S3Playground/bmw.jpg", FileMode.Open, FileAccess.Read);

//var putObjectRequest = new PutObjectRequest
//{
//	BucketName = "oefilesystem",
//	Key = "images/car.jpg",
//	ContentType = "image/jpeg",
//	InputStream = inputStream
//};

//await s3Client.PutObjectAsync(putObjectRequest);
#endregion

#region Download
var getObjectRequest = new GetObjectRequest
{
	BucketName = "oefilesystem",
	Key = "images/car.jpg"
};

var response = await s3Client.GetObjectAsync(getObjectRequest);

using var memoryStream = new MemoryStream();
response.ResponseStream.CopyTo(memoryStream);

var text = Encoding.Default.GetString(memoryStream.ToArray());
Console.WriteLine(text);

#endregion