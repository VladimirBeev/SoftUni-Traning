using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Military_Elite
{
    public interface ICommando
    {
        public List<Missions> Mission { get; set; }
        void CompleteMission();
    }
}
