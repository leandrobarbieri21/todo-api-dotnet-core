using Todo.Data.Interfaces;

namespace Todo.Data.Common
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        // Mongo Collections
        public string TodoCollectionName { get; set; }
    }
}
