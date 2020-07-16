using System;
using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces;

namespace E_Players.Models
{
    //herdando EplayersBase e a interface IEquipe, fazendo com que todos os metodos e atributos da interface seja instanciado na classe filha
    public class Equipe : EplayersBase , IEquipe
    {
        public int      IdEquipe  { get; set; }
        public string   Nome      { get; set; }
        public string   Imagem    { get; set; }
        private const string PATH = "Database/equipe.csv";


        /// <summary>
        /// metodo contrutor chamando metodo do EplayersBase para criar a pasta e diretorio
        /// </summary>
        public Equipe(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Equipe e)
        {
            string[] linha = {PreparLinha(e)};
            File.AppendAllLines(PATH, linha);
        }
        
        private string PreparLinha(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }


        public void Delete(int idEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == idEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add( PreparLinha(e) );
            RewriteCSV(PATH, linhas);
        }

    }
}