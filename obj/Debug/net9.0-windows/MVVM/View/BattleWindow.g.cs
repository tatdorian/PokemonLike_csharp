﻿#pragma checksum "..\..\..\..\..\MVVM\View\BattleWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0AD623A646CC19CE396625423E00A61FB2BEF28C"
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
    /// BattleWindow
    /// </summary>
    public partial class BattleWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 53 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TurnIndicator;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblPlayerName;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPlayerPokemon;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar pbPlayerHealth;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstPlayerSpells;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblEnemyName;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgEnemyPokemon;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar pbEnemyHealth;
        
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
            System.Uri resourceLocater = new System.Uri("/PokemonLikeCsharp;component/mvvm/view/battlewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
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
            this.TurnIndicator = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.lblPlayerName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.imgPlayerPokemon = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.pbPlayerHealth = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 5:
            this.lstPlayerSpells = ((System.Windows.Controls.ListBox)(target));
            
            #line 60 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
            this.lstPlayerSpells.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lstPlayerSpells_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblEnemyName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.imgEnemyPokemon = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.pbEnemyHealth = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 9:
            
            #line 73 "..\..\..\..\..\MVVM\View\BattleWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RunButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

