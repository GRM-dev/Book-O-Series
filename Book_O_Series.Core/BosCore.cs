using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_O_Series.Core
{
    public class BosCore
    {
        public BosCore(BosApp app)
        {
            Current = this;
            App = app;
        }

        public static BosCore Current { get; set; }
        public BosApp App { get; }
    }
}
