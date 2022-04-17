
using StoreYx.Data;

namespace StoreYx.Lib
{
    public class CmsUrlConstraint : IRouteConstraint
    {
        private readonly WebApplication _app;

        public CmsUrlConstraint(WebApplication app)
        {
            _app = app;
        }


        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            using (var scope = _app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var db = new ApplicationDbContext(services.GetRequiredService<Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>>());


                if (values[routeKey] != null)
                {
                   // System.Diagnostics.Debug.WriteLine("==============CmsUrlConstraint===" + values[routeKey].ToString());
                    var permalink = "/" + values[routeKey].ToString();
                    if (permalink.EndsWith('/'))
                    {
                        permalink = permalink.Remove(permalink.Length - 1);
                       // System.Diagnostics.Debug.WriteLine("==============permalink===" + permalink);
                    }


                    var page = db.Page.Where(p => p.Path == permalink).FirstOrDefault();
                    if (page != null)
                    {
                        httpContext.Items["cmspage"] = page;
                        return true;
                    }


                    return false;
                }
            }
            return false;
        }
    }
}
