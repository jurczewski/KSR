using System.Collections.Generic;
using Zad1.Models;

namespace Zad1
{
    public interface IReader
    {
        IEnumerable<Article> ObtainVectorSpaceModels();
    }
}
