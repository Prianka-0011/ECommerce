#pragma checksum "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c65bb0c120d1b61207ead902023f0cd771e7e1ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ProductType_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/ProductType/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/ProductType/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_ProductType_Index))]
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
#line 1 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\_ViewImports.cshtml"
using EcommerceProject;

#line default
#line hidden
#line 2 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\_ViewImports.cshtml"
using EcommerceProject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c65bb0c120d1b61207ead902023f0cd771e7e1ee", @"/Areas/Admin/Views/ProductType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"221fb0acfc1751d620f02ffa1e872e29d71f88d1", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ProductType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EcommerceProject.Models.ProductTypes>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(99, 162, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <h1 class=\"text-dark\">Product Type List</h1>\r\n    </div>\r\n    <div class=\"col-md-6 text-right\">\r\n        ");
            EndContext();
            BeginContext(261, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c65bb0c120d1b61207ead902023f0cd771e7e1ee4867", async() => {
                BeginContext(307, 34, true);
                WriteLiteral("&nbsp; <i class=\"fas fa-plus\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(345, 24, true);
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n");
            EndContext();
#line 15 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(393, 261, true);
            WriteLiteral(@"    <div>
        <table class=""table table-bordered"" id=""myTable"">
            <tr>
                <th class=""bg-success"">Product Type</th>
                <th class=""bg-success""></th>
                <th class=""bg-success""></th>
            </tr>


");
            EndContext();
#line 26 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(711, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(758, 9, false);
#line 29 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
                   Write(item.Type);

#line default
#line hidden
            EndContext();
            BeginContext(767, 57, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(824, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c65bb0c120d1b61207ead902023f0cd771e7e1ee7690", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 31 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(873, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 34 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(940, 32, true);
            WriteLiteral("\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 38 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
    
}

#line default
#line hidden
            BeginContext(981, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1002, 148, true);
                WriteLiteral("\r\n    <script src=\"//cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/alertify.min.js\"></script>\r\n   \r\n        $(function(){\r\n            var create = \'");
                EndContext();
                BeginContext(1151, 18, false);
#line 46 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
                     Write(TempData["create"]);

#line default
#line hidden
                EndContext();
                BeginContext(1169, 30, true);
                WriteLiteral("\';\r\n            var update = \'");
                EndContext();
                BeginContext(1200, 18, false);
#line 47 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
                     Write(TempData["update"]);

#line default
#line hidden
                EndContext();
                BeginContext(1218, 30, true);
                WriteLiteral("\';\r\n            var delete = \'");
                EndContext();
                BeginContext(1249, 18, false);
#line 48 "C:\Users\niku\source\repos\EcommerceProject\EcommerceProject\Areas\Admin\Views\ProductType\Index.cshtml"
                     Write(TempData["delete"]);

#line default
#line hidden
                EndContext();
                BeginContext(1267, 311, true);
                WriteLiteral(@"';
            if (create != null) {
                alertify.success(create);
            }
            if (update != null) {
                alertify.success(update);
            }
            if (delete != null) {
                alertify.success(delete);
            }
        });
    </script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EcommerceProject.Models.ProductTypes>> Html { get; private set; }
    }
}
#pragma warning restore 1591
