using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentMvcGrid.Core
{
    public static class HtmlExtensions
    {
        public static FluentMvcGrid<T> FluentMvcGrid<T>(this IHtmlHelper helper, IEnumerable<T> items, Uri requestUrl)
        {
            return new FluentMvcGrid<T>(items, requestUrl);
        }

        public static MyFluent MyFluent(this IHtmlHelper helper, string saludo)
        {
            return new MyFluent(saludo);
        }
    }


    public class MyFluent : IHtmlContent
    {
        private readonly string _saludo;
        private string _name;
        private string _surname;

        public MyFluent(string saludo)
        {
            _saludo = saludo;
        }

        public MyFluent AddName(string name)
        {
            _name = name;
            return this;
        }

        public MyFluent AddSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public IHtmlContent Build()
        {
            var p = new TagBuilder("p");
            p.InnerHtml.AppendHtml(string.Format("{0}, {1} {2}", _saludo, _name, _surname));
            return p;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            //Build();
        }
    }
}