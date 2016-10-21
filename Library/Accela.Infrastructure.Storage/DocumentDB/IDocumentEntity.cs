using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.DocumentDB
{
    public interface IDocumentEntity
    {
        // global document key to retrieve the document
        string DocKey { get; set; }
    }
}
