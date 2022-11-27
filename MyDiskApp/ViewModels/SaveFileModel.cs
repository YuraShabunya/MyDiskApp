using System.ComponentModel.DataAnnotations;

namespace MyDiskApp.ViewModels
{
    public class SaveFileModel
    {
        [Required(ErrorMessage = "Не указано имя файла")]
        public string Name { get; set; }
    }
}
