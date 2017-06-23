using System.Collections.Generic;
using System.Web.Mvc;

namespace RiskAssessment.Web.Models
{
    public class AddLevelModel:LevelModel
    {
        public List<SelectListItem> ParentLevels { get; set; }
    }
}