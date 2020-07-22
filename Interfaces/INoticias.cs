using System.Collections.Generic;
using E_Players_AspNetCore.Models;

namespace E_Players_AspNetCore.Interfaces
{
    public interface INoticias
    {
    
        //Criar
        void Create(Noticias n);
        //Ler
        List<Noticias> ReadAll();
        //Alterar
        void Update(Noticias n);
        //Excluir
        void Delete(int IdNoticias);
    }
}