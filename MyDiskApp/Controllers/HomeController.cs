using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyDiskApp.Services.Interface;
using MyDiskApp.ViewModels;

namespace MyDiskApp.Controllers 
{
    public class HomeController : Controller
    {
        private readonly IGetAllFiles _getAllFiles;
        private readonly IAddFile _addFile;
        private readonly IGetUser _getUser;
        private readonly IDeleteFile _deleteFile;
        private readonly ILoggy _loggy;

        public HomeController(IGetAllFiles getAllFiles, IGetUser getUser, IAddFile addFileAsync, IDeleteFile deleteFileAsync, ILoggy loggy)
        {
            _getAllFiles = getAllFiles;
            _getUser = getUser;
            _addFile = addFileAsync;
            _deleteFile = deleteFileAsync;
            _loggy = loggy;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var user = _getUser.GetUser(User.Identity.Name);
            if (user != null)
            {
                return View(_getAllFiles.GetAllFiles(user.Id));
            }
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddFile()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        [RequestSizeLimit(737280000)]
        public async Task<IActionResult> AddFile(AddFileModel fileModel)
        {
            if (ModelState.IsValid)
            {
                var user = _getUser.GetUser(User.Identity.Name);
                await _loggy.AddLogAsync(user.Login, "AddFile", DateTime.Now);
                await _addFile.AddFileAsync(user, fileModel.File);
                return RedirectToAction("Index");
            }

            return View(fileModel);
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeleteFile()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteFile(DeleteFileModel deleteFile)
        {
            if (ModelState.IsValid)
            {
                var user = _getUser.GetUser(User.Identity.Name);
                await _loggy.AddLogAsync(user.Login, "DeleteFile", DateTime.Now);
                await _deleteFile.DeleteFileAsync(user, deleteFile.Name);
                return RedirectToAction("Index");
            }
            return View(deleteFile);
        }
    }
}
