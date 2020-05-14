namespace examen.Models{
        public class AerolineaDataSettings : IAerolineaDataSettings
    {
        public string AerolineaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IAerolineaDataSettings{
        string AerolineaCollectionName{get;set;}
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
