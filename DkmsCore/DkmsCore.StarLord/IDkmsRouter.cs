using Microsoft.AspNetCore.Http;
using System;

namespace DkmsCore.StarLord
{
    public interface IDkmsRouter
    {
        DkmsRoute Route(HttpContext context);
    }
}
