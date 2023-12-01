//Below is a simplified example showing the basic structure for both TCP (connection-oriented) and UDP (connectionless) in C#:
// TCP (Connection-Oriented) Server
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TCPServer
{
    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 12345);
        server.Start();

        Console.WriteLine("TCP Server listening...");

        TcpClient client = server.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        byte[] data = new byte[256];
        int bytesRead = stream.Read(data, 0, data.Length);
        string message = Encoding.ASCII.GetString(data, 0, bytesRead);
        Console.WriteLine($"TCP Received: {message}");

        stream.Close();
        client.Close();
        server.Stop();
    }
}

// UDP (Connectionless) Server
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPServer
{
    static void Main()
    {
        UdpClient udpServer = new UdpClient(12346);

        Console.WriteLine("UDP Server listening...");

        IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
        byte[] data = udpServer.Receive(ref clientEndPoint);
        string message = Encoding.ASCII.GetString(data);
        Console.WriteLine($"UDP Received: {message}");

        udpServer.Close();
    }
}
