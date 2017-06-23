using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Infor.LMS.Web.Models
{
    public class AddLevelViewModel
    {
        public int LevelId { get; set; }

        [Required]
        [DisplayName("Level Name")]
        public string LevelName { get; set; }

        [DisplayName("Parent")]
        public int? ParentId { get; set; }

        [DisplayName("IMS Id")]
        [StringLength(5)]
        public string LevelIMSId { get; set; }

        [DisplayName("Parent Level")]
        public List<SelectListItem> ParentLevels { get; set; }
    }
}