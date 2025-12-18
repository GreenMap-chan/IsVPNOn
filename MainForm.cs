using Microsoft.Win32;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsVPNOn
{
    public partial class MainForm : Form
    {
        static HttpClient httpClient = new HttpClient();
        System.Windows.Forms.Timer? ipRequestTimer;
        static Icon? RedIcon;
        static Icon? GreenIcon;
        static Icon? Yellow;
        static AppData? appData = AppData.LoadAppData();
        static bool isInStartup = false;
        public MainForm()
        {
            InitializeComponent();
            CreateIcons();
            notifyIconMain.Icon = Yellow;
            FillServers();
            RestoreUIState();
            setupErrorLabel();
        }

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        void ChangeIcon(string color)
        {
            if (color == "red")
            {
                notifyIconMain.Icon = RedIcon;
                return;
            }
            else if (color == "green")
            {
                notifyIconMain.Icon = GreenIcon;
                return;
            }
        }
        static void CreateIcons()
        {
            RedIcon = CreateIcon(Brushes.Red);
            GreenIcon = CreateIcon(Brushes.Green);
            Yellow = CreateIcon(Brushes.Yellow);
        }
        static Icon CreateIcon(Brush color)
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.FillEllipse(color, 0, 0, 15, 15);
            }
            return Icon.FromHandle(bmp.GetHicon());
        }
        static void SetupTimer(System.Windows.Forms.Timer timer, int interval, EventHandler callback)
        {
            timer.Interval = interval;
            timer.Tick += callback;
            timer.Start();
        }
        void RestoreUIState()
        {
            if (appData != null)
            {
                // Restore white IP
                if (!string.IsNullOrEmpty(appData.whiteIP))
                {
                    whiteIPtext.Text = appData.whiteIP;
                }
                // Restore selected server IP
                if (!string.IsNullOrEmpty(appData.serverIP))
                {
                    serverCB.SelectedItem = appData.serverIP;
                    startIpCheckTimer();
                }
            }
        }
        void FillServers()
        {
            ConfigManager.ipServices.ToList().ForEach(ipService =>
            {
                serverCB.Items.Add(ipService);
            });
        }
        async void UpdateIPStatus(object? sender, EventArgs e)
        {
            string? ip = await GetMyIP();
            if (ip == null)
            {
                ChangeIcon("yellow");
                resultLabel.BackColor = Color.LightYellow;
                resultLabel.Text = "???";
            }
            else if (ip == whiteIPtext.Text)
            {
                ChangeIcon("red");
                resultLabel.BackColor = Color.LightCoral;
                resultLabel.Text = "Disabled";
            }
            else
            {
                ChangeIcon("green");
                resultLabel.BackColor = Color.LightGreen;
                resultLabel.Text = "Enabled";
            }
        }
        async Task<string?> GetMyIP()
        {
            try
            {
                errorLabel.Visible = false;
                return await httpClient.GetStringAsync(serverCB.Text);
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
                return null;
            }
        }
        private async void fillIpBut_Click(object sender, EventArgs e)
        {
            string? ip = await GetMyIP();
            if (ip == null)
            {
                whiteIPtext.Text = "Error";
            }
            else
            {
                whiteIPtext.Text = ip;
            }
        }

        private void startBut_Click(object sender, EventArgs e)
        {
            startIpCheckTimer();
        }

        void startIpCheckTimer()
        {
            if (ipRequestTimer != null)
            {
                ipRequestTimer.Stop();
                ipRequestTimer.Dispose();
            }

            ipRequestTimer = new System.Windows.Forms.Timer();
            SetupTimer(ipRequestTimer, ConfigManager.timerInterval, UpdateIPStatus);

            UpdateIPStatus(null, new EventArgs());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppData appData = new AppData
            {
                whiteIP = whiteIPtext.Text,
                serverIP = serverCB.SelectedItem?.ToString()
            };
            appData.SaveAppData();
        }
        void setupErrorLabel()
        {
            errorLabel.Visible = false;
            errorLabel.BackColor = Color.LightCoral;
        }

        public async Task<bool> IsInStartupAsync(string appName)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(ConfigManager.RunPath, false))
                    {
                        return key?.GetValue(appName) != null;
                    }
                }
                catch
                {
                    return false;
                }
            });
        }

        public async void AddToStartupCurrentUser(string appName, string appPath)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(ConfigManager.RunPath, true))
                    {
                        key?.SetValue(appName, appPath);
                    }
                }
                catch
                {
                    errorLabel.Text = "Failed to add to startup.";
                }
            });

        }

        public async void RemoveFromStartupCurrentUser(string appName)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(ConfigManager.RunPath, true))
                    {
                        key?.DeleteValue(appName, false);
                    }
                }
                catch
                {
                    errorLabel.Text = "Failed to remove from startup.";
                }
            });
        }

        private void startupCB_CheckedChanged(object sender, EventArgs e)
        {
            if (!isInStartup)
            {
                if (startupCB.Checked)
                {
                    AddToStartupCurrentUser(ConfigManager.AppName, Application.ExecutablePath);
                }
                else
                {
                    RemoveFromStartupCurrentUser(ConfigManager.AppName);
                }
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            isInStartup = true;
            startupCB.Checked = await IsInStartupAsync(ConfigManager.AppName);
            isInStartup = false;
        }
    }
}
