﻿#pragma checksum "..\..\MyMessageBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A917F09A2A94088814DBF374EBC8DC0684CA83417EB705C57BA6F5D01BC0AAE9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using NTI_project;
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
using WpfAnimatedGif;


namespace NTI_project {
    
    
    /// <summary>
    /// MyMessageBox
    /// </summary>
    public partial class MyMessageBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Up;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Toolbar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Polygon Dragger;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border close_Button;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Text;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid YesNoGrid;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button YesButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NoButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid OkGrid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MyMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkButton;
        
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
            System.Uri resourceLocater = new System.Uri("/NTI_project;component/mymessagebox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MyMessageBox.xaml"
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
            
            #line 10 "..\..\MyMessageBox.xaml"
            ((NTI_project.MyMessageBox)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Window_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Up = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Toolbar = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.Dragger = ((System.Windows.Shapes.Polygon)(target));
            
            #line 21 "..\..\MyMessageBox.xaml"
            this.Dragger.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Toolbar_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.close_Button = ((System.Windows.Controls.Border)(target));
            
            #line 24 "..\..\MyMessageBox.xaml"
            this.close_Button.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.close_Button_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 24 "..\..\MyMessageBox.xaml"
            this.close_Button.MouseEnter += new System.Windows.Input.MouseEventHandler(this.close_Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 24 "..\..\MyMessageBox.xaml"
            this.close_Button.MouseLeave += new System.Windows.Input.MouseEventHandler(this.close_Button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 24 "..\..\MyMessageBox.xaml"
            this.close_Button.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.close_Button_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.YesNoGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.YesButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\MyMessageBox.xaml"
            this.YesButton.Click += new System.Windows.RoutedEventHandler(this.YesButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.NoButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\MyMessageBox.xaml"
            this.NoButton.Click += new System.Windows.RoutedEventHandler(this.NoButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.OkGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.OkButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\MyMessageBox.xaml"
            this.OkButton.Click += new System.Windows.RoutedEventHandler(this.NoButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

