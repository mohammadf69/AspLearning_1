namespace AspLearning_1.Extensions;

public class CustomeConstraint:IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        throw new NotImplementedException();
    }
}