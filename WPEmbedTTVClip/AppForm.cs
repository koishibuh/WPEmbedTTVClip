using WPEmbedClipCode;
namespace URLConvert;

public partial class AppForm : Form
{
    // == ⚫ FIELDS & PROPERTIES == //

    string WordPressCode = "";
    const string WPCodeDuplicate_ErrorMessage = "Wordpress Code already copied to clipboard";
    const string NotTwitchURL_ErrorMessage = "Not a proper Twitch clip URL";
    const string NotValidDomain_ErrorMessage = "Not a valid Domain";
    const string ReadyStatus_Message = "Ready to convert Twitch Link in clipboard";
    const string CompletedStatus_Message = "Success! WP code copied to clipboard";
    const string WPCodeCopiedAgain_Message = "WP code copied to clipboard again";
    const string HowTo_Message = "1. Set your site domain (ex: https://www.name.com)\n" +
                          "2. Set desired video width and height\n" +
                          "3. Copy Twitch Link to clipboard\n" +
                          "4. Click convert button\n" +
                          "5. WP embed code will be copied to clipboard";


    // == ⚪ APP START UP & SHUT DOWN == //

    public AppForm()
    {
        InitializeComponent();
        InitializeAppForm();
    }

    public void InitializeAppForm()
    {
        DomainTextBox.Text = Settings.Default.Domain;
        VideoHeightBox.Value = Settings.Default.VideoHeight;
        VideoWidthBox.Value = Settings.Default.VideoWidth;
        StatusLabel.Text = ReadyStatus_Message;
        HowToLabel.Text = HowTo_Message;
        VideoWidthBox.Controls[0].Hide();
        VideoHeightBox.Controls[0].Hide();

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
        Settings.Default.VideoHeight = VideoHeightBox.Value;
        Settings.Default.VideoWidth = VideoWidthBox.Value;
    }

    // == ⚫ VIDEO DIMENSION FIELDS == //

    private void VideoWidthTextBox_TextChanged(object sender, EventArgs e)
    {
        Decimal videoWidth = VideoWidthBox.Value;
        VideoHeightBox.Value = Decimal.Round(videoWidth / (16m / 9m));

    }

    private void VideoHeightTextBox_TextChanged(object sender, EventArgs e)
    {
        Decimal videoHeight = VideoHeightBox.Value;
        VideoWidthBox.Value = Decimal.Round(videoHeight * (16m / 9m));
    }

    // == ⚪ CONVERT BUTTON & METHODS == //

    public async void ConvertButton_Click(object sender, EventArgs e)
    {
        if (DomainTextBox.Text != Settings.Default.Domain)
        {
            bool isValid = await CheckIsDomainValid();
            if (isValid == false) return;
        }    

        WordpressCodeLabel.Text = "";
        HowToLabel.Visible = false;
        ConvertButton.Enabled = false;

        string clipboardText = Clipboard.GetText();

        if (CheckIsClipboardWPCode(clipboardText) == true)
        {
            await DisplayErrorMessage(WPCodeDuplicate_ErrorMessage, true);
            return;
        };

        ConvertTwitchURL(clipboardText);       
    }

    public bool CheckIsClipboardWPCode(string clipboard)
    {
        if (clipboard == WordPressCode)
        {
            return true;
        }
        return false;
    }
    
    public async Task<bool> CheckIsDomainValid()
    {
        string domain = DomainTextBox.Text;
        string updatedDomain;

        if (domain.StartsWith("www."))
        {
            updatedDomain = "https://" + domain;
            updatedDomain = RemoveURLPath(updatedDomain);
        }
        else if (domain.StartsWith("http") && !domain.StartsWith("https"))
        {
            updatedDomain = domain.Insert(4, "s");
            updatedDomain = RemoveURLPath(updatedDomain);
        }
        else if (!domain.StartsWith("https://www."))
        {
            updatedDomain = "https://www." + domain;
            updatedDomain = RemoveURLPath(updatedDomain);
        }
        else
        {
            updatedDomain = RemoveURLPath(domain);
        }
        
        DomainTextBox.Text = updatedDomain;

        bool isValid = await CheckIsValidDomainURL(updatedDomain);
        if (isValid == false)
        {
            return false;
        }
        
        SaveFieldValuesToSettings();
        return true;
    }

