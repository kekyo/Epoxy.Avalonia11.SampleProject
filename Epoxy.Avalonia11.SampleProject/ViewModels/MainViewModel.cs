using Avalonia.Controls;

namespace Epoxy.Avalonia11.SampleProject.ViewModels;

[ViewModel]
public class MainViewModel
{
    public MainViewModel()
    {
        this.MainViewWell.Add(Control.LoadedEvent, () =>
        {
            this.Greeting = "Welcome to Avalonia!";
            return default;
        });
    }

#pragma warning disable CA1822 // Mark members as static
    public string? Greeting { get; private set; }

    public Well<UserControl> MainViewWell { get; } = Well.Factory.Create<UserControl>();
#pragma warning restore CA1822 // Mark members as static
}
