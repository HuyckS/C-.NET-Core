#pragma checksum "C:\Users\Spence\Desktop\CodingDojo\C#\assignments\Random_Passcode\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9681bc1e9fd3c9f07d4e489de3f336ed4bb244b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Spence\Desktop\CodingDojo\C#\assignments\Random_Passcode\Views\_ViewImports.cshtml"
using Random_Passcode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Spence\Desktop\CodingDojo\C#\assignments\Random_Passcode\Views\_ViewImports.cshtml"
using Random_Passcode.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9681bc1e9fd3c9f07d4e489de3f336ed4bb244b9", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c71844c139a9880f81304e16fe6af07b63649ef0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Spence\Desktop\CodingDojo\C#\assignments\Random_Passcode\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Random Passcode (passcode #");
#nullable restore
#line 7 "C:\Users\Spence\Desktop\CodingDojo\C#\assignments\Random_Passcode\Views\Home\Index.cshtml"
                                                Write(ViewBag.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</h1>\r\n    <div class=\"passcode\">\r\n        <p>");
#nullable restore
#line 9 "C:\Users\Spence\Desktop\CodingDojo\C#\assignments\Random_Passcode\Views\Home\Index.cshtml"
      Write(ViewBag.Pass);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <button><a href=\"/\">Generate</a></button>\r\n\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
