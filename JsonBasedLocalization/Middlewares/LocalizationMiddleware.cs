﻿using System.Globalization;

namespace JsonBasedLocalization.Middlewares
{
    public class LocalizationMiddleware:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var cultureKey = context.Request.Headers["Accept-Language"];
            if(!string.IsNullOrEmpty(cultureKey))
            {
                if (DoesCultureExist(cultureKey))
                {
                    var culture = new System.Globalization.CultureInfo(cultureKey);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }
            await next(context);
        }
        private bool DoesCultureExist(string cultureName)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures).Any(culture=>string.Equals(cultureName, cultureName,
                StringComparison.CurrentCultureIgnoreCase));
        }

    }
}
