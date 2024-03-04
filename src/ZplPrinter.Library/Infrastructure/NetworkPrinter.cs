using System.Net.Sockets;
using ZplPrinter.Library.Abstractions;

public class NetworkPrinter(string ipAddress, int port) : IPrinter
{
    public NetworkPrinter(string ipAddress) 
        : this(ipAddress, 500)
    {
        
    }

    public void Print(string content)
    {
        TcpClient tcpClient = new TcpClient();
        tcpClient.Connect(ipAddress, port);

        var stream = new StreamWriter(tcpClient.GetStream());
        stream.Write(content);
        stream.Flush();
        stream.Close();
        tcpClient.Close();
    }
}