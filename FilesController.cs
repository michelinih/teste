using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiFile.Models;
using System.IO.Compression;
using System.IO;

namespace WebApiFile.Controllers
{
    public class FilesController : ApiController
    {
        private static List<Files> files = new List<Files>();

        //Utilizei a chamada Get igual ao Postman para facilitar a chamada
        public List<Files> Get()
        {
            return files;
        }

        //Utilizei a nomenclatura igual ao POstman para facilitar a chamada
        public void Post(string pastazip, string pastaext)
        {

            string startPath = string.Concat(@"C:\start");
            string zipPath = string.Concat(@"C:\",pastazip,".zip");
            string extractPath = string.Concat(@"C:\",pastaext);

            if (Directory.Exists(zipPath))
            {
                throw new DirectoryNotFoundException("Pasta já existe nesse diretório");
            }
            else
            {
                ZipFile.CreateFromDirectory(startPath, zipPath);

                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }           

            //Marca o diretório a ser listado
            DirectoryInfo diretorio = new DirectoryInfo(extractPath);

            //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
            FileInfo[] Arquivos = diretorio.GetFiles("*.*");

            //Lista os parametros dos arquivos extraídos na lista a ser retornada
            files = new List<Files>();

            foreach (FileInfo d in Arquivos)
            {
   
                files.Add(new Files(d.Name.ToString(), d.Extension, d.Length));

            }

        }
    }
}
