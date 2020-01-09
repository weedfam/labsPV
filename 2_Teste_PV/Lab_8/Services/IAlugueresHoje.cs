using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstCarII.Models;

namespace EstCarII.Services
{
    public interface IAlugueresHoje
    {
        IEnumerable<Aluguer> AlgueresHoje { get; }
    }
}
