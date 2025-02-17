namespace ngNotebook.Models;

public sealed class Section
{
    public string? FilePath { get; set; }
    public string? Name { get; set; }
    public ObservableCollection<Page> Pages { get; set; } = [];
}