using BlazorTestModel.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorTestModel.Client.Shared
{
    public partial class EditEmailDialog : IDisposable
    {
        private DirectorsLetter _model;

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        [EditorRequired]
        public DirectorsLetter DirectorsLetter { get; set; }

        protected override void OnInitialized()
        {
            _model = new DirectorsLetter();
        }

        protected override void OnParametersSet()
        {
            // Keep a local copy of parameters, recommendation from MS on blazor properties
            _model = DirectorsLetter;
        }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

        public void Dispose()
        {
            // Component is disposed of when used in Dialog instance, cleaning up reference to object provided as parameter
            MudDialog.Dispose();
        }
    }
}
