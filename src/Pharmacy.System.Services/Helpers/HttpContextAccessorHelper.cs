using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;

namespace Pharmacy.System.Services.Helpers
{
    public static class HttpContextAccessorHelper
    {
        public static string GetRequiredUserId(this HttpContext context)
        {
            var userId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                throw new UnauthorizedAccessException("Unauthorized User");

            return userId;
        }

    }
}
