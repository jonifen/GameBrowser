using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Collections;

namespace GameBrowser
{
    class Server
    {
        string m_sIPAddr = "";
        int m_iPort = 0;

        public Server(string sIPAddr, int iPort)
        {
            // Constructor method

            m_sIPAddr = sIPAddr;
            m_iPort = iPort;
        }

        public bool pingServer(out string sPingMs)
        {
            Ping pingSvr = new Ping();
            PingOptions pingOpts = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            pingOpts.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSvr.Send(m_sIPAddr, timeout, buffer, pingOpts);
            if (reply.Status == IPStatus.Success)
            {
                sPingMs = reply.RoundtripTime.ToString();
                return true;
            }
            else
            {
                sPingMs = "";
                return false;
            }
        }

        public string getServerInfo(string sCommand)
        {
            // Make connection to game server, send data to server to request server info
            // Get server status: "ÿÿÿÿgetstatus"
            // Get server info:   "ÿÿÿÿgetinfo"
            bool serverResponded = true;
            string result = "";

            try
            {
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                client.Connect(IPAddress.Parse(m_sIPAddr), m_iPort);


                Byte[] bufferTemp = Encoding.ASCII.GetBytes(sCommand);
                Byte[] bufferSend = new Byte[bufferTemp.Length + 5];

                //Build up 4 characters now
                bufferSend[0] = Byte.Parse("255");
                bufferSend[1] = Byte.Parse("255");
                bufferSend[2] = Byte.Parse("255");
                bufferSend[3] = Byte.Parse("255");
                //bufferSend[4] = Byte.Parse("02");

                //int j = 5;
                int j = 4;

                for (int i = 0; i < bufferTemp.Length; i++)
                {
                    bufferSend[j] = bufferTemp[i];
                    j++;
                }


                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                client.Send(bufferSend, SocketFlags.None);

                //'big enough to receive response
                Byte[] bufferRec = new Byte[64999];
                try
                {
                    client.Receive(bufferRec);
                }
                catch
                {
                    serverResponded = false;
                }

                if (serverResponded)
                {
                    result = Encoding.ASCII.GetString(bufferRec).Replace("\0", ""); // remove blanks
                }
                else
                {
                    result = "error";
                }

                client.Close();
            }
            catch (Exception ex)
            {
                result = "error: " + ex.Message;
            }

            return result;
        }

        /*
         * // Code from internet to do rcon task to server (similar connectivity-wise)
         * // http://www.vbforums.com/showthread.php?t=518401
        public String rcon(String gameServerIP, int gameServerPort, String password, String rconCommand)
        {


            // 'connecting to server
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            client.Connect(IPAddress.Parse(gameServerIP), gameServerPort);


            String command;
            command = "rcon " + password + " " + rconCommand;
            Byte[] bufferTemp = Encoding.ASCII.GetBytes(command);
            Byte[] bufferSend = new Byte[bufferTemp.Length + 5];


            //'intial 5 characters as per standard
            bufferSend[0] = Byte.Parse("255");
            bufferSend[1] = Byte.Parse("255");
            bufferSend[2] = Byte.Parse("255");
            bufferSend[3] = Byte.Parse("255");
            bufferSend[4] = Byte.Parse("02");

            int j = 5;

            for (int i = 0; i < bufferTemp.Length; i++)
            {
                bufferSend[j] = bufferTemp[i];
                j++;
            }


            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            client.Send(bufferSend, SocketFlags.None);

            //'big enough to receive response
            Byte[] bufferRec = new Byte[64999];
            client.Receive(bufferRec);
            String result = Encoding.ASCII.GetString(bufferRec).Replace("\0", ""); // remove blanks
            return result;

        }
        */
    }
}
