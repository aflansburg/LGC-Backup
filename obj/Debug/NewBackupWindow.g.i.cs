﻿#pragma checksum "..\..\NewBackupWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9AD719A9F790ECA9F4790F0D2BB6FB15"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LGC_Backup;
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


namespace LGC_Backup {
    
    
    /// <summary>
    /// NewBackupWindow
    /// </summary>
    public partial class NewBackupWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addSrcBtn;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox sourcesListBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addDestBtn;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox destListBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label promptLbl1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jobNameTxtBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveJobBtn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelBtn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\NewBackupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/LGC-Backup;component/newbackupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewBackupWindow.xaml"
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
            this.addSrcBtn = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\NewBackupWindow.xaml"
            this.addSrcBtn.Click += new System.Windows.RoutedEventHandler(this.addSrcBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sourcesListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.addDestBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\NewBackupWindow.xaml"
            this.addDestBtn.Click += new System.Windows.RoutedEventHandler(this.addDestBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.destListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.promptLbl1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.jobNameTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.saveJobBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\NewBackupWindow.xaml"
            this.saveJobBtn.Click += new System.Windows.RoutedEventHandler(this.saveJobBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.cancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\NewBackupWindow.xaml"
            this.cancelBtn.Click += new System.Windows.RoutedEventHandler(this.cancelBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.textBlock_Copy = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
