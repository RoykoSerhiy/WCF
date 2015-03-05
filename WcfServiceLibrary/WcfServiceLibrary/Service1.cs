using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    public class MyMath : IMyMath
    {
        public MathResult Total(int x, int y)
        {
            MathResult mr = new MathResult();
            mr.sum = x + y;
            mr.subtr = x - y;
            if (y != 0) mr.div = x / y;
            mr.mult = x * y;
            return mr;
        }
    }
}
