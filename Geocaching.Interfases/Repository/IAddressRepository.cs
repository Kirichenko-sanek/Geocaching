using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;

namespace Geocaching.Interfases.Repository
{
    public interface IAddressRepository<T> : IRepository<T> where T : Address
    {
    }
}
