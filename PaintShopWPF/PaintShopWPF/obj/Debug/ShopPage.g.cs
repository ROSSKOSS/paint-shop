﻿#pragma checksum "..\..\ShopPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1CAAD7757382095CE01A9DD64ABEF078"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PaintShopWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace PaintShopWPF {
    
    
    /// <summary>
    /// ShopPage
    /// </summary>
    public partial class ShopPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PaintShopWPF.ShopPage Boop;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid shopHost;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel elementsHost;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid paintType;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid brandType;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel brandOptions;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ShopPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel paintOptions;
        
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
            System.Uri resourceLocater = new System.Uri("/PaintShopWPF;component/shoppage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ShopPage.xaml"
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
            this.Boop = ((PaintShopWPF.ShopPage)(target));
            
            #line 8 "..\..\ShopPage.xaml"
            this.Boop.Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.shopHost = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.elementsHost = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 4:
            this.paintType = ((System.Windows.Controls.Grid)(target));
            
            #line 20 "..\..\ShopPage.xaml"
            this.paintType.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.paintType_MouseDown);
            
            #line default
            #line hidden
            
            #line 20 "..\..\ShopPage.xaml"
            this.paintType.MouseEnter += new System.Windows.Input.MouseEventHandler(this.paintType_MouseEnter);
            
            #line default
            #line hidden
            
            #line 20 "..\..\ShopPage.xaml"
            this.paintType.MouseLeave += new System.Windows.Input.MouseEventHandler(this.paintType_MouseLeave);
            
            #line default
            #line hidden
            
            #line 20 "..\..\ShopPage.xaml"
            this.paintType.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.paintType_MouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.brandType = ((System.Windows.Controls.Grid)(target));
            
            #line 23 "..\..\ShopPage.xaml"
            this.brandType.MouseLeave += new System.Windows.Input.MouseEventHandler(this.brandType_MouseLeave);
            
            #line default
            #line hidden
            
            #line 23 "..\..\ShopPage.xaml"
            this.brandType.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.brandType_MouseDown);
            
            #line default
            #line hidden
            
            #line 23 "..\..\ShopPage.xaml"
            this.brandType.MouseEnter += new System.Windows.Input.MouseEventHandler(this.brandType_MouseEnter);
            
            #line default
            #line hidden
            
            #line 23 "..\..\ShopPage.xaml"
            this.brandType.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.brandType_MouseUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.brandOptions = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 9:
            this.paintOptions = ((System.Windows.Controls.WrapPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

