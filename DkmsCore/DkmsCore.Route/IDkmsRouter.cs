using Microsoft.AspNetCore.Http;
using System;

namespace DkmsCore.Route
{
    public interface IDkmsRouter
    {
        DkmsRoute Route(HttpContext context);
    }
}
