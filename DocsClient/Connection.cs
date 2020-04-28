using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting.Messaging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocsClient
{
    class Connection
    {
        public event EventHandler<string> OnDataReceived;
        public event EventHandler<string> OnErrorReceived;
        public string addr { get; set; }
        public string port { get; set; }
        private Socket socket;
        public bool StopListening { get; set; }
        public Connection()
        {
            StopListening = false;
        }
        public void Send(string str)
        {
            try
            {
                //byte[] messageSent = Encoding.UTF8.GetBytes(str);
                //byte[] testmsg = Encoding.ASCII.GetBytes("{\"type\": \"ping\", \"value\": \"ping\"}\n");
                byte[] jsonUTF8;
                var options = new JsonSerializerOptions
                {

                };
                jsonUTF8 = JsonSerializer.SerializeToUtf8Bytes(new PingRequest("ping", "ping"), options);
                byte[] end = { Convert.ToByte('\n') };
                byte[] testmsg = jsonUTF8.Concat(end).ToArray();
                int byteSent = socket.Send(testmsg);
            }
            catch (SocketException e)
            {
                OnErrorReceived?.Invoke(this, e.Message);
            }
        }
        public void Listen()
        {
            StopListening = false;
            while (!StopListening)
            {
                byte[] messageReceived = new byte[1024];
                socket.ReceiveTimeout = 2000;
                try
                {
                    int byteRecv = socket.Receive(messageReceived);
                    Console.WriteLine("dlugosc     {0}", byteRecv);
                    OnErrorReceived?.Invoke(this, Encoding.UTF8.GetString(messageReceived, 0, byteRecv));
                    OnDataReceived?.Invoke(this, Encoding.UTF8.GetString(messageReceived, 0, byteRecv));
                }
                catch (SocketException e)
                {
                    if (e.ErrorCode != 10060) //timeout
                    {
                        OnErrorReceived?.Invoke(this, e.Message);
                        StopListening = true;
                    }
                }

            }
        }
        public int Start()
        {
            try
            {
                IPAddress ipAddr = IPAddress.Parse(addr);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Convert.ToInt32(port));

                socket = new Socket(ipAddr.AddressFamily,
                           SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    socket.Connect(localEndPoint);
                    OnErrorReceived?.Invoke(this, "CONNECTED");
                    return 0;
                }

                catch (ArgumentNullException ane)
                {
                    OnErrorReceived?.Invoke(this, ane.Message);
                    return -1;
                }

                catch (SocketException se)
                {
                    OnErrorReceived?.Invoke(this, se.Message);
                    return se.ErrorCode;
                }

                catch (Exception ex)
                {
                    OnErrorReceived?.Invoke(this, ex.Message);
                    return -1;
                }
            }


            catch (Exception ex)
            {
                OnErrorReceived?.Invoke(this, ex.Message);
                return -1;
            }
        }
        public void Stop()
        {
            if (socket != null)
            {
                if (socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
        }

        public bool SocketConnected()
        {
            if (socket != null)
            {
                if (socket.Connected) return true;
                else return false;
            }
            else return false;
        }
    }
    
} 

