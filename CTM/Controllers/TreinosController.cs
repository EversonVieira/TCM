using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace CTM.Controllers
{
    class TreinosController
    {

        Manutenção.TreinosCACHE treinosCACHE = new Manutenção.TreinosCACHE();
        Repos.TreinosDAO treinosDAO = new Repos.TreinosDAO();
        public TreinosController()
        {
            treinosCACHE.ListObjectTreinos = treinosDAO.GetTreinos();
        }
        public bool insertTreino(Models.Treino objTreino)
        {
            try
            {
                if (treinosCACHE.insertTreino(objTreino) && treinosDAO.insertTreino(objTreino))
                {
                    MessageBox.Show("Sucesso ao adicionar o treino", "INSERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    string errorCode = "";
                    if (!treinosCACHE.insertTreino(objTreino))
                    {
                        errorCode += "ADD#TC&";
                    }
                    if (!treinosDAO.insertTreino(objTreino))
                    {
                        errorCode += "&IDB#TC";
                    }
                    MessageBox.Show("Erro inesperado->EC: " + errorCode, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool updateTreino(Models.Treino objTreino)
        {
            try
            {
                if (treinosCACHE.updateTreino(objTreino) && treinosDAO.updateTreino(objTreino))
                {
                    MessageBox.Show("Sucesso ao atualizar o treino", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    string errorCode = "";
                    if (!treinosCACHE.updateTreino(objTreino))
                    {
                        errorCode += "UP#TC&";
                    }
                    if (!treinosDAO.updateTreino(objTreino))
                    {
                        errorCode += "&UPDB#TC";
                    }
                    MessageBox.Show("Erro inesperado->EC: " + errorCode, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool removeTreino(Models.Treino objTreino)
        {
            try
            {
                if (treinosCACHE.removeTreino(objTreino) && treinosDAO.removeTreino(objTreino))
                {
                    MessageBox.Show("Sucesso ao remover o treino", "INSERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    string errorCode = "";
                    if (!treinosCACHE.removeTreino(objTreino))
                    {
                        errorCode += "RMV#TC&";
                    }
                    if (!treinosDAO.removeTreino(objTreino))
                    {
                        errorCode += "&RMVDB#TC";
                    }
                    MessageBox.Show("Erro inesperado->EC: " + errorCode, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool getTreino(DataGridView x,int matricula)
        {
            try
            {
                foreach (Models.Treino objTreino in treinosCACHE.ListObjectTreinos)
                {
                    if (objTreino.matricula == matricula)
                    {
                        x.DataSource = objTreino.columns;
                        for (int i = 0; i < 8; i++)
                        {
                            if (i % 2 == 0)
                            {
                                x.Columns[i].HeaderText = string.Format("Treino" + (char)(i + 97)).ToUpper();
                            }
                            else
                            {
                                x.Columns[i].HeaderText = string.Format("SRCD " + (char)(i + 96)).ToUpper();
                            }
                        }
                        for (int i = 0; i < x.Columns.Count; i++)
                        {
                            if (x.Rows[0].Cells[i].Value == null)
                            {
                                x.Columns[i].Visible = false;
                            }
                        }
                        x.AllowUserToAddRows = true;
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

    }
}
