﻿#pragma checksum "C:\Users\IMOE1\source\repos\Santa-Lost-The-Gifts\Santa-Lost-The-Gifts\GamePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CE56E1AA889D11621988710E7AF7B0E5E58B506684E808A0EE5C995D52E3648B"
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
    partial class GamePage : 
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
            case 1: // GamePage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // GamePage.xaml line 63
                {
                    this.lives1 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3: // GamePage.xaml line 64
                {
                    this.lives2 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 4: // GamePage.xaml line 65
                {
                    this.lives3 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 5: // GamePage.xaml line 67
                {
                    this.Pause = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 6: // GamePage.xaml line 68
                {
                    this.Help = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Help).Click += this.Help_Click;
                }
                break;
            case 7: // GamePage.xaml line 69
                {
                    this.Main = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Main).Click += this.Main_Click;
                }
                break;
            case 8: // GamePage.xaml line 71
                {
                    this.scene = (global::Santa_Lost_The_Gifts.GameServices.GameScene)(target);
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

