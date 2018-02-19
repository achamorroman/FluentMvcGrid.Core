using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentMvcGrid.Core
{
    public static class HtmlExtensions
    {
        public static FluentMvcGrid<T> FluentMvcGrid<T>(this IHtmlHelper helper, IEnumerable<T> items, Uri requestUrl)
        {
            var fluentGrid = new FluentMvcGrid<T>(items, requestUrl);
            Debug.Print(fluentGrid.ToString());
            return fluentGrid;
        }
    }
}