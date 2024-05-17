using Avalonia.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Epoxy.Avalonia11.SampleProject.ViewModels;

[ViewModel]
public class MainViewModel
{
    public MainViewModel()
    {
        this.MainViewWell.Add(Control.LoadedEvent, () =>
        {
            this.EnteringText = "Enter your text";
            return default;
        });

        this.FireAdd = Command.Factory.Create(() =>
        {
            var item = new ItemViewModel
            {
                Text = this.EnteringText,
            };
            this.Items.Add(item);

            return default;
        });

        this.FireRemove = Command.Factory.Create(() =>
        {
            this.Items.RemoveAt(this.SelectedIndex);
            return default;
        });
    }

    [PropertyChanged(nameof(EnteringText))]
    private ValueTask OnEnteringTextChangedAsync(string newText)
    {
        this.EnteringTextLength = newText.Length;
        return default;
    }

    [PropertyChanged(nameof(SelectedIndex))]
    private ValueTask OnSelectedIndexChangedAsync(int newIndex)
    {
        this.CanRemove = newIndex >= 0;
        return default;
    }

#pragma warning disable CA1822 // Mark members as static
    public Well<UserControl> MainViewWell { get; } = Well.Factory.Create<UserControl>();
    public Command FireAdd { get; }
    public Command FireRemove { get; }

    public bool CanRemove { get; private set; }
    public int SelectedIndex { get; set; }
    public string EnteringText { get; set; } = "";
    public int EnteringTextLength { get; private set; }
    public ObservableCollection<ItemViewModel> Items { get; } = new();
#pragma warning restore CA1822 // Mark members as static
}

[ViewModel]
public class ItemViewModel
{
    public string? Text { get; set; }
}
