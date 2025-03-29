using Microsoft.Extensions.Localization;
using System.Reflection;

namespace AngielskiNauka.Resources
{
    public class LocService
    {
        private readonly IStringLocalizer _localizer;

        public LocService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString Get(string key)
        {
            var result = _localizer[key];
            return result;
        }
    }
}
