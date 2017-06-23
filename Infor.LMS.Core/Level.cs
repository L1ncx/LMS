using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infor.LMS.Core
{
    public class Level
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int? ParentId { get; set; } 
        public string LevelIMSId { get; set; }
    }
}
