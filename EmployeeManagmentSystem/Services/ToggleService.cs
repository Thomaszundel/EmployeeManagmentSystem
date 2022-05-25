using EmployeeManagmentSystem.Blazor;
using Microsoft.JSInterop;

namespace EmployeeManagmentSystem.Services
{
    public class ToggleService
    {
        private List<MultiNavLink> components = new List<MultiNavLink>();
        private bool enabled = true;

        public void EnrolComponents(IEnumerable<MultiNavLink> comps)
        {
            components.AddRange(comps);
        }

        [JSInvokable]
        public bool ToggleComponents()
        {
            enabled = !enabled;
            components.ForEach(c => c.SetEnabled(enabled));
            return enabled;

        }
    }
}
