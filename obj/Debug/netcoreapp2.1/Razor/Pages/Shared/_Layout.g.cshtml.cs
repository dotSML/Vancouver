#pragma checksum "C:\Users\hlv\source\repos\Vancouver\Pages\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd825713887b8e35ecbca0642688a4c28f62e779"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Vancouver.Pages.Shared.Pages_Shared__Layout), @"mvc.1.0.view", @"/Pages/Shared/_Layout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/Shared/_Layout.cshtml", typeof(Vancouver.Pages.Shared.Pages_Shared__Layout))]
namespace Vancouver.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\hlv\source\repos\Vancouver\Pages\_ViewImports.cshtml"
using Vancouver;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd825713887b8e35ecbca0642688a4c28f62e779", @"/Pages/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7517b6531902e20366634869abb92efd3e0c371d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/bootstrapIndex.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/fullBackgroundImage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/modalLogin.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cd-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/js_modalLogin.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 17, true);
            WriteLiteral("<!DOCTYPE html>\r\n");
            EndContext();
            BeginContext(17, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "08c213dc80e048c7bef502acde8958f9", async() => {
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
            BeginContext(72, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(74, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5dff1d3a9104352b7a39684b4920798", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(129, 56, true);
            WriteLiteral("\r\n<script src=\"lib/popper.js/dist/popper.js\"></script>\r\n");
            EndContext();
            BeginContext(185, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c1dfc247d4e4b2cabc04b1419d5651c", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(252, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(254, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "888ddb33815c447b95fba666c8db8c6b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(316, 69, true);
            WriteLiteral("\r\n<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\"favicon.ico\">\r\n");
            EndContext();
            BeginContext(385, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d3dd250ee7514049ad99c2576fc09ba2", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(438, 127, true);
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(565, 182, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e87edc7b068a4ae0826c119d90356d2b", async() => {
                BeginContext(571, 72, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>");
                EndContext();
                BeginContext(644, 13, false);
#line 14 "C:\Users\hlv\source\repos\Vancouver\Pages\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
                EndContext();
                BeginContext(657, 83, true);
                WriteLiteral("</title>\r\n    <link rel=\"shortcut icon\" type=\"image/x-icon\" href=\"favicon.ico\" />\r\n");
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
            BeginContext(747, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(753, 8574, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ee182a7a4f847b88c318b92b33452b8", async() => {
                BeginContext(759, 1860, true);
                WriteLiteral(@"
<div id=""layoutPreload"">
    <nav class=""navbar navbar-expand-lg navbar-dark navbar-inverse"" style=""padding-top: 50px;"" id=""navBar"">
        <a class=""navbar-brand"" href=""/index"">Vancouver</a>
        <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarSupportedContent"" aria-controls=""navbarSupportedContent"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-icon""></span>
        </button>

        <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">
            <ul class=""navbar-nav ml-auto"">
                <li id=""indexNav"" class=""nav-item"">
                    <a class=""nav-link"" href=""/index"">Home</a>
                </li>
                <li id=""myAccountNav"" class=""nav-item"">
                    <a class=""nav-link"" href=""/MyAccount"">My Account</a>
                </li>
                <li id=""myTicketsNav"" class=""nav-item"">
                    <a class=""nav-link"" href=""/tickettest"">My Tickets<");
                WriteLiteral(@"/a>
                </li>
                <li id=""loginNav"" class=""nav-item login-nav"">
                    <a class=""nav-link cd-signin"" href=""#0"">Log in</a>
                </li>
                <li id=""aboutNav"" class=""nav-item"">
                    <a class=""nav-link"" href=""/about"">About</a>
                </li>
            </ul>

        </div>
    </nav>

    <div class=""cd-user-modal"">
        <!-- this is the entire modal form, including the background -->
        <div class=""cd-user-modal-container"">
            <!-- this is the container wrapper -->
            <ul class=""cd-switcher"">
                <li><a href=""#0"">Sign in</a></li>
                <li><a href=""#0"">New account</a></li>
            </ul>

            <div id=""cd-login"">
                <!-- log in form -->
                ");
                EndContext();
                BeginContext(2619, 1244, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81a566a53c914eb4889c161b3ecff0d6", async() => {
                    BeginContext(2641, 1215, true);
                    WriteLiteral(@"
                    <p class=""fieldset"">
                        <label class=""image-replace cd-email"" for=""signin-email"">E-mail</label>
                        <input class=""full-width has-padding has-border"" id=""signin-email"" type=""email"" placeholder=""E-mail"">
                        <span class=""cd-error-message"">Error message here!</span>
                    </p>

                    <p class=""fieldset"">
                        <label class=""image-replace cd-password"" for=""signin-password"">Password</label>
                        <input class=""full-width has-padding has-border"" id=""signin-password"" type=""text"" placeholder=""Password"">
                        <a href=""#0"" class=""hide-password"">Hide</a>
                        <span class=""cd-error-message"">Error message here!</span>
                    </p>

                    <p class=""fieldset"">
                        <input type=""checkbox"" id=""remember-me"" checked>
                        <label for=""remember-me"">Remember me</label>
 ");
                    WriteLiteral("                   </p>\r\n\r\n                    <p class=\"fieldset\">\r\n                        <input class=\"full-width\" type=\"submit\" value=\"Login\">\r\n                    </p>\r\n                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3863, 298, true);
                WriteLiteral(@"

                <p class=""cd-form-bottom-message""><a href=""#0"">Forgot your password?</a></p>
                <!-- <a href=""#0"" class=""cd-close-form"">Close</a> -->
            </div> <!-- cd-login -->

            <div id=""cd-signup"">
                <!-- sign up form -->
                ");
                EndContext();
                BeginContext(4161, 1674, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccdb3fee72f1474b8e80676e2090eb61", async() => {
                    BeginContext(4183, 1645, true);
                    WriteLiteral(@"
                    <p class=""fieldset"">
                        <label class=""image-replace cd-username"" for=""signup-username"">Username</label>
                        <input class=""full-width has-padding has-border"" id=""signup-username"" type=""text"" placeholder=""Username"">
                        <span class=""cd-error-message"">Error message here!</span>
                    </p>

                    <p class=""fieldset"">
                        <label class=""image-replace cd-email"" for=""signup-email"">E-mail</label>
                        <input class=""full-width has-padding has-border"" id=""signup-email"" type=""email"" placeholder=""E-mail"">
                        <span class=""cd-error-message"">Error message here!</span>
                    </p>

                    <p class=""fieldset"">
                        <label class=""image-replace cd-password"" for=""signup-password"">Password</label>
                        <input class=""full-width has-padding has-border"" id=""signup-password"" type=""text"" pla");
                    WriteLiteral(@"ceholder=""Password"">
                        <a href=""#0"" class=""hide-password"">Hide</a>
                        <span class=""cd-error-message"">Error message here!</span>
                    </p>

                    <p class=""fieldset"">
                        <input type=""checkbox"" id=""accept-terms"">
                        <label for=""accept-terms"">I agree to the <a href=""#0"">Terms</a></label>
                    </p>

                    <p class=""fieldset"">
                        <input class=""full-width has-padding"" type=""submit"" value=""Create account"">
                    </p>
                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5835, 373, true);
                WriteLiteral(@"

                <!-- <a href=""#0"" class=""cd-close-form"">Close</a> -->
            </div> <!-- cd-signup -->

            <div id=""cd-reset-password"">
                <!-- reset password form -->
                <p class=""cd-form-message"">Lost your password? Please enter your email address. You will receive a link to create a new password.</p>

                ");
                EndContext();
                BeginContext(6208, 591, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0a51512192945f883081d7f240ecb52", async() => {
                    BeginContext(6230, 562, true);
                    WriteLiteral(@"
                    <p class=""fieldset"">
                        <label class=""image-replace cd-email"" for=""reset-email"">E-mail</label>
                        <input class=""full-width has-padding has-border"" id=""reset-email"" type=""email"" placeholder=""E-mail"">
                        <span class=""cd-error-message"">Error message here!</span>
                    </p>

                    <p class=""fieldset"">
                        <input class=""full-width has-padding"" type=""submit"" value=""Reset password"">
                    </p>
                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6799, 329, true);
                WriteLiteral(@"

                <p class=""cd-form-bottom-message""><a href=""#0"">Back to log-in</a></p>
            </div> <!-- cd-reset-password -->
            <a href=""#0"" class=""cd-close-form"">Close</a>
        </div> <!-- cd-user-modal-container -->
    </div> <!-- cd-user-modal -->

    <div class=""container"" id=""body"">
        ");
                EndContext();
                BeginContext(7129, 12, false);
#line 146 "C:\Users\hlv\source\repos\Vancouver\Pages\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(7141, 1107, true);
                WriteLiteral(@"
    </div>
    <div class=""vancouverFooter"">
        <p style=""text-align:left;"">
            &copy; Vancouver 2018
            <span style=""float:right;"">Contact us:</span>
        </p>
        <p style=""text-align:left;"">
            Taltech
            <a href=""#"" style=""float: right; background: #55ACEE; color: white; font-size: 25px; padding: 5px; border-radius: 20%; margin-left: 2px; margin-right: 2px;"" class=""fa fa-twitter""></a>
            <a href=""#"" style=""float: right; font-size: 25px; padding: 5px; border-radius: 20%; margin-left: 2px; margin-right: 2px; color: white; background-color: #f09433; background-image: url('http://www.myprojectsite.com/images/social/instagram.png'), linear-gradient(45deg, #f09433 0%,#e6683c 25%,#dc2743 50%,#cc2366 75%,#bc1888 100%);font-size: 25px;"" class=""fa fa-instagram""></a>
            <a href=""#"" style=""float: right; background: #3B5998; color: white; font-size: 25px; padding: 5px; padding-right: 9px; padding-left: 9px; border-radius: 20%; margin-left: 2");
                WriteLiteral("px; margin-right: 2px;\" class=\"fa fa-facebook\"></a>\r\n        </p>\r\n    </div>\r\n    ");
                EndContext();
                BeginContext(8248, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95f60686bad1444bbc0995e4c68254cb", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(8293, 1027, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function() {
            var pathName = window.location.pathname;
            console.log($('#aboutActive'));

            if (pathName === ""/about"") {
            }

            switch (pathName) {
            case '/about':
                $(document).remove('active');
                $('#aboutNav').addClass('active');
                break;
            case '/index':
                $(document).remove('active');
                $('#indexNav').addClass('active');
                break;
            case '/tickettest':
                $(document).remove('active');
                $('#myTicketsNav').addClass('active');
                break;
            case '/MyAccount':
                $(document).remove('active');
                $('#myAccountNav').addClass('active');
                break;
            }
        })

    </script>
</div>
<script>
    $(document).ready(function() {
        $('#layoutPreload').fadeIn();
    });
</script");
                WriteLiteral(">\r\n");
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
            BeginContext(9327, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
