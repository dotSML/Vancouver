#pragma checksum "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5c5ccd35894b03644c7a3a0d2697b4b17b5e8ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Vancouver.Pages.Pages_MyAccount), @"mvc.1.0.razor-page", @"/Pages/MyAccount.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/MyAccount.cshtml", typeof(Vancouver.Pages.Pages_MyAccount), null)]
namespace Vancouver.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\_ViewImports.cshtml"
using Vancouver;

#line default
#line hidden
#line 3 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
using CustomerFolder;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5c5ccd35894b03644c7a3a0d2697b4b17b5e8ca", @"/Pages/MyAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7517b6531902e20366634869abb92efd3e0c371d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_MyAccount : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/bootstrapIndex.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(7, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
  
    ViewData["Title"] = "MyAccount";
    var countOfCustomers = Model.Customers.Count;

#line default
#line hidden
            BeginContext(222, 189, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b16eb6e060ee481baa2413b83e5a8b6d", async() => {
                BeginContext(228, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(234, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f84d6b368d0b43a099db3b39cc735ca2", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(291, 113, true);
                WriteLiteral("\r\n    <link href=\"css/myAccount.css\" rel=\"stylesheet\" />\r\n    <script src=\"lib/jquery/dist/jquery.js\"></script>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(411, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(415, 2343, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "070654e4fb51484bbbe4488bdf8bc72b", async() => {
                BeginContext(421, 456, true);
                WriteLiteral(@"

    <div class=""container"">
        <div class=""profile-sector"">
            <div class=""profile-sector-column"">
                <img src=""/images/Grete.jpg"" alt=""Grete"">
            </div>
            <div class=""profile-sector-column"">
                <h3>Profile</h3>

                <h5>Email</h5>
                <h5>Favourite destinations </h5>
                <input type=""submit"" class=""button"" value=""Change Profile"" onclick="""" />
");
                EndContext();
                BeginContext(979, 86, true);
                WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n        <div id=\"formMyAccount\">\r\n            ");
                EndContext();
                BeginContext(1065, 1661, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a4c17a854bf4e9f8496ab3e1e20bbff", async() => {
                    BeginContext(1110, 18, true);
                    WriteLiteral("\r\n                ");
                    EndContext();
                    BeginContext(1128, 159, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b68681bc48784390aa1847298c8232b4", async() => {
                        BeginContext(1164, 32, true);
                        WriteLiteral("First Name\r\n                    ");
                        EndContext();
                        BeginContext(1196, 65, false);
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3a8d671d055147d283ee1fe05790c54a", async() => {
                        }
                        );
                        __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                        __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 38 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Customer.FirstName);

#line default
#line hidden
                        __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                        __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                        await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                        if (!__tagHelperExecutionContext.Output.IsContentModified)
                        {
                            await __tagHelperExecutionContext.SetOutputContentAsync();
                        }
                        Write(__tagHelperExecutionContext.Output);
                        __tagHelperExecutionContext = __tagHelperScopeManager.End();
                        EndContext();
                        BeginContext(1261, 18, true);
                        WriteLiteral("\r\n                ");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 37 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Customer.FirstName);

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(1287, 18, true);
                    WriteLiteral("\r\n                ");
                    EndContext();
                    BeginContext(1305, 156, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0b233a052264031984139f5dccd80be", async() => {
                        BeginContext(1340, 31, true);
                        WriteLiteral("Last Name\r\n                    ");
                        EndContext();
                        BeginContext(1371, 64, false);
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "eb74b2554e9e4e02a60ee1b3b91c85f9", async() => {
                        }
                        );
                        __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                        __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 41 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Customer.LastName);

#line default
#line hidden
                        __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                        __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                        await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                        if (!__tagHelperExecutionContext.Output.IsContentModified)
                        {
                            await __tagHelperExecutionContext.SetOutputContentAsync();
                        }
                        Write(__tagHelperExecutionContext.Output);
                        __tagHelperExecutionContext = __tagHelperScopeManager.End();
                        EndContext();
                        BeginContext(1435, 18, true);
                        WriteLiteral("\r\n                ");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 40 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Customer.LastName);

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(1461, 310, true);
                    WriteLiteral(@"
                <table class=""table"">
                    <thead>
                    <tr>
                        <th>ID</th>
                        <th>First Name</th>
                        <th>Last Name</th>

                    </tr>
                    </thead>
                    <tbody>
");
                    EndContext();
#line 53 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
                     foreach (var customer in Model.Customers)
                    {


#line default
#line hidden
                    BeginContext(1860, 62, true);
                    WriteLiteral("                        <tr>\r\n                            <td>");
                    EndContext();
                    BeginContext(1923, 19, false);
#line 57 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
                           Write(customer.CustomerId);

#line default
#line hidden
                    EndContext();
                    BeginContext(1942, 39, true);
                    WriteLiteral("</td>\r\n                            <td>");
                    EndContext();
                    BeginContext(1982, 18, false);
#line 58 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
                           Write(customer.FirstName);

#line default
#line hidden
                    EndContext();
                    BeginContext(2000, 39, true);
                    WriteLiteral("</td>\r\n                            <td>");
                    EndContext();
                    BeginContext(2040, 17, false);
#line 59 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
                           Write(customer.LastName);

#line default
#line hidden
                    EndContext();
                    BeginContext(2057, 73, true);
                    WriteLiteral("</td>\r\n                            <td>\r\n                                ");
                    EndContext();
                    BeginContext(2130, 89, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcaab7d031b645a4bd3aaed3cbeb45bb", async() => {
                        BeginContext(2211, 4, true);
                        WriteLiteral("Edit");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                    if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                    {
                        throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                    }
                    BeginWriteTagHelperAttribute();
#line 61 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
                                                       WriteLiteral(customer.CustomerId);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2219, 34, true);
                    WriteLiteral("\r\n                                ");
                    EndContext();
                    BeginContext(2253, 149, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5173865ff4324d7e827cb088ee47a4e1", async() => {
                        BeginContext(2387, 6, true);
                        WriteLiteral("Delete");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                    {
                        throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                    }
                    BeginWriteTagHelperAttribute();
#line 63 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
                                          WriteLiteral(customer.CustomerId);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2402, 68, true);
                    WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
                    EndContext();
#line 66 "C:\Users\sten\source\repos\Vancouver\Vancouver\Pages\MyAccount.cshtml"
                    }

#line default
#line hidden
                    BeginContext(2493, 58, true);
                    WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n");
                    EndContext();
                    BeginContext(2606, 113, true);
                    WriteLiteral("                <button type=\"submit\" id=\"submitAccountBtn\" class=\"btn btn-success\">Create</button>\r\n            ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2726, 25, true);
                WriteLiteral("\r\n    </div>\r\n   </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2758, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyAccountModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyAccountModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyAccountModel>)PageContext?.ViewData;
        public MyAccountModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
