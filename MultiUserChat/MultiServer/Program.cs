using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MultiServer {
    class Program {
        //Create a object of Socket Class
        private static Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static List<Socket> clientSockets = new List<Socket>();
        private static byte[] buff = new byte[128]; // Define buffer

            
        static void Main(string[] args) {
            startServer();
            Console.ReadLine(); // press enter to close the server
            closeClientSockets();
        }

        private static void startServer() {
            Console.WriteLine("Starting server...");
            IPAddress ipaddr = IPAddress.Any;                 // Create an onject of an IP Address.socket listening on any ip address
            IPEndPoint ipep = new IPEndPoint(ipaddr, 25000);  // Define IP END POINT
            listenerSocket.Bind(ipep);                        // Bind socket to ip end point
            listenerSocket.Listen(1);                         // Max number of connection requests
            listenerSocket.BeginAccept(AcceptCallback, null); // Begin Async operation to accept incoming connections
            Console.WriteLine("Server setup complete.");
        }

        private static void AcceptCallback(IAsyncResult IAR) {
            Socket socket;
            try {
                socket = listenerSocket.EndAccept(IAR);                                     // Accepts incoming connection and creates a new socket for that host
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());                                           // print exception to screen
                return;
            }
            clientSockets.Add(socket);                                                      // add current socket to List of client sockets
            socket.BeginReceive(buff, 0, 128, SocketFlags.None, ReceiveCallback, socket);   // Begin receiving data from the socket asynchronously
            Console.WriteLine("Client conneted: " + socket.ToString() + " - IP end point: "
            + socket.RemoteEndPoint.ToString());                                            //print out client ip end point
            listenerSocket.BeginAccept(AcceptCallback, null);                                       // begin accepting again so other clients can connect
        }

        private static void ReceiveCallback(IAsyncResult IAR) {
            Socket currentSocket = (Socket)IAR.AsyncState;
            int receivedBytes;                                 // Create buffer exact size of incoming data

            try {
                receivedBytes = currentSocket.EndReceive(IAR); // End an async request
            }
            catch(SocketException) {
                Console.WriteLine("Client forcefully exited");
                currentSocket.Close();                         // Close socket on error
                clientSockets.Remove(currentSocket);           // Remove this socket from the list of clients
                return;
            }
            
            byte[] receivedBuff = new byte[receivedBytes];
            Array.Copy(buff, receivedBuff, receivedBytes);     // Copy the received data into the buffer
            Console.WriteLine("Received Message: " + Encoding.ASCII.GetString(receivedBuff));
            
            if (Encoding.ASCII.GetString(receivedBuff).Contains("<EXIT>")){ // Close the current socket and remove it from the client sockets 
                currentSocket.Shutdown(SocketShutdown.Both);
                currentSocket.Close();
                clientSockets.Remove(currentSocket);
                Console.WriteLine("Client disconnected");
                return;
            }
            sendToAllClients(Encoding.ASCII.GetString(receivedBuff)); // send the message to all currently connected clients
            currentSocket.BeginReceive(buff, 0, 128, SocketFlags.None, 
            ReceiveCallback, currentSocket);                   // Start receiving data from socket again
        }

        private static void closeClientSockets() {
            foreach (Socket socket in clientSockets) {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            listenerSocket.Close(); // Close server socket
        }

        private static void sendToAllClients(string message) { // Encode a string message to bytes and send it to all sockets in the client socket List
            foreach(Socket socket in clientSockets) {          // Assume a relatively low number of clients in this application, so a foreach loop is adequate to send messages 
                socket.Send(Encoding.ASCII.GetBytes(message));
            }
        }
    }
}
