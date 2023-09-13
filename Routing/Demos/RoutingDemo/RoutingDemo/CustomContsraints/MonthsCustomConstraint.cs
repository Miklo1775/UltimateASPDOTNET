using System.Text.RegularExpressions;

namespace RoutingDemo.CustomContsraints
{
    //sales-report/2020/apr
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //CHECK WHETHER THE VALUE EXISTS
            if (!values.ContainsKey(routeKey)) //month
            {
                return false; //not a match
            }

            Regex monthsRegex = new("^(apr|jul|oct|jan)$");

            string? monthValue = Convert.ToString(values[routeKey]);

            if(monthsRegex.IsMatch(monthValue))
            {
                return true; //it's a match
            }

            return false;
        }
    }
}
