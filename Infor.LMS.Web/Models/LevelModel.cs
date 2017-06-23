using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiskAssessment.Web.Models
{
    public class LevelModel
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int ParentId { get; set; }
        public string LevelIMSId { get; set; }
    }

    public class LevelViewModel
    {
        public List<LevelModel> Levels { get; set; }
        public AddLevelModel AddLevel { get; set; }

    }

    /// <summary>
    /// For JS Tree
    /// </summary>
    public class JsTreeModel
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public string state { get; set; }
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
        public string li_attr { get; set; }
        public string a_attr { get; set; }
    }
}