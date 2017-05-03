

using pidevPMT.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pidevPMT.data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private pidevpmt1Context dataContext;
        public pidevpmt1Context DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new pidevpmt1Context();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
