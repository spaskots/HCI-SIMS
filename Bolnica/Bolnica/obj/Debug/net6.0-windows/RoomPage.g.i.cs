﻿#pragma checksum "..\..\..\RoomPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04C06AE5A921F9A16E4D83BF96599E6CD49F8647"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bolnica;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Bolnica {
    
    
    /// <summary>
    /// RoomPage
    /// </summary>
    public partial class RoomPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomType1;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Id1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description1;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomType2;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Id2;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description2;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomType3;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Id3;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description3;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomType4;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Id4;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\RoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description4;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/roompage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RoomPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 18 "..\..\..\RoomPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addNewRoom);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 29 "..\..\..\RoomPage.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RoomType1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Id1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Description1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 35 "..\..\..\RoomPage.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown2);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RoomType2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Id2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Description2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 41 "..\..\..\RoomPage.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown3);
            
            #line default
            #line hidden
            return;
            case 11:
            this.RoomType3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.Id3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.Description3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            
            #line 47 "..\..\..\RoomPage.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown4);
            
            #line default
            #line hidden
            return;
            case 15:
            this.RoomType4 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.Id4 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.Description4 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            
            #line 53 "..\..\..\RoomPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.next);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 54 "..\..\..\RoomPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.previous);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

