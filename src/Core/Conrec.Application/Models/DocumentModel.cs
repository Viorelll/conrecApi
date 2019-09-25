using System;
using System.Collections.Generic;
using System.Text;

namespace Conrec.Application.Models
{
    public class DocumentModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
