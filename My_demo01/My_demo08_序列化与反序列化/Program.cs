using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace My_demo08_序列化与反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student()
            {
                Age = 20,
                Name="杨超越",
                Number="2020",
                Sex="女"
            };
            //1、序列化
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(@"E:\杨超越.bin",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            //对对象进行序列化
            bf.Serialize(fs,stu);
            fs.Close();
            Console.WriteLine("成功序列化...");

            //2、反序列化
            FileStream fs1 = new FileStream(@"E:\杨超越.bin", FileMode.Open, FileAccess.Read);
            var a =(Student)bf.Deserialize(fs1);
            Console.WriteLine(a.Age);
            Console.WriteLine(a.Name);
            Console.WriteLine(a.Sex);
            Console.WriteLine(a.Number);


        }
    }
}
