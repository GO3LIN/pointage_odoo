﻿#pragma checksum "C:\Users\Username\Documents\Visual Studio 2013\Projects\Pointage_0.1\SilverlightApplication1\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4AE9B82B6BD42DEEAA2399C0C5762DA8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Pointage.client {
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox pass;
        
        internal System.Windows.Controls.Label dateToday;
        
        internal System.Windows.Controls.Label Output;
        
        internal System.Windows.Controls.TextBox login;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Pointage.client;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pass = ((System.Windows.Controls.TextBox)(this.FindName("pass")));
            this.dateToday = ((System.Windows.Controls.Label)(this.FindName("dateToday")));
            this.Output = ((System.Windows.Controls.Label)(this.FindName("Output")));
            this.login = ((System.Windows.Controls.TextBox)(this.FindName("login")));
        }
    }
}

