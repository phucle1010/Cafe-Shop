﻿#pragma checksum "..\..\..\View\OrderTableHistoryItemView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A049E7ACFA53929D483B65B5A62460945A65757E210FF24EA569E60C11DF4ED4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// OrderTableHistoryItemView
    /// </summary>
    public partial class OrderTableHistoryItemView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\View\OrderTableHistoryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTableName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\OrderTableHistoryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbCustomerName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\OrderTableHistoryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTotal;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\View\OrderTableHistoryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbMergeTable;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\View\OrderTableHistoryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbStatus;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\OrderTableHistoryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTime;
        
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
            System.Uri resourceLocater = new System.Uri("/QL_QuanCafe;component/view/ordertablehistoryitemview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\OrderTableHistoryItemView.xaml"
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
            this.tbTableName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tbCustomerName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.tbTotal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.cbMergeTable = ((System.Windows.Controls.CheckBox)(target));
            
            #line 21 "..\..\..\View\OrderTableHistoryItemView.xaml"
            this.cbMergeTable.Click += new System.Windows.RoutedEventHandler(this.cbMergeTable_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.tbTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
