using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _001_socket编程_tcp协议_客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            //第一步，同样是创建一个socket
            Socket tcpClient = new  Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            //2.发起建立连接的请求
            //把字符串转化为ip地址（IPAddress对象）
            IPAddress iPAddress = IPAddress.Parse("192.168.0.107");
            EndPoint Point = new IPEndPoint(iPAddress, 7788);
            tcpClient.Connect(Point);

            //3.接受消息
            byte[] data = new byte[1024];
            //length返回值表示接收了多少字节的数据
           int length =  tcpClient.Receive(data);//传递一个byte数组，实际上是用来接收服务器返回的数据
            var str = Encoding.UTF8.GetString(data,0,length);//取length个字节(有效信息部分)
            Console.WriteLine(str);
            Console.ReadKey();

            //--------------------
            //向服务器端发送消息
            string str1 = Console.ReadLine();
            tcpClient.Send(Encoding.UTF8.GetBytes(str1));//需要把字符串转成字节数组

        }
    }
}
