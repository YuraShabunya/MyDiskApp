namespace MyDiskEF.Models
{
    public class UserFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int UserId { get; set; }
        public string ContentType { get; set; }
    }
}
