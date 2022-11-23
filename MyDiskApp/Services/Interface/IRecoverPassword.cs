using MyDiskApp.ViewModels;
using MyDiskEF.Models;

namespace MyDiskApp.Services.Interface
{
    public interface IRecoverPassword
    {
        public bool ChangePassword(RecoverModel recover);
    }
}
