using System;
using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
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
            SaveFieldValuesToSettings();
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
            //TODO: CheckIfDomainHasChanged
            bool isValid = await CheckIfDomainIsValid();
            if (isValid == true)
            {
                WordpressCodeLabel.Text = "";
                ConvertButton.Enabled = false;
                string url = Clipboard.GetText();

                if (CheckIfClipboardIsWPCode(url) == true)
                {
                    await DisplayErrorMessage(ErrorMessageWPCodeDuplicate, true);
                    return;
                };

                AttemptToConvertTwitchURL(url);
            }
            return;     
        }

        public bool CheckIfClipboardIsWPCode(string clipboard)
        {
            //return !clipboard.StartsWith("<br>");

            if (string.IsNullOrEmpty(wordpressCode))
            {
                return false;   
            }
            else if ( clipboard == wordpressCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public async Task<bool> CheckIfDomainIsValid()
        {
            string domainURL = DomainTextBox.Text;

            if (domainURL.StartsWith("www."))
            {
                if (domainURL.Contains('/'))
                {
                    string rootDomainURL = domainURL.Substring(0, domainURL.LastIndexOf("/"));

                    DomainTextBox.Text = rootDomainURL;
                }
            }
            else if (domainURL.StartsWith("http"))
            {
                string noProtcolDomainURL = domainURL.Substring(domainURL.IndexOf("w"));

                if (noProtcolDomainURL.Contains("/"))
                {
                    string rootDomainURL = noProtcolDomainURL.Substring(0, noProtcolDomainURL.LastIndexOf("/"));
                    DomainTextBox.Text = rootDomainURL;
                }

                DomainTextBox.Text = noProtcolDomainURL;
            }
            else //TODO: Check if URL is valid 
            {
                string wwwAddedDomainURL = "www." + domainURL;
                if (Uri.CheckHostName(wwwAddedDomainURL) == UriHostNameType.Unknown)
                {
                    await DisplayErrorMessage(ErrorMessageNotValidDomain, false);
                    return false;
                }               

                DomainTextBox.Text = wwwAddedDomainURL;
            }
           
            SaveFieldValuesToSettings();
            return true;
        }

        public async Task AttemptToConvertTwitchURL(string url)
        {
            string twitchURL = url;
            string trimmedTwitchURL;            

            if (twitchURL.Contains("https://clips.twitch.tv/") || 
                (twitchURL.Contains("https://www.twitch.tv/") && twitchURL.Contains("/clip/")))
            {
                trimmedTwitchURL = twitchURL.Substring(twitchURL.LastIndexOf("/") + 1);
                if (trimmedTwitchURL.Contains('?'))
                {
                   trimmedTwitchURL = trimmedTwitchURL.Substring(0, trimmedTwitchURL.IndexOf("?"));
                }
            }
            else
            {
                await DisplayErrorMessage(ErrorMessageNotTwitchURL, true);
                return;
            }

            wordpressCode = BuildWordpressCode(trimmedTwitchURL);

            DisplayWordpressCode(wordpressCode);
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
            if ( showClipboard == true ) 
            {
                WordpressCodeLabel.Text = Clipboard.GetText();
            }
            await Task.Delay(2500);
            WordpressCodeLabel.Text = "";
            StatusLabel.Text = "Ready to Convert";
            StatusLabel.ForeColor = Color.Black;
            ConvertButton.Enabled = true;
        }

        public async void VideoHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckHeightWidthIsNumber(e);
        }

        public async void VideoWidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckHeightWidthIsNumber(e);
        }

        public async void CheckHeightWidthIsNumber(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false)
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    await DisplayErrorMessage("Numeric values only", false);
                }
            }
        }
    }
}