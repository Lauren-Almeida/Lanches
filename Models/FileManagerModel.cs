using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanches.Models
{
    public class FileManagerModel
    {
        public FileInfo[] Files { get; set; }
        public IFormFile IFormFile { get; set; }
        public List<IFormFile> IFormFiles { get; set; } 
        public string PathImagesProduto {get; set;}
    }
}