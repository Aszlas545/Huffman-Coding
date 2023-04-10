using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Telekomunikacja1;

namespace TelekomunikacjaZad2
{
    internal class FileReciever
    {
        bool stopCommand = new bool();
        FileEncoder fileEncoder = new FileEncoder();

        public bool StopCommand { get => stopCommand; set => stopCommand = value; }

        public string recieveMessage(int port)
        {
            stopCommand = false;
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            StreamReader streamReader = new StreamReader(stream);
            StreamWriter streamWriter = new StreamWriter(stream);

            string Encodedmessage = string.Empty;
            try
            {
                byte[] buffer = new byte[256];
                stream.Read(buffer, 0, buffer.Length);
                int recieved = 0;
                foreach (byte b in buffer)
                {
                    if (b != 0)
                    {
                        recieved++;
                    }
                }
                byte[] bufferReduced = new byte[recieved];
                for (int i = 0; i < recieved; i++)
                {
                    bufferReduced[i] = buffer[i];
                }
                Encodedmessage = fileEncoder.getStringFromBytes(bufferReduced);
                if (Encodedmessage.Length > 0)
                {
                    streamWriter.WriteLine("Dostałem wiadomość");
                    streamWriter.Flush();
                    return Encodedmessage;
                }
            }
            catch (Exception ex)
            {
                streamWriter.WriteLine("Wystąpił wyjątek. Coś poszło nie tak nie otrzymano pliku");
                streamWriter.Flush();
            }
            streamWriter.WriteLine("Coś poszło nie tak nie otrzymano pliku");
            streamWriter.Flush();
            streamWriter.Close();
            streamReader.Close();
            stream.Close();
            client.Close();
            listener.Stop();
            return Encodedmessage;
        }
    }
}
