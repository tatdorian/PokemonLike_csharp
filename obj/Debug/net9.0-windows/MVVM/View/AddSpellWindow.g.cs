﻿#pragma checksum "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D241CA52B0FE0CB5EC4E864D0C100212CF0A751"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace PokemonLikeCsharp {
    
    
    /// <summary>
    /// AddSpellWindow
    /// </summary>
    public partial class AddSpellWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SpellsListBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SpellDescriptionTextBlock;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SpellDamageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PokemonLikeCsharp;component/mvvm/view/addspellwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SpellsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 41 "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml"
            this.SpellsListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SpellsListBox_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml"
            this.SpellsListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SpellsListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SpellDescriptionTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.SpellDamageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\..\MVVM\View\AddSpellWindow.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

