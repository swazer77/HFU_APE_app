using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLZ2025.Core.Model;
using MLZ2025.Core.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MLZ2025.Core.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private readonly IConnectivity _connectivity;
    private readonly IDialogService _dialogService;
    private readonly DataAccessService<DatabaseAddress> _dataAccessService;
    private readonly IHttpServerAccess _httpServerAccess;

    // TODO Use a custom object instead.
    [ObservableProperty] private ObservableCollection<DatabaseAddress> _items;

    [ObservableProperty] private string firstName = string.Empty;
    [ObservableProperty] private string lastName = string.Empty;
    [ObservableProperty] private string zipCode = string.Empty;
    [ObservableProperty] private DateOnly birthday = DateOnly.FromDateTime(DateTime.Now);

    [ObservableProperty] private string _text = "Something";

    public MainViewModel(IConnectivity connectivity, IDialogService dialogService, DataAccessService<DatabaseAddress> dataAccess, IHttpServerAccess httpServerAccess)
    {
        _connectivity = connectivity;
        _dialogService = dialogService;
        _dataAccessService = dataAccess;
        _httpServerAccess = httpServerAccess;


        /*
        // TODO Map all properties from the address to the UI
        var firstNames = _dataAccessService.Table().Select(address => address.FirstName).ToList();

        if (firstNames.Count == 0)
        {
            
            // TODO Stop using the GetAwaiter().GetResult() pattern.
            var serverAddresses = _httpServerAccess.GetAddressesAsync().GetAwaiter().GetResult();
            firstNames = serverAddresses.Select(address => address.FirstName).ToList();
            
        }

        _items = new ObservableCollection<string>(firstNames);

        */

    }

    [RelayCommand]
    private async Task Add()
    {

        if (await ValidateText(firstName))
        {
            var d = new DatabaseAddress()
            {
                FirstName = firstName,
                LastName = lastName,
                ZipCode = zipCode,
                BirthDate = birthday
            };

            Items.Add(d);
            _dataAccessService.Insert(d);

        }
    }

    [RelayCommand]
    private async Task Delete(string item)
    {
        if (await ValidateText(item))
        {
            if (!Items.Remove(item))
            {
                Debug.WriteLine($"Cannot remove {item} because it is not in the list.");
            }
        }
    }

    [RelayCommand]
    private async Task Select(string item)
    {
        if (await ValidateText(item))
        {
            // TODO Use the dictionary instead.
            // Figure out how to test the Shell <https://software-engineering-corner.zuehlke.com/how-to-test-a-net-maui-app-part-1#heading-testing-of-a-view-model>
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailViewModel.Text)}={item}");
        }
    }

    private async Task<bool> ValidateText(string text)
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await _dialogService.ShowErrorMessage("No Internet. Please check your internet connection.");

            return false;
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            await ShowEmptyTextErrorMessage();

            // TODO Use a logger instead.
            Debug.WriteLine("Text is empty");

            return false;
        }

        return true;
    }

    private async Task ShowEmptyTextErrorMessage()
    {
        await _dialogService.ShowErrorMessage("Please enter a text");
    }
}
