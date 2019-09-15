using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
namespace CTM.Repos
{
    class AlunosDAO
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
                using (var conn = new SQLiteConnection("Data Source =" + Application.StartupPath + "\\dataBase.db"))
                {
                    conn.Open();
                    string sql = "create table IF NOT EXISTS dataTable (SitFinanc string, Matrícula int, Nome string, Email string, Telefone string, Obs string)";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                db_connect = new SQLiteConnection("Data Source = " + Application.StartupPath + "\\dataBase.db");
                db_connect.Open();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao conectar com o banco de dados", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw (e);
            }
        }
        public bool insertAlunoDB(Models.Aluno objAluno)
        {
            try
            {
                if(connection()==true)
                {
                    
                    using (var comm = new SQLiteCommand(db_connect))
                    {
                        comm.CommandText = string.Format("Insert into dataTable(Sitfinanc,Matrícula,Nome,Email,Telefone,Obs) Values(" +
                            "\"{0}\"," +
                            "\"{1}\"," +
                            "\"{2}\"," +
                            "\"{3}\"," +
                            "\"{4}\"," +
                            "\"{5}\")",objAluno.sitFinanc,
                                      objAluno.matricula,
                                      objAluno.nome,
                                      objAluno.email,
                                      objAluno.telefone,
                                      objAluno.obs);
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
                db_connect.Close();
                throw e;
            }
        }
        public bool updateAlunoDB(Models.Aluno objAluno)
        {
            try
            {
                if (connection() == true)
                {
                    using (var comm = new SQLiteCommand(db_connect))
                    {
                        comm.CommandText = ("UPDATE dataTable SET ");
                        comm.CommandText += ("SitFinanc = \"" + objAluno.sitFinanc + "\",");
                        comm.CommandText += ("Matrícula = " + objAluno.matricula + ",");
                        comm.CommandText += ("Nome = \"" + objAluno.nome + "\",");
                        comm.CommandText += ("Email = \"" + objAluno.email + "\",");
                        comm.CommandText += ("Telefone = \"" + objAluno.telefone + "\",");
                        comm.CommandText += ("obs = \"" + objAluno.obs + "\"");
                        comm.CommandText += (" WHERE Matrícula = " + objAluno.matricula);
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
                db_connect.Close();
                throw (e);
            }
        }
        public bool removeAlunoDB(Models.Aluno objAluno)
        {
            try
            {
                if (connection() == true)
                {
                    using (var comm = new SQLiteCommand(db_connect))
                    {
                        comm.CommandText = ("DELETE FROM dataTable where Matrícula = " + objAluno.matricula);
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
                db_connect.Close();
                throw (e);
            }
        }
        public List<Models.Aluno> dataList()
        {
            try
            {
                try
                {
                    if (connection() == true)
                    {
                        List<Models.Aluno> mainList = new List<Models.Aluno>();
                        using (var comm = new SQLiteCommand("SELECT * FROM dataTable", db_connect))
                        {
                            SQLiteDataReader reader = comm.ExecuteReader();
                            while (reader.Read())
                            {
                                Models.Aluno tmpAluno = new Models.Aluno();
                                tmpAluno.sitFinanc = reader[0].ToString();
                                tmpAluno.matricula = int.Parse(reader[1].ToString());
                                tmpAluno.nome = reader[2].ToString();
                                tmpAluno.email = reader[3].ToString();
                                tmpAluno.telefone = reader[4].ToString();
                                mainList.Add(tmpAluno);
                            }
                            return mainList;
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
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
