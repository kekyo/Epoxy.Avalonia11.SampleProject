namespace Epoxy.Avalonia11.SampleProject.ViewModels;

[ViewModel]
public class MainViewModel
{
    public MainViewModel()
    {
        this.Greeting = "Welcome to Avalonia!";
    }

#pragma warning disable CA1822 // Mark members as static
    public string Greeting { get; }
#pragma warning restore CA1822 // Mark members as static
}
