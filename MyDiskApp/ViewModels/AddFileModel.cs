using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyDiskApp.ViewModels
{
    public class AddFileModel
    {
        [Required(ErrorMessage = "Добавьте файл!")]
        public IFormFile File { get; set; }
    }
}
