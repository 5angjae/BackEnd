using oneline.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public interface IKartRepository
    {
        void Register(Kart kart);
        bool LabTimeExist(string userid);
        IDictionary<string, object> KartBestLab(string userid);
    }
}
