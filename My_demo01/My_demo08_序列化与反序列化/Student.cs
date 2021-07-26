using System;
using System.Collections.Generic;
using System.Text;

namespace My_demo08_序列化与反序列化
{
    //序列化
    [Serializable]
  public  class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Number { get; set; }

    }
}
