﻿#pragma checksum "..\..\..\ConfirmarIntegracion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "39A016D106C66EB3195956E05FCD72D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36373
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RibbonView;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Shapes;


namespace OrganismosPjf2015 {
    
    
    /// <summary>
    /// ConfirmarIntegracion
    /// </summary>
    public partial class ConfirmarIntegracion : Telerik.Windows.Controls.RadWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\ConfirmarIntegracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadListBox LstIntegracion;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\ConfirmarIntegracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadListBox LstDiscards;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\ConfirmarIntegracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadButton BtnElimina;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\ConfirmarIntegracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadButton BtnReasigna;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\ConfirmarIntegracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadButton BtnAceptar;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\ConfirmarIntegracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadButton BtnVer;
        
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
            System.Uri resourceLocater = new System.Uri("/OrganismosPjf2015;component/confirmarintegracion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ConfirmarIntegracion.xaml"
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
            
            #line 8 "..\..\..\ConfirmarIntegracion.xaml"
            ((OrganismosPjf2015.ConfirmarIntegracion)(target)).Loaded += new System.Windows.RoutedEventHandler(this.RadWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LstIntegracion = ((Telerik.Windows.Controls.RadListBox)(target));
            return;
            case 3:
            this.LstDiscards = ((Telerik.Windows.Controls.RadListBox)(target));
            return;
            case 4:
            this.BtnElimina = ((Telerik.Windows.Controls.RadButton)(target));
            
            #line 49 "..\..\..\ConfirmarIntegracion.xaml"
            this.BtnElimina.Click += new System.Windows.RoutedEventHandler(this.BtnElimina_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnReasigna = ((Telerik.Windows.Controls.RadButton)(target));
            
            #line 57 "..\..\..\ConfirmarIntegracion.xaml"
            this.BtnReasigna.Click += new System.Windows.RoutedEventHandler(this.BtnReasigna_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnAceptar = ((Telerik.Windows.Controls.RadButton)(target));
            
            #line 65 "..\..\..\ConfirmarIntegracion.xaml"
            this.BtnAceptar.Click += new System.Windows.RoutedEventHandler(this.BtnAceptar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnVer = ((Telerik.Windows.Controls.RadButton)(target));
            
            #line 73 "..\..\..\ConfirmarIntegracion.xaml"
            this.BtnVer.Click += new System.Windows.RoutedEventHandler(this.BtnVer_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

