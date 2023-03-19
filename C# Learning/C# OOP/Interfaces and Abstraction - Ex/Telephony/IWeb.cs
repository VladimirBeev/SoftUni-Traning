using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public interface IWeb
    {
        public string WebSite { get; set; }

        public string WebUrl();
    }
}
