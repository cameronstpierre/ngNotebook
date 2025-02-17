namespace ngNotebook.ViewModels;

// Properties
public sealed partial class SectionViewModel : ViewModelBase
{
    public Section? Section { get; set; }
    public ObservableCollection<PageViewModel> Pages { get; } = [];
    
    private PageViewModel? _selectedPage;
    public PageViewModel? SelectedPage
    {
        get => _selectedPage;
        set
        {
            if (_selectedPage != value)
            {
                _selectedPage = value != null ? new PageViewModel(value.Page) : null;
                OnPropertyChanged();
            }
        }
    }

}

// Constructor
public sealed partial class SectionViewModel
{
    public SectionViewModel()
    {
        
    }
    
    public SectionViewModel(Section section)
    {
        Section = section;

        // Convert each `Page` to `PageViewModel`
        foreach (var page in section.Pages)
        {
            Pages.Add(new PageViewModel(page));
        }

        SelectedPage = Pages.FirstOrDefault();
    }
}

// Methods
public sealed partial class SectionViewModel
{
    public void AddPage()
    {
        var newPage = new Page
        {
            Title = "New Page",
            Content = string.Empty
        };

        var newPageViewModel = new PageViewModel(newPage);
        Pages.Add(newPageViewModel);
    }

    public void RemovePage(PageViewModel pageViewModel)
    {
        Pages.Remove(pageViewModel);
    }

    public void RenamePage(PageViewModel pageViewModel, string newName)
    {
        if (Pages.Contains(pageViewModel))
        {
            pageViewModel.Title = newName;
        }
    }

}
