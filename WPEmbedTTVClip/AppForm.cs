using System;
using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using WPEmbedClipCode;

namespace URLConvert
{
    public partial class AppForm : Form
    {
        string DomainURL;
        int VideoHeight;
        int VideoWidth;
        string wordpressCode = "";
        string ErrorMessageWPCodeDuplicate = "Wordpress Code already copied to clipboard";
        string ErrorMessageNotTwitchURL = "Not a proper Twitch clip URL";
        string ErrorMessageNotValidDomain = "Not a valid Domain";

        public AppForm()
        {
            InitializeComponent();
            InitializeAppForm();
        }

        public void InitializeAppForm()
        {
            DomainTextBox.Text = Settings.Default.Domain;
            VideoHeightTextBox.Text = Settings.Default.VideoHeight;
            VideoWidthTextBox.Text = Settings.Default.VideoWidth;

            FormClosing += AppFormClosingEventHandler;
        }

        public void AppFormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Domain = DomainTextBox.Text ;
            Settings.Default.VideoHeight = VideoHeightTextBox.Text;
            Settings.Default.VideoWidth = VideoWidthTextBox.Text;
            Settings.Default.Save();

            //TODO: If domain is not valid, do not save? Close? Something
        }

        public void SaveFieldValuesToSettings()
        {
            Settings.Default.Domain = DomainTextBox.Text;
            Settings.Default.VideoHeight = VideoHeightTextBox.Text;
            Settings.Default.VideoWidth = VideoWidthTextBox.Text;
        }

        public async void ConvertButton_Click(object sender, EventArgs e)
        {
            // Check if the domain is valid
            if (await CheckIfDomainIsValid() == false)
            {
                return;
            }

            WordpressCodeLabel.Text = "";
            ConvertButton.Enabled = false;

            // Get the text from the clipboard
            string url = Clipboard.GetText();

            // Check if the clipboard text is already WordPress code
            if (CheckIfClipboardIsWPCode(url))
            {
                await DisplayErrorMessage(ErrorMessageWPCodeDuplicate, true);
                return;
            }

            // Attempt to convert the Twitch URL
            AttemptToConvertTwitchURL(url);
        }

        public bool CheckIfClipboardIsWPCode(string clipboard)
        {
          return !string.IsNullOrEmpty(clipboard) && clipboard == wordpressCode;
        }

        public async Task<bool> CheckIfDomainIsValid()
        {
            string domainURL = DomainTextBox.Text;
            string rootDomainURL = GetRootDomainURL(domainURL);

            if (Uri.CheckHostName(rootDomainURL) == UriHostNameType.Unknown)
            {
                await DisplayErrorMessage(ErrorMessageNotValidDomain, false);
                return false;
            }

            DomainTextBox.Text = rootDomainURL;
            SaveFieldValuesToSettings();
            return true;
        }

        private string GetRootDomainURL(string domainURL)
        {
            if (domainURL.StartsWith("www."))
            {
                return domainURL.Substring(0, domainURL.LastIndexOf("/"));
            }
            else if (domainURL.StartsWith("http"))
            {
                string noProtocolDomainURL = domainURL.Substring(domainURL.IndexOf("w"));
                return noProtocolDomainURL.Substring(0, noProtocolDomainURL.LastIndexOf("/"));
            }
            else
            {
                return "www." + domainURL;
            }
        }

        public async Task AttemptToConvertTwitchURL(string url)
        {
            if (!IsValidTwitchURL(url))
            {
                await DisplayErrorMessage(ErrorMessageNotTwitchURL, true);
                return;
            }

            string trimmedTwitchURL = TrimTwitchURL(url);
            wordpressCode = BuildWordpressCode(trimmedTwitchURL);
            DisplayWordpressCode(wordpressCode);
        }

        private bool IsValidTwitchURL(string url)
        {
            return url.Contains("https://clips.twitch.tv/") ||
                  (url.Contains("https://www.twitch.tv/") && url.Contains("/clip/"));
        }

        private string TrimTwitchURL(string url)
        {
            string trimmedURL = url.Substring(url.LastIndexOf("/") + 1);
            int indexOfQuestionMark = trimmedURL.IndexOf("?");
            if (indexOfQuestionMark >= 0)
            {
                trimmedURL = trimmedURL.Substring(0, indexOfQuestionMark);
            }

            return trimmedURL;
        }

        public string BuildWordpressCode(string url)
        {
            return
                $"<pre class=\"wp-block-code\"><div id=\"iframe-wrapper\" align=\"center\">" +
                $"<iframe src=\"https://clips.twitch.tv/embed?clip=" +
                $"{url}&amp;parent={DomainTextBox.Text}\" " +
                $"allowfullscreen=\"true\" scrolling=\"no\" width=\"{VideoWidthTextBox.Text}\" height=\"{VideoHeightTextBox.Text}\" " +
                $"frameborder=\"0\"></iframe></div></pre>";
        }

        public void DisplayWordpressCode(string code)
        {
            StatusLabel.Text = "Conversion Completed";
            StatusLabel.ForeColor = Color.Green;
            WordpressCodeLabel.Text = code;
            Clipboard.SetText(code);
            ConvertButton.Enabled = true;
        }

        public async Task DisplayErrorMessage(string errorMessage, bool showClipboard)
        {
            StatusLabel.ForeColor = Color.Red;
            StatusLabel.Text = errorMessage;
            if (showClipboard)
            {
                WordpressCodeLabel.Text = Clipboard.GetText();
            }
            await Task.Delay(2500);
            WordpressCodeLabel.Text = "";
            StatusLabel.Text = "Ready to Convert";
            StatusLabel.ForeColor = Color.Black;
            ConvertButton.Enabled = true;
        }

        public async void VideoDimensionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                await DisplayErrorMessage(errorMessage, false);
            }
            if (e.KeyChar == (char)8) e.Handled = false; // Allows backspacing
        }
    }
}
