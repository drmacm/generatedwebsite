using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace PDFiller.Website.Services
{
    public static class SpinnerUtil
    {
        public static ValueTask ShowSpinner(this IJSRuntime js)
        {
            return js.InvokeVoidAsync("showSpinner");
        }
        public static ValueTask HideSpinner(this IJSRuntime js)
        {
            return js.InvokeVoidAsync("hideSpinner");
        }
    }
}