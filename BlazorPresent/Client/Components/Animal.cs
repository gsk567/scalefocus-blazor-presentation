using Microsoft.AspNetCore.Components;

namespace BlazorPresent.Client.Components
{
    public class Animal : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }
    }
}
