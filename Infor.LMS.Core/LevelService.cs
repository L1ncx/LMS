using System.Collections.Generic;
using Infor.LMS.Data;

namespace Infor.LMS.Core
{
    public class LevelService:ILevelService
    {
        private readonly ILevelRepository _levelRepostory;

        public LevelService(ILevelRepository levelRepostory)
        {
            _levelRepostory = levelRepostory;
        }
        public List<Level> GetAllLevels()
        {
            return _levelRepostory.GetAll();
        }

        
        public void AddLevel(Level level)
        {
            _levelRepostory.Add(level);
        }
    }
}
