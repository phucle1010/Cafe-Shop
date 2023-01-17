﻿#pragma checksum "..\..\..\View\OrderFoodView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD62A07F7C79C891FAE2146F5B0CB5D5991070A0C9554A9EE1F6B783DAD8087E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.Sharp;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace QL_QuanCafe.View {
    
    
    /// <summary>
    /// OrderFoodView
    /// </summary>
    public partial class OrderFoodView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\View\OrderFoodView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbUserName;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\View\OrderFoodView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid foodList;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\View\OrderFoodView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel navigationFoodList;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\View\OrderFoodView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvOrderChosedFood;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\View\OrderFoodView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\View\OrderFoodView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewHistory;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\View\OrderFoodView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon iconHistory;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\View\OrderFoodView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbHistory;
        
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
            System.Uri resourceLocater = new System.Uri("/QL_QuanCafe;component/view/orderfoodview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\OrderFoodView.xaml"
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
            this.tbUserName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.foodList = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.navigationFoodList = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.lvOrderChosedFood = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\View\OrderFoodView.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.btnSubmit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnViewHistory = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\View\OrderFoodView.xaml"
            this.btnViewHistory.MouseMove += new System.Windows.Input.MouseEventHandler(this.btnViewHistory_MouseMove);
            
            #line default
            #line hidden
            
            #line 100 "..\..\..\View\OrderFoodView.xaml"
            this.btnViewHistory.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnViewHistory_MouseLeave);
            
            #line default
            #line hidden
            
            #line 100 "..\..\..\View\OrderFoodView.xaml"
            this.btnViewHistory.Click += new System.Windows.RoutedEventHandler(this.btnViewHistory_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.iconHistory = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 8:
            this.tbHistory = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

