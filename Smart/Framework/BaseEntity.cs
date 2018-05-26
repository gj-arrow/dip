using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace demo.framework
{
    public class BaseEntity
    {
        protected static readonly Logger Log = new Logger(LogManager.GetLogger(typeof(BaseEntity)));
        protected BaseEntity()
        {
            XmlConfigurator.Configure();
        }
    }
}
