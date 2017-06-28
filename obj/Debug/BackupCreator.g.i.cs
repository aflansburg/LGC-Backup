#pragma checksum "..\..\BackupCreator.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "13D131F61EB94C82E45008E84206799A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LGCBackupGui;
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


namespace LGCBackupGui
{


    /// <summary>
    /// BackupCreator
    /// </summary>
    public partial class BackupCreator : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 14 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox sourceListbox;

#line default
#line hidden


#line 15 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox destinationListbox;

#line default
#line hidden


#line 16 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addSourceBtn;

#line default
#line hidden


#line 17 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addDestinationBtn;

#line default
#line hidden


#line 18 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock sourceTextBlock;

#line default
#line hidden


#line 19 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock destinationTextBlock;

#line default
#line hidden


#line 20 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveJobBtn;

#line default
#line hidden


#line 21 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jobNameTxtBox;

#line default
#line hidden


#line 22 "..\..\BackupCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label promptJobNameLbl;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LGC-Backup;component/backupcreator.xaml", System.UriKind.Relative);

#line 1 "..\..\BackupCreator.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.sourceListbox = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 2:
                    this.destinationListbox = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 3:
                    this.addSourceBtn = ((System.Windows.Controls.Button)(target));

#line 16 "..\..\BackupCreator.xaml"
                    this.addSourceBtn.Click += new System.Windows.RoutedEventHandler(this.addSourceBtn_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.addDestinationBtn = ((System.Windows.Controls.Button)(target));

#line 17 "..\..\BackupCreator.xaml"
                    this.addDestinationBtn.Click += new System.Windows.RoutedEventHandler(this.addDestinationBtn_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.sourceTextBlock = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 6:
                    this.destinationTextBlock = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 7:
                    this.saveJobBtn = ((System.Windows.Controls.Button)(target));

#line 20 "..\..\BackupCreator.xaml"
                    this.saveJobBtn.Click += new System.Windows.RoutedEventHandler(this.saveJobBtn_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.jobNameTxtBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 9:
                    this.promptJobNameLbl = ((System.Windows.Controls.Label)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button closeBtn;
    }
}
