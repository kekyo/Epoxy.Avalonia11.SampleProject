using Avalonia.Controls;
using System.Threading.Tasks;

namespace Epoxy.Avalonia11.SampleProject.ViewModels;

[ViewModel]
public class MainViewModel
{
    public MainViewModel()
    {
        this.MainViewWell.Add(Control.LoadedEvent, () =>
        {
            this.EnteringTextLength = 0;
            return default;
        });
    }

    [PropertyChanged(nameof(EnteringText))]
    private ValueTask OnEnteringTextChangedAsync(string newText)
    {
        this.EnteringTextLength = newText.Length;
        return default;
    }

#pragma warning disable CA1822 // Mark members as static
    public Well<UserControl> MainViewWell { get; } = Well.Factory.Create<UserControl>();
    
    public string EnteringText { get; set; } = "";
    public int EnteringTextLength { get; private set; }
#pragma warning restore CA1822 // Mark members as static
}
