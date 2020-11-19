using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer {
    class Program {
        static void Main(string[] args) {
            //Createa object of Socket Class
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Create an onject of an IP Address.socket listening on any ip address

            IPAddress ipaddr = IPAddress.Any;

            // Define IP END POINT
            IPEndPoint ipep = new IPEndPoint(ipaddr, 25000);

            // Bind socket to ip end point

            try {
                listenerSocket.Bind(ipep);

                //Call listen method on the Listener socket object, pass the a number to signify how many

                //clients can wait for a connection

                listenerSocket.Listen(5);

                //Call Accept method on the listener socket.

                //Accept is a synchronous method

                Socket client = listenerSocket.Accept();

                //print out client ip end point
                Console.WriteLine("Client conneted: " + client.ToString() + " - IP end point: " + client.RemoteEndPoint.ToString());

                //define a buffer
                byte[] buff = new byte[128];

                //define number of recieved bytes
                int norb = 0;
                while (true) {
                    norb = client.Receive(buff);

                    Console.WriteLine("Number of received bytes: " + norb);

                    //convert from bytes to ascii

                    string receivedText = Encoding.ASCII.GetString(buff, 0, norb);

                    //print out text
                    Console.WriteLine("Data sent by client is: " + receivedText);

                    //send data back to buffer
                    client.Send(buff);
                    if(receivedText == "x") {
                        break;
                    }
                    Array.Clear(buff, 0, buff.Length);
                    norb = 0;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
