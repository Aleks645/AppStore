using System;

namespace AppStore.DL.Configurations;

public class MongoDbConfiguration
{
        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string CollectionName {get; set; } = string.Empty;

}
