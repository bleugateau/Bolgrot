using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bolgrot.Tools.MITM.Network;
using EmbedIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swan.Logging;

namespace Bolgrot.Tools.MITM
{
    public partial class Form1 : Form
    {

        private bool Record = true;
        
        public Form1()
        {
            InitializeComponent();

            this.dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Descending);
            
            var server = CreateWebServer("http://localhost:440/", ClientTypeEnum.AUTH);
            server.RunAsync();

            var worldServer = CreateWebServer("http://localhost:446/", ClientTypeEnum.WORLD);
            worldServer.RunAsync();

            this.recordButton.Enabled = !Record;

            this.dataGridView1.SelectionChanged += (sender, args) =>
            {
                if (this.dataGridView1.SelectedRows.Count == 0)
                    return;

                var row = this.dataGridView1.SelectedRows[0];
                
                var objectMessage = JsonConvert.DeserializeObject<JObject>(row.Cells[2].FormattedValue.ToString().Substring(1, row.Cells[2].FormattedValue.ToString().Length - 1));
                this.richTextBox1.Text = JsonConvert.SerializeObject(objectMessage, Formatting.Indented);
            };

        }

        public void ClearDataGridView()
        {
            this.dataGridView1.Invoke(new Action(() => this.dataGridView1.Rows.Clear()));
        }

        public void AddMessageToDataGridView(ClientTypeEnum clientTypeEnum, string message)
        {
            if (!Record || !message.StartsWith("4{"))
            {
                return;
            }
            
            var time = $"{DateTime.Now.Hour.ToString()}:{DateTime.Now.Minute}";

            this.dataGridView1.Invoke(new Action(() => this.dataGridView1.Rows.Add(new string[]
            {
                time,
                $"{Enum.GetName(typeof(ClientTypeEnum), clientTypeEnum)}",
                message
            })));
            
            this.dataGridView1.Invoke(new Action(() => dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount-1));
        }
        
        private WebServer CreateWebServer(string url, ClientTypeEnum clientTypeEnum)
        {
            var server = new WebServer(o => o
                    .WithUrlPrefix(url)
                    .WithMode(HttpListenerMode.EmbedIO))
                .WithModule(new WebSocketPrimusServer("/primus/", clientTypeEnum, this));

            // Listen for state changes.
            server.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();

            return server;
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            this.Record = true;
            
            this.stopRecordingButton.Enabled = true;
            this.recordButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Record = false;
            
            this.stopRecordingButton.Enabled = false;
            this.recordButton.Enabled = true;
        }
    }
}