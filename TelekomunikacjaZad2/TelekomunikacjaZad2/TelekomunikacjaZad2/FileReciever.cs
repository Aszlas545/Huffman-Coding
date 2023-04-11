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
    internal class FileReciever         //klasa której zadaniem jest odbieranie danych (socked)
    {
        FileEncoder fileEncoder = new FileEncoder();

        public string recieveMessage(int port)                                  //funckja odbierająca pomniejszoną zakodowaną wiadomość
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);        //Utworzenie nasłuchu na port do któego podłącza się nadwaca z dowolego ip
            listener.Start();                                                   //rozpoczęcie nasłuchiwania
            TcpClient client = listener.AcceptTcpClient();                      //utworzenie clienta aceptującego połaczenai tcp
            NetworkStream stream = client.GetStream();                          //utworznie strumienia
            StreamReader streamReader = new StreamReader(stream);               //utwrzenie nadawcy i odbiorcy wiadomości (komunikacja client-serwer)
            StreamWriter streamWriter = new StreamWriter(stream);

            string Encodedmessage = string.Empty;                               //miejsce na wiadomość
            try
            {
                byte[] buffer = new byte[1024];                                 //utworzenie buffora
                stream.Read(buffer, 0, buffer.Length);                          //wczytanie wiadomości do buffora
                int recieved = 0;
                foreach (byte b in buffer)                                      //obcięcie zerowych bajtów
                {
                    if (b != 0)
                    {
                        recieved++;
                    }
                }
                byte[] bufferReduced = new byte[recieved];
                for (int i = 0; i < recieved; i++)                              //przekopiowanie bez zbędnych bajtów
                {
                    bufferReduced[i] = buffer[i];
                }
                Encodedmessage = fileEncoder.getStringFromBytes(bufferReduced); //Przetworzenie otrzymanych bajtów na ciąg zer i jedynek
                if (Encodedmessage.Length > 0)
                {
                    streamWriter.WriteLine("Dostałem wiadomość");               //informacja zwrotna dla klienta i zamknięcie wszystkiego co należy zamknąć jak w nadwacy
                    streamWriter.Flush();
                    streamWriter.Close();
                    streamReader.Close();
                    stream.Close();
                    client.Close();
                    listener.Stop();
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

        public HuffmanNode recieveTree(int port)                        //funckja odbierająca drzewo birarne
        {
            string stringOfFrequencies = string.Empty;                  //miejse na częśc wiadomości z częstotliwościami
            string stringOfSigns = string.Empty;                        //miejse na częśc wiadomości ze znakami

            TcpListener listener = new TcpListener(IPAddress.Any, port);//nastepne kroki są analogiczne jak w odbieraniu pliku
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            StreamReader streamReader = new StreamReader(stream);
            StreamWriter streamWriter = new StreamWriter(stream);
            string message = string.Empty;
            try
            {
                byte[] buffer = new byte[1024];
                stream.Read(buffer, 0, buffer.Length);

                stream.Flush();
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
                message = Encoding.ASCII.GetString(bufferReduced);      //zamianai bajtów z wiadomością na string
            }
            catch (Exception ex)
            {
                streamWriter.WriteLine("Wystąpił wyjątek. Coś poszło nie tak nie otrzymano pliku");
                streamWriter.Flush();
            }
            stringOfSigns = message.Substring(0, message.IndexOf('*'));         //przecięzcie stringa na 2 części jedna ze znakami 
            stringOfFrequencies = message.Substring(message.IndexOf('*')+1);    //druga z częstotliwościami
            streamWriter.Flush();                                               //analogiczne zamknięcie wszystkich rzeczy jak client, strumień itd.
            stream.Flush();
            streamWriter.Close();
            streamReader.Close();
            stream.Close();
            client.Close();
            listener.Stop();
            Console.WriteLine(stringOfSigns);
            Console.WriteLine(stringOfFrequencies);
            TreeSerializer serializer = new TreeSerializer();                   //utworzenia serializera
            serializer.makeLists(stringOfSigns, stringOfFrequencies);           //stworzenie list z otrzymanych stringów
            HuffmanNode node = serializer.deserialize();                        //deserializacja z list
            return node;                                                        //zwrócenie drzewa
        }
    }
}
