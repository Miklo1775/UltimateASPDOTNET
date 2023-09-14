namespace CountriesDemo.CustomConstraints
{
    public class CountryIDConstraintClass : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(!values.ContainsKey(routeKey)) return false;

            int countryID = Convert.ToInt32(values[routeKey]);

            if(countryID < 1 || countryID > 100)
            {
                return true;
            }

            return false;
        }
    }
}
