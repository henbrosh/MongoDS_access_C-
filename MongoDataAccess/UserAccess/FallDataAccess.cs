
using MongoDataAccess.Models;
using MongoDB.Driver;
namespace MongoDataAccess.UserAccess;

public class FallDataAccess
{
    private const string ConnectionString = "mongodb+srv://hen:1234@cluster0.736dm.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
    private const string DatabaseName = "choredb";
    private const string FallCollecion = "Falls";
    private const string GPUCollection = "GPU";
    private const string FallHistoryCollection = "Fall_history";
    private const string JSCollection = "Monitoring_from_JS";


    private IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);
    }

    public async Task<List<TestModel>> GetAllJS()
    {
        var gpusCollection = ConnectToMongo<TestModel>(JSCollection);
        var results = await gpusCollection.FindAsync(_ => true);
        return results.ToList();

    }
    public async Task<List<GPUModel>> GetAllGPU()
    {
        var gpusCollection = ConnectToMongo<GPUModel>(GPUCollection);
        var results = await gpusCollection.FindAsync(_ => true);
        return results.ToList();

    }
    private async Task<List<FallModel>> GetAllChores()
    {
        var choresCollection = ConnectToMongo<FallModel>(FallCollecion);
        var results = await choresCollection.FindAsync(_ => true);
        return results.ToList();  
    }

    private async Task<List<FallModel>> GetAllChoresFotAUser(GPUModel user)
    {
     var choresCollection = ConnectToMongo<FallModel>(FallCollecion);
       var results = await choresCollection.FindAsync(c =>c.AssignedTo.Id == user.Id );
       return results.ToList();
    }

    public Task CreateUser(GPUModel user)
    {
        var usersCollection = ConnectToMongo<GPUModel>(GPUCollection);
        return usersCollection.InsertOneAsync(user);
    }
    public Task CreateChore(FallModel chore)
    {
        var choresCollection = ConnectToMongo<FallModel>(FallCollecion);
        return choresCollection.InsertOneAsync(chore);

    }
    public async Task UpdateChore(FallModel chore)
    {
        var choresCollection = ConnectToMongo<FallModel>(FallCollecion);
        var filter = Builders<FallModel>.Filter.Eq(field:"Id", chore.Id);
        var update = Builders<FallModel>.Update.Set(a => a.FallReason, "2");

        var result = await choresCollection.UpdateOneAsync(filter,update);

    }
    public Task UpdateGPU(GPUModel GPU)
    {
        var gpuCollection = ConnectToMongo<GPUModel>(GPUCollection);
        var filter = Builders<GPUModel>.Filter.Eq(field: "Id", GPU.Id);
        return gpuCollection.ReplaceOneAsync(filter, GPU, options: new ReplaceOptions { IsUpsert = true });
    }
    public Task DeleteChore(FallModel chore)
    {
        var choresCollection = ConnectToMongo<FallModel>(FallCollecion);

        return choresCollection.DeleteOneAsync(c => c.Id == chore.Id);
    }

}
