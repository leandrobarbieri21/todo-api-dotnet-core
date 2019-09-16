namespace Todo.Data.Interfaces
{
    public interface IMongoDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

        // Mongo Collections
        string TodoCollectionName { get; set; }
    }
}
