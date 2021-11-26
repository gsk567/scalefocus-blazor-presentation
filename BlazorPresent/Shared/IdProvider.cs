using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPresent.Shared
{
    public class IdProvider : IIdProvider
    {
        private Guid id;

        public IdProvider()
        {
            this.id = Guid.NewGuid();
        }

        public Guid GetId()
        {
            return this.id;
        }
    }
}
