using System;
using System.IO;

namespace My_demo07_流
{
    // C#  流 的学习
    class Program
    {
        static void Main(string[] args)
        {
            // FileStream：是一个文件流的类，处理文件的原始字节，即处理byte[]。
            // 对txt，xml，avi等任何文件进行内容写入、读取、复制...
            #region File类
            //File(静态类)，拥有对文件的创建，移动，删除，复制等操作(和FileInfo类功能差不多，不过FileInfo类是实例类型，文件操作多使用FileInfo,少的话使用File类)
            //@ 代表不转义
            /*   if (!File.Exists(@"D:\huang.txt"))
               {
                   File.Create(@"D:\huang.txt");
               }
               else
               {
                   //将 huang.txt 复制到 bb.txt 文件中
                   File.Copy(@"D:\huang.txt", @"D:\bb.txt");
               }
               //删除操作 
               File.Delete(@"D:\huang.txt");
               */
            #endregion

      

            #region 文本文件的读写操作
            /*    个人理解：首先是创建一个文件流，这个文件流对象相当于连接外部文件和
             * 程序内部的一条管道(管道里面是文件流创建时所指向的文件，相当于一条水管，水是
             * 文件内容)，然后这个管道(流)搭建好了，但是要操作流里面的文件内容，还要
             * 有读取或者写入的数据操作(文件内容读写器)，所以需要读写器(StreamWriter类
             * 和StreamReader类)进行读写，把读写的数据放 在流中，流只是它的载体来的。
             * 
                步骤：1、创建一个文件流对象(FileStream类,FileMode(文件模式，打开,创建,创建或者打开等)，FileAccess( 指的是 读还是写，还是读写) )
             *            2、创建相应的读写器(StreamWriter类和StreamReader类)
             *            3、执行读写操作
             *            4、关闭读写器
             *            5、关闭文件流
             */
            /*   // 写入操作
               //1、创建文件流对象
               FileStream fileStream = new FileStream(@"E:\haung.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
             //2、创建相应的读写器(例如在fileStream这个流中写入数据)
             StreamWriter sr = new StreamWriter(fileStream);
             //3、读写操作
             sr.Write("hello world");
             //4、关闭读写器
             sr.Close();
             //5、关闭流
             fileStream.Close();*/

            /*  //读取操作
              FileStream fileStream = new FileStream(@"E:\haung.txt", FileMode.Open, FileAccess.ReadWrite);
              StreamReader hu = new StreamReader(fileStream);
              var str=hu.ReadToEnd();
              hu.Close();
              fileStream.Close();
              Console.WriteLine(str);*/
            #endregion

            #region 二进制文件的读写操作
            /* //步骤和文本文件的读写操作一样
             //二进制读写器的类：BinaryReader类 和 BinaryWriter类
             //1、创建文件流，该流不仅可以传输文本类型，也可以对任意类型的文件进行读取操作
             FileStream fs = new FileStream(@"E:\二进制文件.data",FileMode.OpenOrCreate,FileAccess.ReadWrite);
             //2、二进制读取写入
             BinaryWriter bw = new BinaryWriter(fs);
             //3、写入二进制文件
             for (int i = 0; i < 10; i++)
             {
                 bw.Write(i);
             }
             Console.WriteLine("数字已经写入文件");
             bw.Close();
             fs.Close();
             Console.WriteLine("-----------------------------");

             //读取二进制文件
             FileStream fs1 = new FileStream(@"E:\二进制文件.data", FileMode.Open, FileAccess.Read);
             BinaryReader br = new BinaryReader(fs1);
             while (br.PeekChar()>-1)
             {
                 int sss = br.ReadInt32();
                 Console.WriteLine(sss);
             }
             br.Close();
             fs1.Close();*/


            #endregion

            #region 利用二进制读写实现图片复制

            FileStream fs = new FileStream(@"E:\hhh.jpg",FileMode.Open,FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            //读取一个字节数组，参数是字节数组长度
            byte[] by= bw.ReadBytes((int)fs.Length);
            bw.Close();
            fs.Close();

            //复制，相当于在另外一个路径写入图片信息
            FileStream fs2 = new FileStream(@"D:/hhh.jpg",FileMode.Create,FileAccess.Write);
            BinaryWriter bb = new BinaryWriter(fs2);
            bb.Write(by);
            Console.WriteLine("写入成功");
            bb.Close();
            fs2.Close();

            #endregion
        }
    }
}
