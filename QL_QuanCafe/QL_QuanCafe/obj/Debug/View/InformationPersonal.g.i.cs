﻿#pragma checksum "..\..\..\View\InformationPersonal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "374A464684A89764CB81DECFE4FEF2F9CC03AFE0F5858187B49934C9351B84E9"
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
using QL_QuanCafe.View;
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
    /// InformationPersonal
    /// </summary>
    public partial class InformationPersonal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 70 "..\..\..\View\InformationPersonal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_HoTen;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\View\InformationPersonal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Email;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\View\InformationPersonal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_picker;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\View\InformationPersonal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Sdt;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\View\InformationPersonal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_SaveChange;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\View\InformationPersonal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_DiemTichLuy;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\View\InformationPersonal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_LoaiKhachHang;
        
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
            System.Uri resourceLocater = new System.Uri("/QL_QuanCafe;component/view/informationpersonal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\InformationPersonal.xaml"
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
            
            #line 17 "..\..\..\View\InformationPersonal.xaml"
            ((QL_QuanCafe.View.InformationPersonal)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_HoTen = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.date_picker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.txt_Sdt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_SaveChange = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\..\View\InformationPersonal.xaml"
            this.btn_SaveChange.Click += new System.Windows.RoutedEventHandler(this.btn_SaveChange_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_DiemTichLuy = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txt_LoaiKhachHang = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

