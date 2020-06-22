using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bourse.Models
{
    public class DownloadFile
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Symbol> Symbols { get; set; }
    }
}