namespace ngNotebook.ViewModels;

// Properties
public partial class MainWindowViewModel : ViewModelBase
{
    public SectionViewModel? SelectedSection { get; set; }
    public ObservableCollection<SectionViewModel>? Sections { get; set; }
}

// Constructor
public partial class MainWindowViewModel
{
    public MainWindowViewModel()
    {
        Sections =
        [
            new SectionViewModel(new Section
            {
                FilePath = @"C:\Projects\ngNotebook Data\Work",
                Name = "Work",
                Pages = [
                    new Page
                    {
                        FilePath = @"C:\Projects\ngNotebook Data\Work\Page 1.txt",
                        Title = "Page 1",
                        Content = "This is content"
                    },
                    new Page
                    {
                        FilePath = @"C:\Projects\ngNotebook Data\Work\Page 2.txt",
                        Title = "Page 2",
                        Content = "This is [poop"
                    },
                ]
            }),
           
        ];

        SelectedSection = Sections.FirstOrDefault();

        //TODO Load Last Notebook
        LoadNotebook();
    }
}

// Methods
public partial class MainWindowViewModel
{
    private void LoadNotebook()
    {
        Sections = [];        
        
        // get all directories in notebook path
        try
        {
            var tempSections = Directory.GetDirectories(@"C:\Projects\ngNotebook Data");
            for (var i = 0; i < tempSections.Length; i++)
            {
                // Create Section and its pages
                var section = new SectionViewModel();

                section.Section = new Section();
                section.Section.FilePath = tempSections[i];
                section.Section.Name = Path.GetFileName(tempSections[i]);
                
                var pages = Directory.GetFiles(tempSections[i]);
                for (var j = 0; j < pages.Length; j++)
                {
                    var tempPage = new PageViewModel();
                    tempPage.Title = Path.GetFileNameWithoutExtension(pages[j]);
                    section.Pages.Add(tempPage);
                }
                
                Sections?.Add(section);
            }
        }
        catch (Exception ex)
        {
            var t = "";
        }
    }
}