using System.Collections.Generic;
using Infor.LMS.Data;

namespace Infor.LMS.Core
{
    public interface ILevelService
    {
        void AddLevel(Level level);
        List<Level> GetAllLevels();
    }
}