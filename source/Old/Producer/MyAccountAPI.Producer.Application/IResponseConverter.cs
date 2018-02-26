namespace MyAccountAPI.Producer.Application
{
    public interface IResponseConverter
    {
        T Map<T>(object source);
    }
}
