using System.ComponentModel.DataAnnotations;

namespace MyDiskApp.ViewModels
{
    public class DeleteFileModel
    {
        [Required(ErrorMessage = "Не указано имя файла")]
        public string Name { get; set; }
    }
}
