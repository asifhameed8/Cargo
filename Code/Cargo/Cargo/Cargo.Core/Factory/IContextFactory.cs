using Cargo.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Core.Factory
{
    public interface IContextFactory
    {
        IDatabaseContext DbContext { get; }
    }
}
