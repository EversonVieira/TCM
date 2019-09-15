using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTM.Manutenção
{
    class AlunosCACHE
    {
        public List<Models.Aluno> ListObjectAlunos = new List<Models.Aluno>();
        public bool addObject(Models.Aluno objAluno)
        {

            try
            {
                ListObjectAlunos.Add(objAluno);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateObject(Models.Aluno objAluno)
        {
            try
            {
                foreach(Models.Aluno aluno in ListObjectAlunos)
                {
                    if(aluno.matricula == objAluno.matricula)
                    {
                        aluno.sitFinanc = objAluno.sitFinanc;
                        aluno.nome = objAluno.nome;
                        aluno.email = objAluno.email;
                        aluno.telefone = objAluno.telefone;
                        aluno.obs = objAluno.obs;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public bool removeObject(Models.Aluno objAluno)
        {
            try
            {
                foreach(Models.Aluno aluno in ListObjectAlunos)
                {
                    if(aluno.matricula == objAluno.matricula)
                    {
                        ListObjectAlunos.Remove(aluno);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
