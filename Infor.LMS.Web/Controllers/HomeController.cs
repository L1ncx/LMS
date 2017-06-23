using System;
using System.Linq;
using System.Web.Mvc;
using Infor.LMS.Core;
using RiskAssessment.Web.Models;

namespace RiskAssessment.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var levelManager = new LevelManager();

            var levels = levelManager.GetAllLevels()
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
            var levelManager = new LevelManager();

            var levels = levelManager.GetAllLevels()
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

                    var levelManager = new LevelManager();


                    levelManager.AddLevel(level);
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