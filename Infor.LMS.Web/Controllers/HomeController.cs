using System;
using Microsoft.VisualBasic.FileIO;
using RiskAssessment.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Infor.LMS.Core;
using RiskAssessment.Web.Managers;

namespace RiskAssessment.Web.Models
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var levelManager = new LevelManager();

            var levels = levelManager.GetAllLevels().Select(l => new LevelModel()
            {
                LevelId = l.LevelId,
                LevelName = l.LevelName
            }).ToList();

            var addNewLevel = new AddLevelModel()
            {
                ParentLevels = levels.Select(l => new SelectListItem() { Text = l.LevelName, Value = l.LevelId.ToString() }).ToList()
            };
            return View(new LevelViewModel() { Levels =  levels, AddLevel = addNewLevel });
        }

        public ActionResult GetLevels()
        {
            var levelManager = new LevelManager();

            var levels = levelManager.GetAllLevels()
                .Select(s => new JsTreeModel()
                {
                    id = s.LevelId.ToString(),
                    parent = s.ParentId == null ? "#" : s.ParentId.GetValueOrDefault().ToString(),
                    text = s.LevelName,
                });
         
            return Json(levels, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLevel(AddLevelModel levelViewModel)
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