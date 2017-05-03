

using pidevPMT.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pidevPMT.data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        pidevpmt1Context DataContext { get; }
    }

}
