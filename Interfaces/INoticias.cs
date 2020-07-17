using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces
{
    public interface INoticias
    {
         //CRUD
        
        //Criar
        void Create(Noticias n);
        
        //Ler
        List<Noticias> ReadAll();
        
        //Alterar
        void Update(Noticias n);

        //Excluir
        void Delete(int idNoticias);
    }
}