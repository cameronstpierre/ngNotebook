namespace ngNotebook.Models;

public sealed class Section
{
    public string? Name { get; set; }
    public ObservableCollection<Page> Pages { get; set; } = [];
}