using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Model
{
    public partial class Base
    {

        public class Rootobject
        {
            public DJIdea[] ideas { get; set; }
        }

        public class DJTime
        {
            public DJDate[] dates { get; set; }
        }

        public class DJTimes
        {
            public DJOpen_Days open_days { get; set; }
            public Date1[] dates { get; set; }
            public Hours hours { get; set; }
            public DateTime show_from { get; set; }
            public DateTime show_to { get; set; }
        }

        public class Hours
        {
            public _0[] _0 { get; set; }
            public _1[] _1 { get; set; }
            public _2[] _2 { get; set; }
            public _3[] _3 { get; set; }
            public _4[] _4 { get; set; }
            public _5[] _5 { get; set; }
            public _6[] _6 { get; set; }
        }

        public class _0
        {
            public string open { get; set; }
            public string close { get; set; }
            public bool overnight { get; set; }
        }

        public class _1
        {
            public string open { get; set; }
            public string close { get; set; }
            public bool overnight { get; set; }
        }

        public class _2
        {
            public string open { get; set; }
            public string close { get; set; }
            public bool overnight { get; set; }
        }

        public class _3
        {
            public string open { get; set; }
            public string close { get; set; }
            public bool overnight { get; set; }
        }

        public class _4
        {
            public string open { get; set; }
            public string close { get; set; }
            public bool overnight { get; set; }
        }

        public class _5
        {
            public string open { get; set; }
            public string close { get; set; }
            public bool overnight { get; set; }
        }

        public class _6
        {
            public string open { get; set; }
            public string close { get; set; }
            public bool overnight { get; set; }
        }

        public class Date1
        {
            public DateTime start { get; set; }
            public DateTime end { get; set; }
        }




    }
}
