#pragma checksum "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "652950b5764ef194cdc82232ad12e93acf10fc92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_History), @"mvc.1.0.view", @"/Views/Home/History.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/History.cshtml", typeof(AspNetCore.Views_Home_History))]
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
#line 1 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\_ViewImports.cshtml"
using zadanie;

#line default
#line hidden
#line 2 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\_ViewImports.cshtml"
using zadanie.Models;

#line default
#line hidden
#line 3 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\_ViewImports.cshtml"
using System.Data.SqlClient;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"652950b5764ef194cdc82232ad12e93acf10fc92", @"/Views/Home/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ff808fb5eb1f2bf21bc9e88acb9a6a0c43af345", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<zadanie.Models.HistoryViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation/dist/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("register-table history"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
  
    ViewData["Title"] = "History";

#line default
#line hidden
            BeginContext(85, 39, true);
            WriteLiteral("\r\n<!--Strona z historią logowania.-->\r\n");
            EndContext();
            BeginContext(124, 3315, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7aba030677164cf3b11bc62011618e18", async() => {
                BeginContext(161, 36, true);
                WriteLiteral("\r\n    <!-- Formularz kontaktowy-->\r\n");
                EndContext();
#line 10 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
     using (Html.BeginForm("History", "Home", FormMethod.Post))
    {
        

#line default
#line hidden
                BeginContext(278, 23, false);
#line 12 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
                EndContext();
                BeginContext(305, 103, true);
                WriteLiteral("        <div>\r\n            <p class=\"history-label info\">Number of logs to remove</p>\r\n        </div>\r\n");
                EndContext();
                BeginContext(410, 235, true);
                WriteLiteral("        <div class=\"form-horizontal history-label\">\r\n\r\n            <table class=\"long-table\">\r\n                <tr>\r\n                    <!--Okno na liczbę wpisów, które chcemy usunąć.-->\r\n                    <td class=\"history-info\"> ");
                EndContext();
                BeginContext(646, 99, false);
#line 23 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                                         Write(Html.TextBoxFor(model => model.LogsToRemove, new { @class = "form-control", @id = "history-info" }));

#line default
#line hidden
                EndContext();
                BeginContext(745, 125, true);
                WriteLiteral("</td>\r\n                    <!--Komunikat z błędem jeżeli input zły.-->\r\n                    <td class=\"td-with-small-margin\">");
                EndContext();
                BeginContext(871, 81, false);
#line 25 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                                                Write(Html.ValidationMessageFor(m => m.LogsToRemove, "", new { @class = "error info" }));

#line default
#line hidden
                EndContext();
                BeginContext(952, 7, true);
                WriteLiteral("</td>\r\n");
                EndContext();
#line 26 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                      
                        // Jeśli inpu wykracza po za przedziały listy.
                        if (ViewBag.ValidInput == false)
                        {

#line default
#line hidden
                BeginContext(1140, 174, true);
                WriteLiteral("                            <td class=\"td-with-small-margin\">\r\n                                <p class=\"info\">Number is out of range</p>\r\n                            </td>\r\n");
                EndContext();
#line 33 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                        }
                        // Jeżeli użytkownik próbuje usunąć sesję, na której jest aktualnie zalogowany.
                        

#line default
#line hidden
#line 35 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                         if (ViewBag.NoIdea == "NoIdeaWhatIShouldTypeHere")
                        {

#line default
#line hidden
                BeginContext(1550, 177, true);
                WriteLiteral("                            <td class=\"td-with-small-margin\">\r\n                                <p class=\"info\">Cannot remove current log</p>\r\n                            </td>\r\n");
                EndContext();
#line 40 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                        }

#line default
#line hidden
                BeginContext(1777, 334, true);
                WriteLiteral(@"                </tr>
                <tr>
                    <td>
                        <div id=""history-button"">
                            <input type=""submit"" value=""Submit"" class=""btn btn-success"" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
");
                EndContext();
                BeginContext(2113, 15, true);
                WriteLiteral("        <div>\r\n");
                EndContext();
#line 54 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
              
                // Wczytujemy wszystkie wpisy z historii.
                string query = @"SELECT LoginHistory.DateOfLogging, Accounts.Nick FROM LoginHistory INNER JOIN Accounts ON LoginHistory.UserID = Accounts.ID";
                using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-HPD9G79T; database=MedievalStudents; Trusted_Connection=yes"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

#line default
#line hidden
                BeginContext(2875, 48, true);
                WriteLiteral("                                <p class=\"info\">");
                EndContext();
                BeginContext(2924, 9, false);
#line 66 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                                           Write(reader[1]);

#line default
#line hidden
                EndContext();
                BeginContext(2933, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(2935, 9, false);
#line 66 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                                                      Write(reader[0]);

#line default
#line hidden
                EndContext();
                BeginContext(2944, 6, true);
                WriteLiteral("</p>\r\n");
                EndContext();
#line 67 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
                            }

                            reader.Close();

                        }
                        connection.Close();
                    }
                  }
                

#line default
#line hidden
                BeginContext(3165, 16, true);
                WriteLiteral("        </div>\r\n");
                EndContext();
                BeginContext(3183, 8, true);
                WriteLiteral("        ");
                EndContext();
                BeginContext(3191, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80235a10270a4d419e67ed355a090a85", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3242, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(3252, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78abce35da104457acf438a7ced82a63", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3323, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(3333, 90, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c63d3dc04f674cbf9c9c1aa7b009d007", async() => {
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
                BeginContext(3423, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 81 "C:\Users\Milosz\Desktop\Projekty\C#\Medieval Students Server Site\zadanie\Views\Home\History.cshtml"
    }

#line default
#line hidden
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<zadanie.Models.HistoryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
