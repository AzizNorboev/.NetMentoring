using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");

var client = new MongoClient("mongodb+srv://AzizMongoDb:AzizMongoDb123@cluster0.gnw0v.mongodb.net/?retryWrites=true&w=majority");

var db = client.GetDatabase("sample_mflix");
var collection = db.GetCollection<BsonDocument>("movies");

var result = collection.Find("{title: 'The Princess Bride'}")
    .FirstOrDefault();

Console.WriteLine(result);
