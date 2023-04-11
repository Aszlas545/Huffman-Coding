using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TelekomunikacjaZad2
{
    internal class FileSender   //klasa nadająca wiadomość przez socket
    {
        public string sendMessage(string ip, int port, byte[] file)         //funkcja nadająca wiadomość
        {
            string response = string.Empty; //miejsce na wiadomość zwrotną odbiorcy
            try
            {
                TcpClient tcpClient = new TcpClient(ip, port);      //utworzenie clienta (odbiorcy) na podstawie jego portu i ip lokalnego podanego przez drugiego użytkownika programu
                
                NetworkStream stream = tcpClient.GetStream();               //otwarcie strumienia do przesyłu
                stream.Write(file, 0, file.Length);                         //nadanie wiadomości
                StreamReader streamReader = new StreamReader(stream);       //utowrzenie readera odczytującego dopowiedzi serwera (odbiorcy)
                response = streamReader.ReadLine();                         //odczytanie odpowiedzi
                while (response == string.Empty)
                {
                    response = streamReader.ReadLine();
                }
                streamReader.Close();                                       //zamknięcie wszystkich reczy które trzeba zamknąć tj. strumień, client itd.
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
