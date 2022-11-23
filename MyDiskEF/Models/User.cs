namespace MyDiskEF.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string CurrentDirectory { get; set; }
        public List<UserFile> Files { get; set; }
        public int UserExtraInformationId { get; set; }
        public UserExtraInformation userExtraInformation { get; set; }
        public int UserServiceInformationId { get; set; }
        public UserServiceInformation userServiceInformation { get; set; }

    }
}
