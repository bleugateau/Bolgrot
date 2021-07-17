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
using EmbedIO.Files;
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
            
            var server = CreateWebServer("http://localhost:3001/", ClientTypeEnum.AUTH);
            server.RunAsync();

            var worldServer = CreateWebServer("http://localhost:667/", ClientTypeEnum.WORLD);
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
            if(this.checkBox1.Checked)
                this.dataGridView1.Invoke(new Action(() => dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount-1));
        }
        
        private WebServer CreateWebServer(string url, ClientTypeEnum clientTypeEnum)
        {
            var server = new WebServer(o => o
                    .WithUrlPrefix(url)
                    .WithMode(HttpListenerMode.EmbedIO))
                .WithCors()
                .WithStaticFolder("/primus/primus.js", "data/primus.js", true, m => m.WithContentCaching(true).WithDefaultExtension(".js"))
                .WithModule(new WebSocketPrimusServer("/primus/", clientTypeEnum, this))
               .WithStaticFolder("/", "data/", false);
               // .HandleHttpException(DataResponseForHttpException).HandleUnhandledException(DataResponseForHandleUnhandledException);

            // Listen for state changes.
            server.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();

            return server;
        }
        public static Task DataResponseForHttpException(IHttpContext context, IHttpException httpException)
        {
            context.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return ResponseSerializer.Json(context, httpException.Message);
        }
        public static Task DataResponseForHandleUnhandledException(IHttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return ResponseSerializer.Json(context, exception.Message);
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
            {
                this.richTextBox1.Text += cell.Value.ToString()+ "\r\n";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
        }
    }
}