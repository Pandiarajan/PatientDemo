namespace PatientDemographics.Repository
{
    public interface ISerializer
    {
        string Serialize<T>(T dataToSerialize);
        T Deserialize<T>(string xmlText);
    }
}
