#pragma checksum "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8d405b01e9263a8bd09f49bce460c35258467b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_GetTeacherById), @"mvc.1.0.view", @"/Views/Teacher/GetTeacherById.cshtml")]
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
#line 1 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\_ViewImports.cshtml"
using SMS_APP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\_ViewImports.cshtml"
using SMS_APP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8d405b01e9263a8bd09f49bce460c35258467b1", @"/Views/Teacher/GetTeacherById.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"799dc20b0a31032d88db59b1aeee2a508cdd11ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_GetTeacherById : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeacherModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
  
    ViewData["Title"] = "GetTeacherById";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetTeacherById</h1>\r\n\r\n");
#nullable restore
#line 9 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
   Layout = "_Layout"; ViewBag.Title = "Get Teacher by Id";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Get Student by Id ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8d405b01e9263a8bd09f49bce460c35258467b15060", async() => {
                WriteLiteral("Back");
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
            WriteLiteral("</h2>\r\n<h3>");
#nullable restore
#line 12 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
Write(ViewBag.StatusCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8d405b01e9263a8bd09f49bce460c35258467b16570", async() => {
                WriteLiteral(@"
    <div class=""form-group"">
        <label for=""id"">Id:</label>
        <input class=""form-control"" name=""id"" />
    </div>
    <div class=""text-center panel-body"">
        <button type=""submit"" class=""btn btn-sm btn-primary"">Get Student</button>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 23 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h2>TEACHER</h2>
    <table class=""table table-sm table-striped table-bordered m-2"">
        <thead>
            <tr>
                <th>Teacher ID</th>
                <th>Class Name</th>
                <th>Teacher Name</th>
                <th>Gender</th>
                <th>DOB</th>
                <th>Contact</th>
                <th>Email</th>
                <th>Address</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>");
#nullable restore
#line 41 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
               Write(Model.TeacherId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 42 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
               Write(Model.ClassName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 43 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
               Write(Model.TeacherName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 44 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
               Write(Model.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 45 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
               Write(Model.Dob);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 46 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
               Write(Model.Contact);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 47 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
               Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 48 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
               Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 52 "S:\Capgemini\Sprint 2- 6th September to 13th September\Team5\New folder\SMS_APP\Views\Teacher\GetTeacherById.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeacherModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
