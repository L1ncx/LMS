namespace Infor.LMS.Data
{
    public class Level
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int? ParentId { get; set; } 
        public string LevelIMSId { get; set; }
    }
}
