using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAccess.Models;

public class GPUModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Watt { get; set; }
    public string BestWatt { get; set; }
    public string CoreClock { get; set; }

    public string BestCoreClock { get; set; }
    public string MemoryClock { get; set; }
    public string BestMemoryClock { get; set; }



}
