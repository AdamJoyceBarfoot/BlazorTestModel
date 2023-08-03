using BlazorTestModel.Client.Shared;
using BlazorTestModel.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorTestModel.Client.Pages
{
    public partial class Index
    {
        private DirectorsLetterViewModel _viewModel = new();

        [Inject] public IDialogService DialogService { get; set; }

        private async Task EmailRowClick(TableRowClickEventArgs<DirectorsLetter> tableRowClickEventArgs)
        {
            // Create parameters for the EditEmailDialog component, assign the selected DirectorsLetter object
            var parameters = new DialogParameters<EditEmailDialog> { { x => x.DirectorsLetter, tableRowClickEventArgs.Item } };

            // Create a dialog instance and show it
            IDialogReference dialogReference = await DialogService.ShowAsync<EditEmailDialog>("Edit email dialog", parameters);

            // Get the result from the dialog
            var result = await dialogReference.Result;

            // Check if the user clicked 'update'. This is where we'd update the API and mark the record as changed
            if (!result.Canceled)
            {
                // Refresh this component to show any changes
                StateHasChanged();

                // If we were using an email/PDF dialog mark the record as processed and animate its removal from the table
                tableRowClickEventArgs.Item.Processed = true;
            }
        }
    }
}
