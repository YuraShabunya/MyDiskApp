namespace MyDiskServices.Interfaces
{
    public interface IHashPassword
    {
        public string GetHash(string password);
    }
}
