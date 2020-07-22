
using System;
using System.Collections.Generic;
using System.IO;
using E_Players_AspNetCore.Interfaces;

namespace E_Players_AspNetCore.Models
{
    public class Noticias: EPlayersBase , INoticias
    {
      public Noticias(int idNoticias, string titulo,string texto, string imagem)
        {
            this.IdNoticias = idNoticias;
            this.Titulo = titulo;
            this.Texto = texto;
            this.Imagem = imagem;

        }
        public int IdNoticias { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        /// <summary>
        /// configuraçao da tabela em csv
        /// </summary>
        private const string PATH = "Database/noticias.csv";

        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Noticias n)
        {
        string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// como o dado será exibido
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Noticia ; titulo; texto; imagem</returns>
        private string PrepararLinha(Noticias n)
        {
            return $"{n.IdNoticias};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        public void Delete(int IdNoticias)
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