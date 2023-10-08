using Bussiness.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    public class EtkinlikController : Controller
    {
        private readonly IEtkinlikService _etkinlikService;
        private Microsoft.Extensions.Hosting.IHostingEnvironment _environment;

        public EtkinlikController(IEtkinlikService etkinlikService, Microsoft.Extensions.Hosting.IHostingEnvironment environment)
        {
            _etkinlikService = etkinlikService;
            _environment = environment;
        }


        
        public IActionResult DeleteAAdminEtkinlikList(int id)
        {
            bool isDelete = _etkinlikService.DeleteByResult(id);
            return RedirectToAction("EtkinlikList");
        }


        //[Authorize(Roles = "User")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public IActionResult EtkinlikList()
        {
            List<Etkinlik> etkinliks = _etkinlikService.GetAll();
            return View("EtkinlikList", etkinliks);
        }


        public IActionResult EditEtkinlik(int id)
        {
            Etkinlik etkinlik = _etkinlikService.GetById(id);
            return View(etkinlik);
        }
        [HttpPost]
        public IActionResult EditEtkinlik(int id, string baslik, string yer, DateTime zaman, bool ucretliUcretsiz, decimal ucret, string aciklama, IFormFile icon)
        {
            string fileName = "";
            if (icon != null && icon.Length != 0)
            {
                var extention = Path.GetExtension(icon.FileName).Trim('.').ToLower();
                if (!(new[] { "jpg", "png", "jpeg" }).Contains(extention))
                {
                    return RedirectToAction("AddEtkinlik", new { msg = ".jpg, .png yada jpeg olarak giriniz!" });
                }
                else
                {
                    string path = Path.Combine(_environment.ContentRootPath, "wwwroot\\Img");
                    if (!Directory.Exists(Path.Combine(path)))
                    {
                        Directory.CreateDirectory(Path.Combine(path));
                    }
                    fileName = Path.GetFileName(icon.FileName);
                    using (Stream fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        icon.CopyTo(fileStream);
                    }
                }
            }
            bool isUpdate = _etkinlikService.UpdateByResult(id, baslik, yer, zaman, ucretliUcretsiz, (ucretliUcretsiz ? ucret : 0), aciklama, fileName);
            return RedirectToAction("EtkinlikList");
        }

        public IActionResult DetailEtkinlik(int id)
        {
            Etkinlik etkinlik = _etkinlikService.GetById(id);
            return View(etkinlik);
        }

        public IActionResult AddEtkinlik(string? msg)
        {
            ErrorMsgModel errorMsg = new ErrorMsgModel { Msg = msg };
            return View(errorMsg);
        }

        [HttpPost]
        public IActionResult AddEtkinlik(string baslik, string yer, DateTime zaman, bool ucretliUcretsiz, decimal ucret, string aciklama, IFormFile icon)
        {
            if (string.IsNullOrWhiteSpace(baslik))
            {
                return RedirectToAction("AddEtkinlik", new { msg = "Etkinlik adı giriniz!" });
            }
            //if(icon == null || icon.Length == 0)
            //{
            //    return RedirectToAction("AddEtkinlik", new {msg = "dosya giriniz!" });
            //}

            string fileName = "";
            if (icon != null && icon.Length != 0)
            {
                var extention = Path.GetExtension(icon.FileName).Trim('.').ToLower();
                if (!(new[] { "jpg", "png", "jpeg" }).Contains(extention))
                {
                    return RedirectToAction("AddEtkinlik", new { msg = ".jpg, .png yada jpeg olarak giriniz!" });
                }
                else
                {
                    string path = Path.Combine(_environment.ContentRootPath, "wwwroot\\Img");
                    if (!Directory.Exists(Path.Combine(path)))
                    {
                        Directory.CreateDirectory(Path.Combine(path));
                    }
                    fileName = Path.GetFileName(icon.FileName);
                    using (Stream fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        icon.CopyTo(fileStream);
                    }
                }
            }
            bool isCreated = _etkinlikService.CreateByResult(baslik, yer, zaman, ucretliUcretsiz, (ucretliUcretsiz? ucret : 0 ), aciklama, fileName);
            return RedirectToAction("EtkinlikList");
        }

    }
}
