using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    public class IntWrapper
    {
        public int MainField { get; set; }

        public void UpdateField()
        {

        }

        //...

        public static int operator +(IntWrapper m1, IntWrapper m2)
        {
            return m1.MainField + m2.MainField;
        }
    }
}
