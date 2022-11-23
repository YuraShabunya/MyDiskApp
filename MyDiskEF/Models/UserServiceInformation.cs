namespace MyDiskEF.Models
{
    public class UserServiceInformation
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string SecretWord { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
