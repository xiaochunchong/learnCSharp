using System;
using System.Collections.Generic;
using System.Text;

namespace 设计原则和模式.开闭原则
{
    /// <summary>
    /// 
    /// </summary>
    public class DaZheCSharpCourse : CSharpCourse
    {
        public DaZheCSharpCourse(string Name, string ID, double Price) : base(Name, ID, Price)
        {
        }


        public double GetDaZhePrice(double count)
        {
            return base.GetPrice() * count;
        }

    }

}
