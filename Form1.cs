using AutoInjectorAPI;
using Guna.UI2.WinForms;
using NeuraAPI;
using NeuraReworkV2.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuraReworkV2
{
    public partial class Form1 : Form
    {
        private readonly Neura CzkFUNC = new Neura();
        public Form1()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void InitializeAsync()
        {
            try
            {
                await Editor.EnsureCoreWebView2Async(null);
                Editor.CoreWebView2.Navigate(new Uri($"file:///{Directory.GetCurrentDirectory()}/Monaco/Monacoe.html").ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // CzkFUNC.StartCommunication();
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }

        private int targetPid = 0;

        private async void Inject()
        {
            try
            {
                var proc = Process.GetProcessesByName("RobloxPlayerBeta").FirstOrDefault();
                if (proc == null)
                {
                    MessageBox.Show("Roblox is not running!", "Error");
                    return;
                }

                targetPid = proc.Id;


                if (CzkFUNC.IsAttached(targetPid))
                {
                    return;
                }


                guna2Button4.Enabled = false;

                await CzkFUNC.Attach(targetPid);


                if (!statusTimer.Enabled)
                    statusTimer.Start();


                guna2Button4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Injection failed: {ex.Message}", "Error");
                guna2Button4.Enabled = true; 
            }
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Executor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/realczk");
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {

            await AnimatePanelSlideAndResize(PanelMenu, 422, 63, 100, 17, 72);


            EndButton.Visible = true;
            guna2Button12.Visible = false;


            guna2Button10.Visible = false;


            guna2Button9.Visible = false;


            guna2Button8.Visible = false;
        }


        private Task AnimatePanelSlideAndResize(Panel panel, int startWidth, int targetWidth, int duration, int targetX, int targetY)
        {
            var tcs = new TaskCompletionSource<bool>();

            int stepCount = 15; 
            int stepTime = Math.Max(1, duration / stepCount);
            float widthStep = (float)(targetWidth - startWidth) / stepCount;
            float leftStep = (float)(targetX - panel.Left) / stepCount;
            float topStep = (float)(targetY - panel.Top) / stepCount;

            Timer timer = new Timer();
            int currentStep = 0;

            timer.Interval = stepTime;
            timer.Tick += (s, e) =>
            {
                currentStep++;
                panel.Width = (int)(panel.Width + widthStep);
                panel.Left = (int)(panel.Left + leftStep);
                panel.Top = (int)(panel.Top + topStep);

                if (currentStep >= stepCount)
                {
                    panel.Width = targetWidth;
                    panel.Left = targetX;
                    panel.Top = targetY;
                    timer.Stop();
                    timer.Dispose();
                    tcs.SetResult(true);
                }
            };

            timer.Start();
            return tcs.Task;
        }



        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            if (targetPid == 0) return;

            if (CzkFUNC.IsAttached(targetPid))
            {
                label1.ForeColor = Color.Lime;
                label1.Text = "Connected";
                guna2Button4.Image = Properties.Resources.wifion;
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Not Connected";
                guna2Button4.Image = Properties.Resources.wifioff; 
            }
        }

        private async void EndButton_Click(object sender, EventArgs e)
        {

            EndButton.Visible = false;

            guna2Button8.Visible = true;
            guna2Button9.Visible = true;
            guna2Button10.Visible = true;
            guna2Button12.Visible = true;
            await AnimatePanelSlideAndResize(PanelMenu, 63, 422, 100, 17, 72);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Executor.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Scripthub.BringToFront();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            CreditzTheme.Visible = true;

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            CreditzTheme.Visible = false;

        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {

            CreditzTheme.Visible = false;
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {

            CreditzTheme.Visible = false;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Themes.BringToFront();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            UpdateNeura.BringToFront();
            UpdateNeura.Visible = true;
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            UpdateNeura.Visible = false;
        }

        private void guna2GradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Settings.BringToFront();
        }

        private void Editor_Click(object sender, EventArgs e)
        {

        }

        private async Task guna2Button25_Click(object sender, EventArgs e)
        {
            api.Initialize();
            Task.Delay(2000);
            // Inject();
            api.AttachToAll();
        }

        private async void guna2Button26_Click(object sender, EventArgs e)
        {
            string script = "editor.getValue();";
            string result = await Editor.CoreWebView2.ExecuteScriptAsync(script);
            string editorText = Regex.Unescape(result.Trim('"'));
      //      CzkFUNC.Execute(editorText);
            api.ExecuteToAll(editorText);
        }

        private async void guna2Button29_Click(object sender, EventArgs e)
        {

        }

        private async void guna2Button30_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt",
                    DefaultExt = "lua",
                    Title = "Save Lua or Text File"
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string textToSave = await Editor.ExecuteScriptAsync("GetText();");
                    string rawText = JsonConvert.DeserializeObject<string>(textToSave);
                    File.WriteAllText(saveFileDialog1.FileName, rawText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void guna2Button27_Click(object sender, EventArgs e)
        {
            await Editor.ExecuteScriptAsync($"SetText(``);");
        }

        private void Scripthub_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
        }
    }
}
