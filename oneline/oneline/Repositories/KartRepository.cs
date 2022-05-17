using oneline.Data;
using oneline.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public class KartRepository : IKartRepository
    {
        private readonly OneLineContext _context;
        public KartRepository(OneLineContext context)
        {
            _context = context;
        }

        public IDictionary<string, object> KartBestLab(string userid)
        {
            IDictionary<string, object> bestlab = new ExpandoObject();
            Kart kart = _context.Karts.FirstOrDefault(x => x.UserId == userid);

            if (kart != null)
            {
                bestlab.Add("LabTime", kart.LabTime);
            
                int LabTimeMinute = (int)(kart.LabTime / 60);
                float LabTimeWithoutM = kart.LabTime - (LabTimeMinute * 60);
                int LabTimeSecond = (int)(LabTimeWithoutM);
                int LabTimeRemain = (int)(Math.Round((LabTimeWithoutM - LabTimeSecond) * 100,0));
                string LabTimeString = string.Format("{0:D2}:{1:D2}.{2}", LabTimeMinute, LabTimeSecond, LabTimeRemain);
                bestlab.Add("LabTimeString", LabTimeString);

            }
            
            return bestlab;
        }

        public bool LabTimeExist(string userid)
        {
            Kart kart = _context.Karts.FirstOrDefault(x => x.UserId == userid);
            if (kart == null) return false;
            else return true;
        }

        public void Register(Kart kart)
        {
            if (LabTimeExist(kart.UserId))
            {
                Kart prior_kart = _context.Karts.FirstOrDefault(x => x.UserId == kart.UserId);
                
                if(kart.LabTime > prior_kart.LabTime)
                {
                    prior_kart.LabTime = kart.LabTime;
                }
            }
            else
            {
                _context.Karts.Add(kart);
            }
            _context.SaveChanges();
        }
    }
}
