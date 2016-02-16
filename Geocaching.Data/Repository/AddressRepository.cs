using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class AddressRepository<T> : Repository<T>, IAddressRepository<T> where T : Address
    {
        public AddressRepository(DataContext context) : base(context)
        {
            
        }
    }
}
