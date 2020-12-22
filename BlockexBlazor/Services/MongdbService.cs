using BlockexBlazor.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BlockexBlazor.Services
{
    public class MongodbService
    {
        private readonly IMongoCollection<SourceHeader> _docs;

        public MongodbService(IMongodbDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _docs = database.GetCollection<SourceHeader>(settings.CollectionName);
        }

        public List<SourceHeader> Get() =>
            _docs.Find(doc => true).ToList();

        public SourceHeader Get(string id) =>
            _docs.Find<SourceHeader>(doc => doc.Id == id).FirstOrDefault();

        public SourceHeader Create(SourceHeader sourceHeader)
        {
            _docs.InsertOne(sourceHeader);
            return sourceHeader;
        }

        public void Update(string id, SourceHeader sourceHeaderIn) =>
            _docs.ReplaceOne(doc => doc.Id == id, sourceHeaderIn);

        public void Remove(SourceHeader sourceHeaderIn) =>
            _docs.DeleteOne(doc => doc.Id == sourceHeaderIn.Id);

        public void Remove(string id) => 
            _docs.DeleteOne(doc => doc.Id == id);
    }
}