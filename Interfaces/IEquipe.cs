using System.Collections.Generic;
using E_Players_AspNetCore.Models;


namespace E_Players_AspNetCore.Interfaces
{
    public interface IEquipe
    {
        //Criar
        void Create(Equipe e);
        //Ler
        List<Equipe> ReadAll();
        //Alterar
        void Update(Equipe e);
        //Excluir
        void Delete(int IdEquipe);
    }
}