using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace My_demo05_socket编程
{
    //socket编程  tcp协议
    class Program
    {
        //服务器端
        static void Main(string[] args)
        {
            //---------服务器端发送消息-------------
            // 第一步：创建socket
            // 参数含义依次是： 内网，流的形式，tcp协议
            Socket tcpServicer = new  Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //第二步：绑定IP 192.168.0.107 和 端口号
            IPAddress ipaddress = new IPAddress(new byte[]{192,168,0,107});// endpoint是一个抽象类，ipendpoint是他的实现类
            //point 是ip+端口号做了一层封装的类
            EndPoint point = new IPEndPoint(ipaddress, 7788);
            //向操作系统申请一个 可用的ip和端口号 来做通信
            tcpServicer.Bind(point);

            //第三步，开始监听(就是指等待客户端做连接)
            tcpServicer.Listen(100);// 最大客户端连接数
            //接受客户端连接
           Socket clientSocket =  tcpServicer.Accept();//  暂停当前线程，直到有一个客户端连接过来，之后进行下面的代码
            //使用返回的socket跟客户端做通信
            string msg = "欢迎你";
            byte[] data = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);

            //-------服务器端接收消息--------
            byte[] bb = new byte[1024];
           int len = clientSocket.Receive(bb);
            string msg2 = Encoding.UTF8.GetString(bb, 0, len);
            Console.WriteLine("接受客户端消息"+msg2);
            Console.ReadKey();

        }
    }
}
