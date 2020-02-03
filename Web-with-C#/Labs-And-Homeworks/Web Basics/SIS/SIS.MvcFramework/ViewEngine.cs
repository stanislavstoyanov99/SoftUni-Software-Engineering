namespace SIS.MvcFramework
{
    using System;
    using System.Text;

    public class ViewEngine : IViewEngine
    {
        public string GetHtml(string templateHtml, object model)
        {
            var methodCode = PrepareCSharpCode(templateHtml);
            var code = @$"using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using SIS.MvcFramework;
namespace AppViewNamespace
{{
    public class AppViewCode : IView
    {{
        public string GetHtml(object model)
        {{
            var html = new StringBuilder();

            {methodCode}

            return html.ToString();
        }}
    }}
}}";
            IView view = GetInStanceFromCode(code, model);
            string html = view.GetHtml(model);
            return html;
        }

        private IView GetInStanceFromCode(string code, object model)
        {
            // TODO
            throw new NotImplementedException();
        }

        private string PrepareCSharpCode(string templateHtml)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
