using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Extensions
{
    static class UriBuilderExtensions
    {
        public static void AppendQuery(this UriBuilder uriBuilder, string key, string value = "")
        {
            var escapedKey = Uri.EscapeDataString(key);
            var escapedValue = string.IsNullOrEmpty(value) ? "" : $"={Uri.EscapeDataString(value)}";
            var queryToAppend = $"{escapedKey}{escapedValue}";
            if (uriBuilder.Query != null && uriBuilder.Query.Length > 1)
            {
                uriBuilder.Query = uriBuilder.Query.Substring(1) + "&" + queryToAppend;
            }
            else
            {
                uriBuilder.Query = queryToAppend;
            }
        }
    }
}
