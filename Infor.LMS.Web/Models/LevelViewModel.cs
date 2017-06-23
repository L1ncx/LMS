namespace Infor.LMS.Web.Models
{
   
    public class LevelViewModel
    {
        public AddLevelViewModel AddLevel { get; set; }

    }

    /// <summary>
    /// For JS Tree
    /// </summary>
    public class LevelTreeModel
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