#pragma checksum "/Users/fethitekyaygil/Projects/DQuiz/DQuiz.App/Views/Home/EndContest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9aa61a5194247a7b599e1e7aed38dc21f456940"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EndContest), @"mvc.1.0.view", @"/Views/Home/EndContest.cshtml")]
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
#line 1 "/Users/fethitekyaygil/Projects/DQuiz/DQuiz.App/Views/_ViewImports.cshtml"
using DQuiz.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/fethitekyaygil/Projects/DQuiz/DQuiz.App/Views/_ViewImports.cshtml"
using DQuiz.App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9aa61a5194247a7b599e1e7aed38dc21f456940", @"/Views/Home/EndContest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23f765a26c7ba72be154dedbfe8483033b84db9c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EndContest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<canvas id=\"serviceGlobalChart\" style=\"width: 600px; height: 440px\"></canvas>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <script src=\"../js/Quiz/endContest.js\"></script>\n");
            }
            );
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