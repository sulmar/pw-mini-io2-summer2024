using System.Net.Sockets;
using System.Net;
using ZplPrinter.Library.Abstractions;

namespace ZplPrinter.Library.Infrastructure;

public class NetworkPrinterService : IPrinterService
{
    private IPAddress ipAddress;
    private int port;

    public NetworkPrinterService(IPAddress ipAddress, int port)
    {
        this.ipAddress = ipAddress;
        this.port = port;
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
