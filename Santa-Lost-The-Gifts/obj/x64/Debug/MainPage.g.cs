﻿#pragma checksum "C:\Users\IMOE1\source\repos\Santa-Lost-The-Gifts\Santa-Lost-The-Gifts\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "76906B23A230A8C019116F764335EA343816D4666568915705C4C2E12F03C695"
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
    partial class MainPage : 
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
            case 1: // MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // MainPage.xaml line 50
                {
                    this.Game = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Game).Click += this.StartGame_Click;
                }
                break;
            case 3: // MainPage.xaml line 53
                {
                    this.Help = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Help).Click += this.Help_Click;
                }
                break;
            case 4: // MainPage.xaml line 56
                {
                    this.SignInPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SignInPage).Click += this.SignInPage_Click;
                }
                break;
            case 5: // MainPage.xaml line 59
                {
                    this.LevelsPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.LevelsPage).Click += this.LevelsPage_Click;
                }
                break;
            case 6: // MainPage.xaml line 62
                {
                    this.Settings = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Settings).Click += this.Settings_Click;
                }
                break;
            case 7: // MainPage.xaml line 65
                {
                    this.MusicPopup = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 8: // MainPage.xaml line 71
                {
                    this.MusicButtonControl = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.MusicButtonControl).Click += this.MusicButtonControl_Click;
                }
                break;
            case 9: // MainPage.xaml line 75
                {
                    this.soundEffect = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.soundEffect).Toggled += this.soundEffect_Toggled;
                }
                break;
            case 10: // MainPage.xaml line 77
                {
                    this.Volume = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.Volume).ValueChanged += this.Volume_ValueChanged;
                }
                break;
            case 11: // MainPage.xaml line 80
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.CloseSettings_Click;
                }
                break;
            case 12: // MainPage.xaml line 73
                {
                    this.Music = (global::Windows.UI.Xaml.Controls.Image)(target);
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

