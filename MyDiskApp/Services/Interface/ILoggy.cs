namespace MyDiskApp.Services.Interface
{
    public interface ILoggy
    {
        public Task AddLogAsync(string login, string message, DateTime dateTime);
    }
}
