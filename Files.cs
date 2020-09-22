using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiFile.Models
{
    public class Files
    {
        public string Nome { get; set; }

        public string Extensao { get; set; }

        public long Tamanho { get; set; }

        public Files(string fileName, string fileExtensao, long fileTamanho)
        {
            this.Nome = fileName;
            this.Extensao = fileExtensao;
            this.Tamanho = fileTamanho;
        }
    }
}