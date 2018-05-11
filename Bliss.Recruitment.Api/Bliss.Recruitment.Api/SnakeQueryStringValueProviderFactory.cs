using Bliss.Recruitment.Common.Extensions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace Bliss.Recruitment.Api
{
    public class SnakeQueryStringValueProviderFactory : QueryStringValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            var pairs = actionContext.ControllerContext.Request.GetQueryNameValuePairs()
                .Select(x => new KeyValuePair<string, string> (x.Key.ToCamelCase(), x.Value));

            return new NameValuePairsValueProvider(pairs, CultureInfo.InvariantCulture);
        }

    }
    
}