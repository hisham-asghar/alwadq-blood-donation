using System;
using System.Web;
using System.Web.Mvc;

namespace Admin
{
    /// <inheritdoc cref="" />
    /// <summary>
    /// Represents an attribute that forces an unsecured HTTP request to be re-sent over HTTPS.
    /// <see cref="T:System.Web.Mvc.RequireHttpsAttribute" /> performs a 302 Temporary redirect from a HTTP URL to a HTTPS URL. This
    /// filter gives you the option to perform a 301 Permanent redirect or a 302 temporary redirect. You should
    /// perform a 301 permanent redirect if the page can only ever be accessed by HTTPS and a 302 temporary redirect if
    /// the page can be accessed over HTTP or HTTPS. <see cref="T:System.Web.Mvc.RequireHttpsAttribute" /> also throws an
    /// <see cref="T:System.InvalidOperationException" /> if request is made except GET, which returns a 500 Internal Server
    /// Error to the client. This filter, returns a 405 Method Not Allowed instead, which is much more suitable.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
  public class RedirectToHttpsAttribute : FilterAttribute, IAuthorizationFilter
  {
    private readonly bool _permanent;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Admin.RedirectToHttpsAttribute" /> class.
    /// </summary>
    /// <param name="permanent">if set to <c>true</c> the redirection should be permanent; otherwise,
    /// <c>false</c>.</param>
    public RedirectToHttpsAttribute(bool permanent)
    {
      _permanent = permanent;
    }

    /// <summary>
    /// Gets a value indicating whether the redirection should be permanent.
    /// </summary>
    /// <value>
    /// <c>true</c> if the redirection should be permanent; otherwise, <c>false</c>.
    /// </value>
    public bool Permanent => _permanent;

      /// <inheritdoc />
      /// <summary>
      /// Determines whether a request is secured (HTTPS) and, if it is not, calls the
      /// <see cref="M:Admin.RedirectToHttpsAttribute.HandleNonHttpsRequest(System.Web.Mvc.AuthorizationContext)" /> method.
      /// </summary>
      /// <param name="filterContext">An object that encapsulates information that is required in order to use the
      /// <see cref="T:System.Web.Mvc.RequireHttpsAttribute" /> attribute.</param>
      /// <exception cref="T:System.ArgumentNullException">The <paramref name="filterContext" /> parameter is <c>null</c>.</exception>
    public virtual void OnAuthorization(AuthorizationContext filterContext)
    {
      if (filterContext == null)
        throw new ArgumentNullException(nameof (filterContext));
      if (filterContext.HttpContext.Request.IsSecureConnection)
        return;
      HandleNonHttpsRequest(filterContext);
    }

    /// <summary>
    /// Handles unsecured HTTP requests that are sent to the action method.
    /// </summary>
    /// <param name="filterContext">An object that encapsulates information that is required in order to use the
    /// <see cref="T:System.Web.Mvc.RequireHttpsAttribute" /> attribute.</param>
    /// <exception cref="T:System.Web.HttpException">The HTTP request contains an invalid transfer method override.
    /// All GET requests are considered invalid. A HTTP 405 Method Not Allowed is thrown.</exception>
    protected virtual void HandleNonHttpsRequest(AuthorizationContext filterContext)
    {
      if (!string.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
        throw new HttpException(403, "Forbidden");
      var url = "https://" + filterContext.HttpContext.Request.Url.Host + filterContext.HttpContext.Request.RawUrl;
      filterContext.Result = new RedirectResult(url, _permanent);
    }
  }
}
