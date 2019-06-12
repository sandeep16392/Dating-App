using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Configs
{
    public interface ICommonConfigurations
    {
        string Token { get; }
        string ConnectionString { get;  }
    }
}
