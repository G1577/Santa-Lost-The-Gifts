﻿#pragma checksum "C:\Users\IMOE1\source\repos\Santa-Lost-The-Gifts\Santa-Lost-The-Gifts\StorePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C0CBDC506C135AA236C8A9044405A5DEE966E40075A1007F48F8AE8B6434A9A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Santa_Lost_The_Gifts
{
    partial class StorePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // StorePage.xaml line 23
                {
                    this.Main = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Main).Click += this.Main_Click;
                }
                break;
            case 3: // StorePage.xaml line 29
                {
                    this.productsViewList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 4: // StorePage.xaml line 40
                {
                    this.yesBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.yesBtn).Click += this.YesBtn_Click;
                }
                break;
            case 5: // StorePage.xaml line 44
                {
                    this.noBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.noBtn).Click += this.noBtn_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

