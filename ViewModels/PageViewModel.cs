namespace ngNotebook.ViewModels;

// Properties
public sealed partial class PageViewModel : ViewModelBase
{
    private readonly DispatcherTimer? _saveTimer;
    private readonly DispatcherTimer? _autosaveTimer;
    
    private Page _page;
    public Page Page
    {
        get => _page;
        set
        {
            _page = value;
            OnPropertyChanged();
        }
    }
    
    public string? Title { get; set; }

    private string? _content;
    public string? Content
    {
        get => _content;
        set
        {
            _content = value;
            OnPropertyChanged();

            if (_content is not null)
            {
                _saveTimer?.Stop();
                _saveTimer?.Start();
            }
        }
    }
}

// Constructor
public sealed partial class PageViewModel
{
    public PageViewModel()
    {
        
    }
    
    public PageViewModel(Page page)
    {
        _page = page;
        Title = _page.Title;
        Content = _page.Content;
        
        _saveTimer = new DispatcherTimer();
        _saveTimer.Interval = new TimeSpan(0, 0, 1);
        _saveTimer.Tick += async (_, _) => await SaveContentAsync(_content);
    }
}

// Methods
public sealed partial class PageViewModel
{
    private string? ReadContentAsync(string? filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex)
        {
            
        }
        
        return null;
    }
    
    private async Task SaveContentAsync(string? content)
    {
        var tempFileName = Path.GetFileNameWithoutExtension(_page.Title);
        var tempFilePath = $"{Path.GetDirectoryName(_page.FilePath)}\\{tempFileName}.temp";
        
        try
        {
            // Write the content to the temporary file
            await File.WriteAllTextAsync(tempFilePath, content);

            // Replace the contents of the main file with the ones from the temporary file
            File.Replace(tempFilePath, _page.FilePath, null);
            
            // Stop the save timer to avoid an endless loop
            _saveTimer?.Stop();
        }
        catch (Exception ex)
        {
            //
            var t = "";
        }
    }
}