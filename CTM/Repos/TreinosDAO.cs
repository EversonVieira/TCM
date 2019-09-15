using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace CTM.Repos
{
    class TreinosDAO
    {
        private SQLiteConnection db_connect;
        public bool connection()
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\dataBase.db"))
                {
                    SQLiteConnection.CreateFile(Application.StartupPath + "\\dataBase.db");
                }
                using (var conn = new SQLiteConnection("Data source = " + Application.StartupPath + "\\dataBase.db"))
                {
                    conn.Open();
                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "CREATE TABLE IF NOT EXISTS dataTreino(ID int,TREINO string)";
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                db_connect = new SQLiteConnection("Data source = " + Application.StartupPath + "\\dataBase.db");
                db_connect.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
        public bool insertTreino(Models.Treino treino)
        {
            try
            {
                if (connection() == true)
                {
                    using (var comm = new SQLiteCommand(db_connect))
                    {
                        comm.CommandText = "INSERT INTO dataTreino(ID,TREINO) Values(\"" + treino.matricula + "\",\'" + JsonSerializer(treino) + "\')"; ;
                        comm.ExecuteNonQuery();
                        db_connect.Close();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public bool updateTreino(Models.Treino treino)
        {
            try
            {
                if (connection() == true)
                {
                    using (var comm = new SQLiteCommand(db_connect))
                    {
                        comm.CommandText = string.Format("UPDATE dataTreino set TREINO = \"{0}\" WHERE ID = {1}", JsonSerializer(treino), treino.matricula);
                        comm.ExecuteNonQuery();
                        db_connect.Close();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool removeTreino(Models.Treino treino)
        {
            try
            {
                if (connection() == true)
                {
                    using (var comm = new SQLiteCommand(db_connect))
                    {
                        comm.CommandText = string.Format("DELETE FROM dataTREINO WHERE ID = {0}", treino.matricula);
                    }
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Models.Treino> GetTreinos()
        {
            try
            {
                if (connection() == true)
                {
                    List<Models.Treino> ListObjectTreinos = new List<Models.Treino>();
                    using (var comm = new SQLiteCommand("SELECT * FROM dataTreino", db_connect))
                    {
                        SQLiteDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            Models.Treino treinoAUX = new Models.Treino();
                            treinoAUX = JsonDeserializer(reader[1].ToString());
                            ListObjectTreinos.Add(treinoAUX);
                        }
                        return ListObjectTreinos;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string JsonSerializer(Models.Treino objTreino)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(objTreino);
                return json;
            }
            catch
            {
                throw;
            }
        }
        public Models.Treino JsonDeserializer(string json)
        {
            try
            {
                var serializer = new JavaScriptSerializer();

                Models.Treino treino = new Models.Treino();

                treino = serializer.Deserialize<Models.Treino>(json);

                return treino;
            }
            catch
            {
                throw;
            }
        }
    }
}
