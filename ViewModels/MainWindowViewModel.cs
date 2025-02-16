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
            new SectionViewModel(new Section { Name = "Math", Pages = [new Page { Title = "Page 1", Content = ";l'amsd posdanf gdm afpodsafong polin a 1" }] }),
            new SectionViewModel(new Section { Name = "Science", Pages = [new Page { Title = "Page 1", Content = "Content 1" }, new Page { Title = "Page 2", Content = "fdygjtyj 1" }] }),
            new SectionViewModel(new Section { Name = "History", Pages = [new Page { Title = "Page 1", Content = "gseg0945iokndfokinerg 1" }, new Page { Title = "Page 2", Content = "54651695841 1" }, new Page { Title = "Page 3", Content = "pokmdsfg65987b56d1fb854g984er9tr8g49e8rgt4 1" }] })
        ];

        SelectedSection = Sections.FirstOrDefault();

        //TODO Load Last Notebook

    }
}

// Methods
public partial class MainWindowViewModel
{
    
}