﻿

#pragma checksum "C:\Users\aksha\Documents\GitHub\MUGDApp\MUGDApp\MUGDApp.Shared\loginMember.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "769BF98730672231CE0415330A156539"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MUGDApp
{
    partial class loginMember : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 26 "..\..\loginMember.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.TextBox_GotFocus;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 27 "..\..\loginMember.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.PasswordBox_GotFocus;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 28 "..\..\loginMember.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Button_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


