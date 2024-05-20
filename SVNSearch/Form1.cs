using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVNSearch
{
    public partial class SVNSearch : Form
    {
        public SVNSearch()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string searchString = searchBox.Text;
            string URL = urlBox.Text;
            bool empty = string.IsNullOrEmpty(URL);

            if (empty)
            {
                URL = "file:///torr-svn/Database/T/";
            }

            // Display initial "Searching" text
            searchOutput.Text = "Searching";

            // Start a timer to update the text every second
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second interval
            timer.Tick += (s, args) =>
            {
                UpdateSearchingText();
            };
            timer.Start();

            try
            {
                // Construct PowerShell command
                string command = $"svn ls -R --search '{EscapeSingleQuotes(searchString)}' '{EscapeSingleQuotes(string.IsNullOrEmpty(URL) ? "file:///torr-svn/Database/T/" : URL)}'";

                // Start the process to run the PowerShell command
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "powershell.exe";
                    process.StartInfo.Arguments = $"-Command \"{command}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    outputPanel.Controls.Clear();

                    if (empty)
                    {
                        Label emptyLabel = new Label();
                        emptyLabel.Width = 500;
                        emptyLabel.Text = "Searching entire repository - specify URL to folder for quicker results.";
                        outputPanel.Controls.Add(emptyLabel);
                    }

                    // Asynchronously read the output of the command
                    //string output = await process.StandardOutput.ReadToEndAsync();

                    string line;
                    while ((line = await process.StandardOutput.ReadLineAsync()) != null)
                    {
                        // Create a new LinkLabel for each line of output
                        LinkLabel linkLabel = new LinkLabel();
                        linkLabel.Text = line;
                        Debug.WriteLine("Output line: " + line);
                        linkLabel.AutoSize = true;
                        linkLabel.LinkClicked += (sender, eventArgs) =>
                        {
                            string CheckoutURL = "tsvn:" + URL + "/" + line;
                            // Handle the click event (e.g., open a browser with the link)
                            Process.Start(new ProcessStartInfo { FileName = CheckoutURL, UseShellExecute = true });
                        };

                        // Add the LinkLabel to the outputPanel
                        outputPanel.Controls.Add(linkLabel);
                    }

                    process.WaitForExit();

                    if (line != null && line.StartsWith("svn :"))
                    {
                        line = "You must first install SVN command line tools \r\nDownload and run the installer: https://tortoisesvn.net/downloads.html\r\nMake sure 'command line client tools' are set to install fully" +
                            "\r\nEnsure the SVN folder (usually C:/Program Files/TortoiseSVN/Bin) is now listed in your PATH\r\nFind your PATH: Settings > About > Advanced System Settings > Environment Variables > PATH. Add it if not found";
                    }

                    if (line == "")
                    {
                        searchOutput.Text = "No results";
                    }
                    else
                    {
                        // Display the final output in the output box
                        searchOutput.Text = line;
                    }


                }
            }
            finally
            {
                // Stop the timer and clean up
                timer.Stop();
                timer.Dispose();
            }
        }

        private void urlBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Check if searchBox is empty
                if (string.IsNullOrEmpty(searchBox.Text))
                {
                    // Move focus to searchBox
                    searchBox.Focus();
                    e.Handled = true;
                }
                else
                {
                    // Both fields are filled, trigger button click
                    searchButton.PerformClick(); // Call button click event handler
                }
            }
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Check if urlBox is empty
                if (string.IsNullOrEmpty(urlBox.Text))
                {
                    // Move focus to urlBox
                    urlBox.Focus();
                    e.Handled = true;
                }
                else
                {
                    // Both fields are filled, trigger button click
                    searchButton.PerformClick(); // Call button click event handler
                }
            }
        }


        // Helper method to escape single quotes in the string for PowerShell command
        private string EscapeSingleQuotes(string input)
        {
            // Replace single quotes with two single quotes to escape them
            return input.Replace("'", "''");
        }

        private int dotsCount = 0;
        private void UpdateSearchingText()
        {
            dotsCount = (dotsCount + 1) % 4; // Cycle between 0, 1, 2, 3
            searchOutput.Text = "Searching" + new string('.', dotsCount);
        }

        private void searchOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}