using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace GameBrowser
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            grdServerList.Rows.Add("XS4All (CTFS)", "194.109.69.93", "27960");
            grdServerList.Rows.Add("rX (CTFS)", "208.94.49.4", "27980");
            grdServerList.Rows.Add("ZUZ UrbanTerror", "91.121.146.218", "27990");
            grdServerList.Rows.Add("rw (CTFS)", "83.233.238.206", "27960");
        }

        #region Menu Options

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            // Close the application
            this.Close();
        }


        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GameBrowser\r\n" +
                            "Version {dev}");
        }

        #endregion Menu Options

        private string getServerInfo(string sIPAddr, int iPort, string sCommand)
        {
            // Make connection to game server, send data to server to request server info
            // Get server status: "ÿÿÿÿgetstatus"
            // Get server info:   "ÿÿÿÿgetinfo"

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            client.Connect(IPAddress.Parse(sIPAddr), iPort);


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
                MessageBox.Show("Server unavailable");
            }
            String result = Encoding.ASCII.GetString(bufferRec).Replace("\0", ""); // remove blanks

            client.Close();

            return result;
        }


        private void grdServerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sPingMs;

            // To Do - Get the selected row and grab the IP and Port.
            // Pass the IP and Port into the getServerInfo method,
            //  throw the output into a method to populate the lower grids/listboxes (players/serverinfo)
            if (e.RowIndex >= 0)
            {
                grdServerInfo.Rows.Clear();
                grdPlayerInfo.Rows.Clear();

                object oValue = grdServerList.Rows[e.RowIndex].Cells[1].Value;
                string sServerIP = oValue.ToString();

                oValue = grdServerList.Rows[e.RowIndex].Cells[2].Value;
                int iServerPort = int.Parse(oValue.ToString());

                Server oServer = new Server(sServerIP, iServerPort);

                if (oServer.pingServer(out sPingMs) == true)
                {
                    string sGetStatusResponse = oServer.getServerInfo("getstatus");
                    string sGetInfoResponse = oServer.getServerInfo("getinfo");

                    // next if statement should check if the strings returned an error
                    bool result = (sGetStatusResponse.StartsWith("error")) || (sGetInfoResponse.StartsWith("error"));

                    if (result)
                    {
                        sbrlbl_Status.Text = "Server unavailable";
                    }
                    else
                    {
                        handleServerStatusInfo(sGetStatusResponse);
                        handleServerInfoInfo(sGetInfoResponse, e.RowIndex);
                        //Application.DoEvents();
                        //updateServerList(sServerIP, e);
                        grdServerList.Rows[e.RowIndex].Cells[3].Value = sPingMs;
                        sbrlbl_Status.Text = "Ready";
                    }
                }
                else
                {
                    sbrlbl_Status.Text = "Server unavailable (The IP Address cannot be found!)";
                }
            }
        }


        private void handleServerStatusInfo(string sStatusText)
        {
            /* Todo
             *  - Split text into fields
             *  - Split the player info from server info
             *  - Populate server info grid
             *  - Populate players grid
             *  - Update top grid with server name.
             *  - Consider adding current map and player count on top grid?
             * */

            grdServerInfo.Rows.Clear();

            // Make the array big enough to ensure it can handle all info
            string[] sInfoArray = new string[1000];

            char[] splitter = { '\\' };
            sInfoArray = sStatusText.Split(splitter);

            int i;

            // Start iterator at 1 to skip the StatusResponse message
            for (i = 1; i < sInfoArray.Length; i++)
            {
                if (i + 1 <= sInfoArray.Length)
                {
                    // Take current value and next value in array and pass into AddInfo method
                    grdServerInfo.Rows.Add(sInfoArray[i].ToString(), sInfoArray[i + 1].ToString());
                    // Force increment to go by 2
                    i++;
                }
            }

            handlePlayerInfo(sInfoArray[sInfoArray.Length -1]);

            Array.Clear(sInfoArray, 0, sInfoArray.Length);
        }


        private void handleServerInfoInfo(string sInfoText, int selectedRow)
        {
            /* Todo:
             *  - Split the data into fields (Array)
             *  - Populate what information is available into the top grid
             *     - Server name (replace what is there if not an empty value) *strip any colours!*
             *     - Player count (should be playercount/totalplayerslots)
             *     - Game mod (i.e. "threewave" etc)
             *     - Map name
             * */

            // Make the array big enough to ensure it can handle all info
            string[] sInfoArray = new string[500];

            string maxPlayers = "";
            string currentPlayers = "";

            char[] splitter = { '\\' };
            sInfoArray = sInfoText.Split(splitter);

            int i;

            // Start iterator at 1 to skip the StatusResponse message
            for (i = 1; i < sInfoArray.Length; i++)
            {
                if (i + 1 <= sInfoArray.Length)
                {
                    //example text
                    // ????infoResponse\game\threewave\punkbuster\1\pure\1\gametype\9\sv_maxclients\18\clients\2\mapname\q3wcp14\hostname\XS4ALL - Quake3 Threewave CTFS\protocol\68

                    if (sInfoArray[i].ToString() == "hostname")
                    {
                        grdServerList.Rows[selectedRow].Cells[0].Value = stripColourTags(sInfoArray[i + 1].ToString());
                    }

                    if (sInfoArray[i].ToString() == "game")
                    {
                        grdServerList.Rows[selectedRow].Cells[5].Value = sInfoArray[i + 1].ToString();
                    }

                    if (sInfoArray[i].ToString() == "mapname")
                    {
                        grdServerList.Rows[selectedRow].Cells[6].Value = sInfoArray[i + 1].ToString();
                    }

                    if (sInfoArray[i].ToString() == "sv_maxclients")
                    {
                        maxPlayers = sInfoArray[i + 1].ToString();
                    }

                    if (sInfoArray[i].ToString() == "clients")
                    {
                        currentPlayers = sInfoArray[i + 1].ToString();
                    }

                    // Force increment to go by 2
                    i++;
                }

                grdServerList.Rows[selectedRow].Cells[4].Value = currentPlayers.ToString() + "/" + maxPlayers.ToString();
            }

            Array.Clear(sInfoArray, 0, sInfoArray.Length);
        }


        private void handlePlayerInfo(string sStatusText)
        {
            /* Todo
             *  - Split text into fields
             *  - Split the player info from server info
             *  - Populate server info grid
             *  - Populate players grid
             *  - Update top grid with server name.
             *  - Consider adding current map and player count on top grid?
             * */

            grdPlayerInfo.Rows.Clear();

            // Make the array big enough to ensure it can handle all info
            string[] sInfoArray = new string[1000];

            char[] splitter = {(char)10};
            sInfoArray = sStatusText.Split(splitter);

            int i;

            char[] spaceKey = {(char)32};
            string[] sPlayerInfoArray = new string[10];
            string sPlayerName;

            // Start iterator at 1 to skip the StatusResponse message
            for (i = 1; i < sInfoArray.Length; i++)
            {
                if ((sInfoArray[i] != "") && (sInfoArray[i] != "0"))
                {
                    sPlayerInfoArray = sInfoArray[i].Split(spaceKey);

                    sPlayerName = "";
                    for (int p = 2; p < sPlayerInfoArray.Length; p++)
                    {
                        sPlayerName = sPlayerName + " " + sPlayerInfoArray[p].ToString();
                    }

                    /* Remove any quotes and leading/trailing spaces */
                    sPlayerName = sPlayerName.Replace("\"","");
                    sPlayerName = sPlayerName.Trim();

                    sPlayerName = stripColourTags(sPlayerName);

                    /* Take current value and next value in array and pass into AddInfo method */
                    grdPlayerInfo.Rows.Add(sPlayerName, sPlayerInfoArray[0].ToString(), sPlayerInfoArray[1].ToString());

                    Array.Clear(sPlayerInfoArray, 0, sPlayerInfoArray.Length -1);
                }
            }

            Array.Clear(sInfoArray, 0, sInfoArray.Length);
        }


        private string stripColourTags(string sValue)
        {
            bool bCaretFound = false;
            string caretChar = "^";
            string outputValue = "";

            IEnumerator stringEnum = sValue.GetEnumerator();

            while (stringEnum.MoveNext())
            {
                if (stringEnum.Current.ToString() == caretChar)
                {
                    bCaretFound = true;
                }
                else
                {
                    if (!bCaretFound)
                    {
                        outputValue = outputValue + stringEnum.Current.ToString();
                    }

                    bCaretFound = false;
                }
            }

            return outputValue;
        }


        private void mnuServerSelectedRefresh_Click(object sender, EventArgs e)
        {
            //To Do - trigger the server refresh method
        }


        private void updateServerList(string ipAddress, DataGridViewCellEventArgs e)
        {
            //update the server list grid with server name, ping, player count, map etc.
            grdServerList.EditMode = DataGridViewEditMode.EditProgrammatically;
            grdServerList.BeginEdit(false);

//            grdServerList.Rows[e.RowIndex].Cells[3].Value = ping.PingHost(ipAddress).ToString();

            grdServerList.EndEdit();
            grdServerList.Refresh();
        }

    }
}
