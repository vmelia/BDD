using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp2.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private readonly IConnectivity _connectivity;
    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        _connectivity = connectivity;
    }

    [ObservableProperty] private ObservableCollection<string> _items;

    [ObservableProperty] private string _text;

    partial void OnTextChanged(string value)
    {
        AddCommand.NotifyCanExecuteChanged();
    }

    public bool IsTextValid => !string.IsNullOrWhiteSpace(Text) && !Items.Contains(Text);

    [RelayCommand(CanExecute = nameof(IsTextValid))]
    private async Task Add()
    {
        if(_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
            return;
        }

        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    private void Delete(string s)
    {
        if(Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    private async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}