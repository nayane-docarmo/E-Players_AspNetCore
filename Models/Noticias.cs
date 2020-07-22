
using System;
using System.Collections.Generic;
using System.IO;
using E_Players_AspNetCore.Interfaces;

namespace E_Players_AspNetCore.Models
{
    public class Noticias: EPlayersBase , INoticias
    {
        public int IdNoticias { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH ="Datebase/noticias.csv";

        public void Create(Noticias n)
        {
        string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinha(Noticias n)
        {
            return $"{n.Titulo};{n.Texto};{n.Imagem}";
        }

        public void Delete(int INoticias)
        {
        List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticias.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Noticias> ReadAll()
        {
       List<Noticias> noticia = new List<Noticias>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticias = new Noticias();
                noticias.IdNoticias = Int32.Parse(linha[0]);
                noticias.Titulo = linha[1];
                noticias.Texto = linha[2];
                noticias.Imagem = linha[3];

                noticia.Add(noticias);
            }
            return noticia;
        }

        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticias.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
 
        }
    }
}