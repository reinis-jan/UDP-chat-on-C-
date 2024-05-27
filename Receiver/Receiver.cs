using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        UdpClient udpClient = new UdpClient(11000);
        IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

        try
        {
            Console.WriteLine("gaidam ziņas");

            while (true)
            {
                byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                string receiveData = Encoding.ASCII.GetString(receiveBytes);

                Console.WriteLine($"Saņemtā ziņā: {receiveData}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            udpClient.Close();
        }
    }
}
