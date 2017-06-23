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
}