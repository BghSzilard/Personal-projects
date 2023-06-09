﻿#pragma checksum "..\..\MainGamePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6064DEB3527AE9A880BFCD423771DE85BC32E0B118F68191EDF5BB1E0407BC44"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// MainGamePage
    /// </summary>
    public partial class MainGamePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\MainGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem saveGame;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem standardMenuItem;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem customMenuItem;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label username;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MainGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image profilePicture;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainGamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/maingamepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainGamePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\MainGamePage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OnNewGameClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\MainGamePage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OnLoadGameClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.saveGame = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\MainGamePage.xaml"
            this.saveGame.Click += new System.Windows.RoutedEventHandler(this.OnSaveGameClicked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 22 "..\..\MainGamePage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OnStatisticsClicked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 23 "..\..\MainGamePage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OnExitButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.standardMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 26 "..\..\MainGamePage.xaml"
            this.standardMenuItem.Click += new System.Windows.RoutedEventHandler(this.OnStandardOptionClicked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.customMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 27 "..\..\MainGamePage.xaml"
            this.customMenuItem.Click += new System.Windows.RoutedEventHandler(this.OnCustomOptionClicked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 30 "..\..\MainGamePage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OnAboutClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.username = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.profilePicture = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.frame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

