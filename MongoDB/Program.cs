using MongoDataAccess.UserAccess;
using MongoDataAccess.Models;

FallDataAccess db = new FallDataAccess();
GPUModel gpu = new GPUModel() { BestCoreClock = "101010", BestWatt = "1321321" };
await db.CreateUser(gpu);


var Fall = new FallModel()
{
    AssignedTo = gpu,
    FallReason = "90"
};


List<TestModel> t =  await db.GetAllJS();

    Console.WriteLine( t[0].mhs);

