using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CTM.Manutenção
{
    class TreinosCACHE
    {
        public List<Models.Treino> ListObjectTreinos = new List<Models.Treino>();
        public bool insertTreino(Models.Treino objTreino)
        {
            try
            {
                ListObjectTreinos.Add(objTreino);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateTreino(Models.Treino objTreino)
        {
            try
            {
                foreach (Models.Treino treino in ListObjectTreinos)
                {
                    if(treino.matricula == objTreino.matricula)
                    {
                        treino.columns = objTreino.columns;
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public bool removeTreino(Models.Treino objTreino)
        {
            try
            {
                foreach(Models.Treino treino in ListObjectTreinos)
                {
                    if(treino.matricula == objTreino.matricula)
                    {
                        ListObjectTreinos.Remove(treino);
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
