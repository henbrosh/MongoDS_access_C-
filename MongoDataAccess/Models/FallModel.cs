
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDataAccess.Models;

public class FallModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public string FallReason { get; set; }
    public GPUModel? AssignedTo { get; set; }
    public DateTime? LastCompleted { get; set; }

}
