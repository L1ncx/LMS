using System;
using System.Linq;
using System.Web.Mvc;
using Infor.LMS.Core;
using Infor.LMS.Data;
using Infor.LMS.Web.Models;

namespace Infor.LMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILevelService _levelService;

        public HomeController(ILevelService levelService)
        {
            _levelService = levelService;
        }
        public ActionResult Index()
        {

            var levels = _levelService.GetAllLevels()
                .Select(l => new SelectListItem
                    {Text = l.LevelName, Value = l.LevelId.ToString()})
                .ToList();

            var addNewLevel = new AddLevelViewModel()
            {
                ParentLevels = levels
            };

            return View(new LevelViewModel() {  AddLevel = addNewLevel });
        }

        public ActionResult GetLevels()
        {

            var levels = _levelService.GetAllLevels()
                .Select(s => new LevelTreeModel()
                {
                    id = s.LevelId.ToString(),
                    parent = s.ParentId == null ? "#" : s.ParentId.GetValueOrDefault().ToString(),
                    text = s.LevelName,
                });
         
            return Json(levels, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLevel(AddLevelViewModel levelViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Level level = new Level()
                    {
                        ParentId = levelViewModel.ParentId,
                        LevelId = levelViewModel.LevelId,
                        LevelName = levelViewModel.LevelName,
                        LevelIMSId = levelViewModel.LevelIMSId
                    };



                    _levelService.AddLevel(level);
                }

                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw;
            }
        }


    }
}