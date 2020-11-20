using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiClient {
    class Program {
        private static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static IPAddress ipaddr = null;
        private static string name = null;
        static void Main(string[] args) {
            try {
                connect();
                while (true) {
                    sendMessage();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            finally {
                if (client != null) {
                    if (client.Connected) {
                        client.Shutdown(SocketShutdown.Both);
                    }
                    client.Close();
                    client.Dispose();
                }
            }
        }

        private static void connect() {
            Console.WriteLine("*** Welcome to Socket Client Starter ***");
            Console.WriteLine("Please type a Valid Server IP Address and Press Enter: ");

            string strIPAddress = Console.ReadLine();

            Console.WriteLine("Please supply a valid Port Number 0 - 65535 and press Enter: ");

            string strPortInput = Console.ReadLine();
            int nPortInput = 0;

            Console.WriteLine("Please enter your name and press Enter: ");
            name = Console.ReadLine();

            if (strIPAddress == "") {
                strIPAddress = "127.0.0.1";
            }
            if (strPortInput == "") {
                strPortInput = "25000";
            }
            if (!IPAddress.TryParse(strIPAddress, out ipaddr)) {
                Console.WriteLine("Invalid server IP supplied");
                return;
            }
            if (!int.TryParse(strPortInput.Trim(), out nPortInput)) {
                Console.WriteLine("Invalid port number supplied.");
                return;
            }
            if (nPortInput <= 0 || nPortInput > 65535) {
                Console.WriteLine("Port number must between 0 and 65535");
            }

            System.Console.WriteLine(string.Format("IPAddress: {0} - Port: {1}", ipaddr.ToString(), nPortInput));
            client.Connect(ipaddr, nPortInput);

            Console.WriteLine("Connected to the server, type text and press enter to send it to the server. Type <EXIT> to close.");

            Thread ctThread = new Thread(receiveMessage); // start a thread for receiving messages
            ctThread.Start();
        }

        private static void sendMessage() {
            string msg = Console.ReadLine(); // Read in message

            Console.SetCursorPosition(0, Console.CursorTop - 1); // Removes the readline from the console - just to look more beautiful
            ClearCurrentConsoleLine();

            msg = $"<{getTime()}> {name}: {msg}";
            byte[] buffSend = Encoding.ASCII.GetBytes(msg); // Encode into a byte array
            client.Send(buffSend); // send the data to the server
            if (msg.Contains("<EXIT>")) { // close the client socket and exit the environment
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                Environment.Exit(0);
            }
        }

        private static void receiveMessage() {
            while (true) { // keep receiving messages
                byte[] buffReceived = new byte[128];
                int nRecv = client.Receive(buffReceived);
                if(nRecv == 0) {
                    return;
                }
                byte[] data = new byte[nRecv];
                Array.Copy(buffReceived, data, nRecv);
                string text = Encoding.ASCII.GetString(data);
                Console.WriteLine(text);
            }
        }

        private static string getTime() { // Gets the time, better for the client to have this method so it's displayed what time the msg was sent rather than received by the server
            string data = DateTime.Now.ToLongTimeString();
            return data;
        }

        public static void ClearCurrentConsoleLine() { // clears the current line of console
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
