using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace MyCookbook.Api.Controllers.ViewModel
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string messenge, ValueEnumerable errors)
        {
            Messenge = messenge;
            Errors = errors;
        }

        public string Messenge { get; set; }

        public ValueEnumerable Errors { get; set; }
    }
}
