namespace SerializerJson.Interfaces
{
    public interface ISerializerJson<T> where T : class
    {
        void Serialize(T item, string jsonObjects);

        T Deserialize(string jsonObjects);
    }
}
