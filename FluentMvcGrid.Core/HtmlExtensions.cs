using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FluentMvcGrid.Core
{
    public static class HtmlExtensions
    {
        public static FluentMvcGrid<T> FluentMvcGrid<T>(this HtmlHelper helper, IEnumerable<T> items, Uri requestUrl)
        {
            return new FluentMvcGrid<T>(items, requestUrl);
        }
    }
}