using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infor.LMS.Data
{
    public class LevelRepository: ILevelRepository
    {
        private readonly string _connStr;

        public LevelRepository()
        {
            _connStr = @"Data Source=(localdb)\v13.0;Initial Catalog=LMSData;Integrated Security=True";

        }
        public List<Level> GetAll()
        {
            var levels = new List<Level>();
            // runs stored proc and returns data to main page
            using (var con = new SqlConnection())
            {
                string sql = @"SELECT * FROM Levels";
                con.ConnectionString = _connStr;

                var dt = new DataTable();
                var da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, con);

                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    var level = new Level();
                    level.LevelId = Convert.ToInt32(row["LevelId"].ToString());
                    level.LevelName = row["LevelName"].ToString();
                    var dataParentLevelId = row["ParentLevelId"];

                    if (dataParentLevelId != DBNull.Value)
                        level.ParentId = Convert.ToInt32(dataParentLevelId.ToString());

                    level.LevelIMSId = row["LevelImsId"].ToString();
                    levels.Add(level);
                }
            }
            return levels;
        }

        public void Add(Level level)
        {
            using (var connection = new SqlConnection(_connStr))
            {
                connection.Open();
                var sql = "INSERT INTO Levels(LevelName,ParentLevelId,LevelIMSId) VALUES(@param2,@param3,@param4)";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = level.LevelName;

                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = level.ParentId ?? (object)DBNull.Value;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 5).Value = level.LevelIMSId;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
    }

    public interface ILevelRepository
    {
        List<Level> GetAll();
        void Add(Level level);
    }
}
