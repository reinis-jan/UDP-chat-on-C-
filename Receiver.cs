using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Receiver
{
    static void Main()
    {
        UdpClient udpClient = new UdpClient(11000);
        IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

        try
        {
            Console.WriteLine("Gaidam ziņas no sūtītāja");

            while (true)
            {
                byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                string receiveData = Encoding.ASCII.GetString(receiveBytes);

                Console.WriteLine($"Ir saņemta ziņa: {receiveData}");
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
