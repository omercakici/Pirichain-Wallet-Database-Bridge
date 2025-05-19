using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiriChainWalletDataBridge.OOP
{
    public class commonObjects
    {
        public class tableStructure
        {
            public string dummyOne { get; set; }
            public string dummyTwo { get; set; }
            public string dummyThree { get; set; }

            public tableStructure add(string _d1, string _d2, string _d3)
            {
                this.dummyOne = _d1;
                this.dummyTwo = _d2;
                this.dummyThree = _d3;
                return this;
            }
        }
    }
}
