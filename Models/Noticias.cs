using System;
using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Noticias : EplayersBase , INoticias
    {
        public int      IdNoticias  { get; set; }
        public string   Titulo      { get; set; }
        public string   Texto       { get; set; }
        public string   Imagem      { get; set; }

        private const string PATH = "Database/noticias.csv";

        public Noticias(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Noticias n)
        {
            string[] linha = {PreparLinha(n)};
            File.AppendAllLines(PATH, linha);
        }

        public void Delete(int idNoticias)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == idNoticias.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Noticias> ReadAll()
        {
             List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticias = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }

        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticias.ToString());
            linhas.Add( PreparLinha(n) );
            RewriteCSV(PATH, linhas);
        }

        private string PreparLinha(Noticias n){
            return $"{n.IdNoticias};{n.Titulo};{n.Texto};{n.Imagem}";
        }
    }
}