using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class ListOfVisitedCachesRepository<T> : Repository<T>, IListOfVisitedCachesRepository<T> where T : ListOfVisitedCaches
    {
        public ListOfVisitedCachesRepository(DataContext context) : base(context)
        {
            
        }
    }
}
