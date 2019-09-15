using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace CTM.Controllers
{
    class AlunosController
    {
        public Manutenção.AlunosCACHE alunosCACHE = new Manutenção.AlunosCACHE();
        public Repos.AlunosDAO alunosDAO = new Repos.AlunosDAO();
        public AlunosController()
        {
            alunosCACHE.ListObjectAlunos = alunosDAO.dataList();
        }
        public void updateList()
        {
            alunosCACHE.ListObjectAlunos = alunosDAO.dataList();
        }
        public bool insertAluno(Models.Aluno aluno)
        {
            try
            {
                if(alunosCACHE.addObject(aluno) == true && alunosDAO.insertAlunoDB(aluno) == true)
                {
                    MessageBox.Show("Sucesso ao inserir novo Aluno!","Insert",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    string errorCode = "";
                    if(!alunosCACHE.addObject(aluno))
                    {
                        errorCode += "ADD#AC&";
                    }
                    if(!alunosDAO.insertAlunoDB(aluno))
                    {
                        errorCode += "&IDB#AC";
                    }
                    MessageBox.Show("Erro inesperado->EC: " + errorCode, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public bool updateAluno(Models.Aluno aluno)
        {
            try
            {
                if (alunosCACHE.updateObject(aluno) == true && alunosDAO.updateAlunoDB(aluno) == true)
                {
                    MessageBox.Show("Sucesso ao atualizar o aluno!","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    string errorCode = "";
                    if(!alunosCACHE.updateObject(aluno))
                    {
                        errorCode += "UP#AC&";
                    }
                    if(!alunosDAO.updateAlunoDB(aluno))
                    {
                        errorCode += "&UPDB#AC";
                    }
                    MessageBox.Show("Erro inesperado->EC: " + errorCode, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool RemoveAluno(Models.Aluno aluno)
        {
            try
            {
                if (alunosCACHE.removeObject(aluno) == true && alunosDAO.removeAlunoDB(aluno) == true)
                {
                    MessageBox.Show("Sucesso ao remover o aluno!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    string errorCode = "";
                    if (!alunosCACHE.updateObject(aluno))
                    {
                        errorCode += "RMV#AC&";
                    }
                    if (!alunosDAO.updateAlunoDB(aluno))
                    {
                        errorCode += "&RMVDB#AC";
                    }
                    MessageBox.Show("Erro inesperado->EC: " + errorCode, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable tabelaAlunos()
        {
            try
            {
                DataTable auxTable = new DataTable();
                DataColumn column;
                DataRow row;

                column = new DataColumn();
                column.ColumnName = "SITUAÇÃO FINANCEIRA";
                column.DataType = Type.GetType("System.String");
                column.AutoIncrement = false;
                column.ReadOnly = true;
                column.Caption = "SITUAÇÃO FINANCEIRA";
                auxTable.Columns.Add(column);


                column = new DataColumn();
                column.ColumnName = "MATRÍCULA";
                column.DataType = Type.GetType("System.Int32");
                column.AutoIncrement = false;
                column.ReadOnly = true;
                column.Caption = "MATRÍCULA";
                column.Unique = true;
                auxTable.Columns.Add(column);


                column = new DataColumn();
                column.ColumnName = "NOME";
                column.DataType = Type.GetType("System.String");
                column.AutoIncrement = false;
                column.ReadOnly = true;
                column.Caption = "NOME";
                auxTable.Columns.Add(column);


                column = new DataColumn();
                column.ColumnName = "E-MAIL";
                column.DataType = Type.GetType("System.String");
                column.AutoIncrement = false;
                column.ReadOnly = true;
                column.Caption = "E-MAIL";
                auxTable.Columns.Add(column);


                column = new DataColumn();
                column.ColumnName = "TELEFONE";
                column.DataType = Type.GetType("System.String");
                column.AutoIncrement = false;
                column.ReadOnly = true;
                column.Caption = "TELEFONE";
                auxTable.Columns.Add(column);

                foreach (Models.Aluno aluno in alunosCACHE.ListObjectAlunos)
                {
                    row = auxTable.NewRow();
                    row[0] = aluno.sitFinanc;
                    row[1] = aluno.matricula;
                    row[2] = aluno.nome;
                    row[3] = aluno.email;
                    row[4] = aluno.telefone;
                    auxTable.Rows.Add(row);
                }
                return auxTable;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public Models.Aluno alunoData(int matricula)
        {
            try
            {
                foreach (Models.Aluno objAluno in alunosCACHE.ListObjectAlunos)
                {
                    if (matricula == objAluno.matricula)
                    {
                        return objAluno;
                    }
                }
                Models.Aluno auxAluno = new Models.Aluno();
                return auxAluno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
