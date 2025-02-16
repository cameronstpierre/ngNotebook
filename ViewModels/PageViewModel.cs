namespace ngNotebook.ViewModels;

// Properties
public sealed partial class PageViewModel : ViewModelBase
{
    private Page _page;
    
    public string? Title { get; set; }
    public string? Content { get; set; }
}

// Constructor
public sealed partial class PageViewModel
{
    public PageViewModel(Page page)
    {
        _page = page;
        Title = _page.Title;
        Content = _page.Content;
    }
}

// Methods
public sealed partial class PageViewModel
{
    
}