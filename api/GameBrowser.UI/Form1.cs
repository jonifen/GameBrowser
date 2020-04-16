using GameBrowser.Managers;
using GameBrowser.Models.Q3A;
using System;
using System.Windows.Forms;

namespace GameBrowser.UI
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serverListGrid.Rows.Add("Home Server", "192.168.178.28", "27960");
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GameBrowser\r\n" +
                            "Version {dev}");
        }

        private void grdServerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // To Do - Get the selected row and grab the IP and Port.
            // Pass the IP and Port into the getServerInfo method,
            //  throw the output into a method to populate the lower grids/listboxes (players/serverinfo)
            if (e.RowIndex >= 0)
            {
                serverInfoGrid.Rows.Clear();
                playerListGrid.Rows.Clear();

                var row = serverListGrid.Rows[e.RowIndex];
                var serverIpAddress = row.Cells[1].Value.ToString();
                var serverPort = int.Parse(row.Cells[2].Value.ToString());

                var details = new Q3AManager().GetServerDetails(serverIpAddress, serverPort);
                UpdateRow(e.RowIndex, details);

                sbrlbl_Status.Text = details.Ping < 9999 ? "Ready" : "Server unavailable";
            }
        }

        private void UpdateRow(int serverRowIndex, ServerDetails serverDetails)
        {
            // Server list
            serverListGrid.Rows[serverRowIndex].Cells[3].Value = serverDetails.Ping.ToString();
            serverListGrid.Rows[serverRowIndex].Cells[4].Value = $"{serverDetails.Players.Count.ToString()}/{serverDetails.MaxClients.ToString()}";
            serverListGrid.Rows[serverRowIndex].Cells[5].Value = serverDetails.GameName;
            serverListGrid.Rows[serverRowIndex].Cells[6].Value = serverDetails.MapName;

            // Server Info list
            serverInfoGrid.Rows.Clear();

            foreach (var detail in serverDetails.AllDetails)
            {
                serverInfoGrid.Rows.Add(detail.Key, detail.Value);
            }

            // Players list
            playerListGrid.Rows.Clear();

            foreach (var player in serverDetails.Players)
            {
                playerListGrid.Rows.Add(player.Name, player.Score, player.Ping);
            }
        }

        private void mnuServerSelectedRefresh_Click(object sender, EventArgs e)
        {
            //To Do - trigger the server refresh method
        }
    }
}
