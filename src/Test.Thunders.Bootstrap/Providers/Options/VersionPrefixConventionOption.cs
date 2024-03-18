using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Test.Thunders.Bootstrap.Providers.Options;

[ExcludeFromCodeCoverage]
public class VersionPrefixConventionOption : IApplicationModelConvention
{
    private const string VERSION_PREFIX_TEMPLATE = "api/v{version:apiVersion}";
    private readonly AttributeRouteModel _routePrefix = new(new RouteAttribute(VERSION_PREFIX_TEMPLATE));

    public void Apply(ApplicationModel application)
    {
        foreach (var selector in application.Controllers.SelectMany(c => c.Selectors))
        {
            if (selector.AttributeRouteModel == null)
            {
                selector.AttributeRouteModel = _routePrefix;
            }
            else if (!selector.AttributeRouteModel.Template.Contains("{version:"))
            {
                selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_routePrefix, selector.AttributeRouteModel);
            }
        }
    }
}