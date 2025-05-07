using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Internet
{
    public partial class Internet_Form : Form
    {
        public static EventLog _logger = new EventLog();
        public Tuple<DateTime, ushort> codeInfo = null;
        private CancellationTokenSource _monitorTokenSource = new CancellationTokenSource();
        private Code CashedCode = new Code();
        private System.Windows.Forms.Timer countdownTimer;
        private DateTime endTime;
        private  string EthernetName = "Ethernet 6"; // Change this to your Ethernet name if needed

        public Internet_Form()
        {
            InitializeComponent();
            InitializeButtonRegions();
        }

        private void InitializeButtonRegions()
        {
            // Initialize close button region
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, btn_Close.Width, btn_Close.Height);
                btn_Close.Region = new Region(path);
            }

            // Initialize minimize button region
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, btn_Minimize.Width, btn_Minimize.Height);
                btn_Minimize.Region = new Region(path);
            }
        }

        private void btn_GO_Enter(object sender, EventArgs e)
        {
            if (btn_GO.Enabled) // only highlight if enabled
                btn_GO.BackColor = Color.LightBlue; // Hover color
        }
        private void btn_GO_Leave(object sender, EventArgs e)
        {
            if (btn_GO.Enabled) // only highlight if enabled
                btn_GO.BackColor = Color.Silver; // Hover color
        }

        private void TextBox_Change(object sender, EventArgs e)
        {
            if (IsThereAnyText(textBox1))
                btn_GO.Enabled = true;
            else
                btn_GO.Enabled = false;
        }
        private bool IsThereAnyText(TextBox textBox)
        {
            return !string.IsNullOrWhiteSpace(textBox.Text);
        }

        private async void btn_GO_Click(object sender, EventArgs e)
        {
            btn_GO.Enabled = false;
            await Enable();
            ProcessCode(textBox1.Text.ToUpper());
            // Re-enable after 10 seconds
            await Task.Delay(10000);
            btn_GO.Enabled = true;
            btn_GO.BackColor = Color.Silver;
        }
        private void ProcessCode(string text)
        {
            try
            {
                var CODE = GetCode(text);
                if (CODE != null && IsCodeValid(CODE.StartTime,CODE.Duration))
                {
                    CashedCode.TheCode = CODE.TheCode;
                    CashedCode.Duration = CODE.Duration;
                    CashedCode.StartTime = CODE.StartTime;
                    CashedCode.Status = CODE.Status;

                    MessageBox.Show("Use Your Minutes Online Wisely !" , "You Are Online :)" ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    StartCountdown(CashedCode.StartTime, CashedCode.Duration);
                }
                else
                {
                    Disable();
                    MessageBox.Show("The Code is invalid or used before");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void StartCountdown(DateTime startTime, int durationInMinutes)
        {
            endTime = startTime.AddMinutes(durationInMinutes);

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 50; // update ~20 times/sec
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan remaining = endTime - DateTime.Now.AddHours(-1);
            

            if (remaining <= TimeSpan.Zero)
            {
                countdownTimer.Stop();
                Disable();
                label_TimeLeft.Text = "00:00";
            }
            else
            {
                int totalMinutes = (int)remaining.TotalMinutes;
                int seconds = remaining.Seconds;
                label_TimeLeft.Text = $"{totalMinutes:D2}:{seconds:D2}";
            }
        }

        private void Disable()
        {
            try
            {
                Console.WriteLine("Attempting to disable Ethernet...");
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID IS NOT NULL"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["NetConnectionID"]?.ToString();

                        if (name != null && name.StartsWith("Ethernet") && name == EthernetName)
                        {
                            var result = obj.InvokeMethod("Disable", null);
                            Console.WriteLine($"Successfully disabled {name}: {result}");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disabling Ethernet: {ex.Message}");
            }
        }
        private async Task Enable()
        {
            try
            {
                Console.WriteLine("Attempting to enable Ethernet...");
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID IS NOT NULL"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["NetConnectionID"]?.ToString();

                        if (name != null && name.StartsWith("Ethernet") && name == EthernetName)
                        {
                            // Perform the enabling operation asynchronously.
                            var result = await Task.Run(() => obj.InvokeMethod("Enable", null));
                            Console.WriteLine($"Successfully enabled {name}: {result}");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enabling Ethernet: {ex.Message}");
            }
        }


        public bool IsCodeValid(DateTime startTime, int durationMinutes)
        {
            return TimeLeft(startTime, durationMinutes);
        }
        public bool TimeLeft(DateTime startTime, int duration)
        {
            TimeSpan timeLeft = (startTime.AddMinutes(duration)) - DateTime.Now.AddHours(-1);

            if (timeLeft.TotalSeconds > 0)
            {
                Console.WriteLine($"⏳ Code valid for {Math.Ceiling(timeLeft.TotalMinutes)} more minutes.");
                return true;
            }
            else
            {
                Console.WriteLine("⛔ Code expired.");
                return false;
            }
        }


        public Code GetCode(string code)
        {
            string connectionString = "Server=db18170.public.databaseasp.net; Database=db18170; User Id=db18170; Password=D!n9mA8@_sL7; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

            string query = "SELECT TOP 1 * FROM Codes WHERE TheCode = @code AND Status = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@code", code);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Code
                        {
                            Id = (int)reader["Id"],
                            TheCode = (string)reader["TheCode"],
                            StartTime = (DateTime)reader["StartTime"],
                            Duration = (int)reader["Duration"],
                            Status = (int)reader["Status"]
                        };
                    }
                }
            }

            return null; // Not found or inactive
        }

        public class Code
        {
            public int Id { get; set; }

            public string TheCode { get; set; }

            public DateTime StartTime { get; set; }
            public int Duration { get; set; }

            public int Status { get; set; }
        }


        private void btn_Close_MouseEnter(object sender, EventArgs e)
        {           
            btn_Close.BackColor = Color.FromArgb(232, 17, 35); // Red color for close button
        }
        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {           
            btn_Close.BackColor = Color.Transparent;
        }
        private void btn_Minimize_MouseEnter(object sender, EventArgs e)
        {
            btn_Minimize.BackColor = Color.FromArgb(232, 17, 35); // Red color for minimize button
        }
        private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        {
            btn_Minimize.BackColor = Color.Transparent;
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Disable();
            Application.Exit();
        }

        private void Internet_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disable();
        }
    }
}
