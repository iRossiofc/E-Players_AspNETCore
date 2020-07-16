using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces
{
    public interface IEquipe
    {
        //CRUD
        
        //Criar
        void Create(Equipe e);
        
        //Ler
        List<Equipe> ReadAll();
        
        //Alterar
        void Update(Equipe e);

        //Excluir
        void Delete(int idEquipe);
        
    }
}