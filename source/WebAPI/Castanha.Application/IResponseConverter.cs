namespace Castanha.Application
{
    public interface IResponseConverter
    {
        T Map<T>(object source);
    }
}
