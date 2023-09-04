using System;
using System.Collections.Generic;
using System.Text;

namespace 设计原则和模式.开闭原则
{
    /// <summary>
    /// 
    /// </summary>
    public class CSharpCourse : ICourse
    {
        public CSharpCourse() 
        {
        }

        public CSharpCourse(string Name, string ID, double Price)
        {
            this.Name = Name;
            this.ID = ID;
            this.Price = Price;
        }

        string Name { get; set; }
        string ID { get; set; }
        double Price { get; set; }

        public string GetName()
        {
            return this.Name;
        }

        public virtual double GetPrice()
        {
            return this.Price;
        }

        public string GetID()
        {
            return this.ID;
        }

    }
}
