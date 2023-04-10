using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class FileSender
    {
        public string send(string ip, int port, byte[] file)
        {
            string response = string.Empty;
            try
            {
                TcpClient tcpClient = new TcpClient(ip, port);

                NetworkStream stream = tcpClient.GetStream();
                stream.Write(file, 0, file.Length);

                StreamReader streamReader = new StreamReader(stream);
                response = streamReader.ReadLine();

                streamReader.Close();
                stream.Close();
                tcpClient.Close();
            }
            catch(Exception ex)
            {
                response = "nie udało się połaczyć";
            }
            return response;
        }
    }
}
