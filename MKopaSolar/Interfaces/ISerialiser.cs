namespace MKopaSolar.Interfaces
{
    public interface ISerializer
    {
        T Deserialize<T>(object model);
    }
}
