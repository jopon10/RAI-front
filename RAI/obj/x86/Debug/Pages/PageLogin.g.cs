﻿#pragma checksum "..\..\..\..\Pages\PageLogin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "138680FA095BC64EDCCF3A14D5367A142F7C94BD465F5E19FAB37A522341A789"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RAI.Pages;
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
using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Behaviors;
using Telerik.Windows.Controls.BulletGraph;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.ComboBox;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.HeatMap;
using Telerik.Windows.Controls.LayoutControl;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Controls.MultiColumnComboBox;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RadialMenu;
using Telerik.Windows.Controls.Sparklines;
using Telerik.Windows.Controls.TimeBar;
using Telerik.Windows.Controls.Timeline;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeMap;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Controls.Wizard;
using Telerik.Windows.Data;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Persistence;
using Telerik.Windows.Persistence.SerializationMetadata;
using Telerik.Windows.Shapes;


namespace RAI.Pages {
    
    
    /// <summary>
    /// PageLogin
    /// </summary>
    public partial class PageLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\..\..\Pages\PageLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadAutoSuggestBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\PageLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadPasswordBox txtSenha;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\PageLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btEntrar;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\PageLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar pb;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\PageLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtVersion;
        
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
            System.Uri resourceLocater = new System.Uri("/RAI;component/pages/pagelogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\PageLogin.xaml"
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
            
            #line 12 "..\..\..\..\Pages\PageLogin.xaml"
            ((RAI.Pages.PageLogin)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\..\Pages\PageLogin.xaml"
            ((MaterialDesignThemes.Wpf.ColorZone)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ColorZone_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 33 "..\..\..\..\Pages\PageLogin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btFechar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtEmail = ((Telerik.Windows.Controls.RadAutoSuggestBox)(target));
            
            #line 61 "..\..\..\..\Pages\PageLogin.xaml"
            this.txtEmail.TextChanged += new System.EventHandler<Telerik.Windows.Controls.AutoSuggestBox.TextChangedEventArgs>(this.txtEmail_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtSenha = ((Telerik.Windows.Controls.RadPasswordBox)(target));
            
            #line 62 "..\..\..\..\Pages\PageLogin.xaml"
            this.txtSenha.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtSenha_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btEntrar = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\Pages\PageLogin.xaml"
            this.btEntrar.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.pb = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 8:
            this.txtVersion = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
