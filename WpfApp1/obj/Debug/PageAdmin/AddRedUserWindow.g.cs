﻿#pragma checksum "..\..\..\PageAdmin\AddRedUserWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6745C262142A7E2204A9F0007B2DDA216AD1DCF6AADC20ADE2ED0DCA041DC8A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp1.Controls;
using WpfApp1.PageAdmin;


namespace WpfApp1.PageAdmin {
    
    
    /// <summary>
    /// AddRedUserWindow
    /// </summary>
    public partial class AddRedUserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbRole;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp1.Controls.HintTextBox TxbFamilia;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp1.Controls.HintTextBox TxbName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp1.Controls.HintTextBox TxbOtchestvo;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp1.Controls.HintTextBox TxbLogin;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp1.Controls.HintTextBox TxbPssword;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/pageadmin/addreduserwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.cmbRole = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.TxbFamilia = ((WpfApp1.Controls.HintTextBox)(target));
            return;
            case 3:
            this.TxbName = ((WpfApp1.Controls.HintTextBox)(target));
            return;
            case 4:
            this.TxbOtchestvo = ((WpfApp1.Controls.HintTextBox)(target));
            return;
            case 5:
            this.TxbLogin = ((WpfApp1.Controls.HintTextBox)(target));
            return;
            case 6:
            this.TxbPssword = ((WpfApp1.Controls.HintTextBox)(target));
            return;
            case 7:
            this.BtnSave = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\PageAdmin\AddRedUserWindow.xaml"
            this.BtnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

