using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");

var client = new MongoClient("mongodb+srv://AzizMongoDb:AzizMongoDb123@cluster0.gnw0v.mongodb.net/?retryWrites=true&w=majority");

var db = client.GetDatabase("sample_mflix");
var collection = db.GetCollection<BsonDocument>("movies");

var result = collection.Find(new BsonDocument())
               .SortByDescending(m => m["runtime"])
               .Limit(10)
               .ToList();

foreach (var r in result)
{
    Console.WriteLine(r.GetValue("title"));
}