    public string RemoveURLPath(string domain)
    {
        int indexOfLastSlash = domain.LastIndexOf("/");

        if (domain.Contains("/") && indexOfLastSlash > 8)
        {
            return domain.Substring(0, indexOfLastSlash);
        }
        else
        {
            return domain;
        }
    }

    public async Task<bool> CheckIsValidDomainURL(string domain)
    {     
        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        try
        {
            response = await client.GetAsync(domain);
            if (response.IsSuccessStatusCode)
            {
                client.Dispose();
                return true;
            }
            else
            {
                await DisplayErrorMessage(NotValidDomain_ErrorMessage, false);
                return false;
            }
        }
        catch
        {
            await DisplayErrorMessage(NotValidDomain_ErrorMessage, false);
            return false;
        }
    }  

    public async Task ConvertTwitchURL(string url)
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
            await DisplayErrorMessage(NotTwitchURL_ErrorMessage, true);
            return;
        }

        WordPressCode = BuildWordpressCode(trimmedTwitchURL);

        DisplayWordpressCode(WordPressCode);
    }

    public string BuildWordpressCode(string url)
    {
        string simpleURL = DomainTextBox.Text.Substring(DomainTextBox.Text.LastIndexOf('/') + 1);

        return 
            $"<pre class=\"wp-block-code\"><center><div id=\"iframe-wrapper\">" +
            $"<iframe src=\"https://clips.twitch.tv/embed?clip=" +
            $"{url}&amp;parent={simpleURL}\" " +
            $"allowfullscreen=\"true\" scrolling=\"no\" width=\"{VideoWidthBox.Value}\" height=\"{VideoHeightBox.Value}\" " +
            $"frameborder=\"0\"></iframe></div></center></pre>";
    }

    public void DisplayWordpressCode(string code)
    {
        StatusLabel.Text = CompletedStatus_Message;
        WordpressCodeLabel.Text = code;
        Clipboard.SetText(code);
        ConvertButton.Enabled = true;
        CopyLastWPCodeButton.Enabled = true;
    }

    public async Task DisplayErrorMessage(string errorMessage, bool showClipboard)
    {
        StatusLabel.ForeColor = Color.Red;
        StatusLabel.Text = errorMessage;
        if ( errorMessage == NotValidDomain_ErrorMessage)
        {
            DomainLabel.ForeColor= Color.Red;
            DomainTextBox.BackColor= Color.Red;
        }    
        if ( showClipboard == true ) 
        {
            WordpressCodeLabel.Text = "Attempted to convert: " + Clipboard.GetText();
        }
        await Task.Delay(2500);
        ResetUIValues();
    }

    public void ResetUIValues()
    {
        WordpressCodeLabel.Text = "";
        StatusLabel.ForeColor = Color.Green;
        StatusLabel.Text = ReadyStatus_Message;
        DomainLabel.ForeColor = Color.Black;
        DomainTextBox.BackColor = Color.White;
        HowToLabel.Visible = true;
        ConvertButton.Enabled = true;
    }

    private void WordpressCodeLabel_MouseClick(object sender, MouseEventArgs e)
    {
        Clipboard.SetText(WordPressCode);
        StatusLabel.Text = WPCodeCopiedAgain_Message;
    }

    private async void CopyLastWPCodeButton_Click(object sender, EventArgs e)
    {
        HowToLabel.Visible = false;
        Clipboard.SetText(WordPressCode);
        StatusLabel.Text = WPCodeCopiedAgain_Message;
        WordpressCodeLabel.Text = WordPressCode;
        await Task.Delay(2500);
        ResetUIValues();
    }
}