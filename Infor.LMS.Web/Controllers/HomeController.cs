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

            var levels = levelManager.GetAllLevels().Select(s => new LevelModel()
            {
                LevelId = s.LevelId,
                ParentId = s.ParentId.GetValueOrDefault(),
                LevelIMSId = s.LevelIMSId,
                LevelName = s.LevelName
            }).ToList();

            LevelViewModel lvm = new LevelViewModel();
            lvm.Levels = levels;
            lvm.AddLevel = new AddLevelModel();

            return View(lvm);
        }

        public ActionResult Nodes()
        {
            var nodes = new List<JsTreeModel>();
            nodes.Add(new JsTreeModel() {id = "101", parent = "#", text = "Simple root node"});
            nodes.Add(new JsTreeModel() {id = "102", parent = "#", text = "Root node 1"});
            nodes.Add(new JsTreeModel() {id = "103", parent = "102", text = "Child 1"});
            nodes.Add(new JsTreeModel() {id = "104", parent = "102", text = "Child 2"});
            return Json(nodes, JsonRequestBehavior.AllowGet);
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