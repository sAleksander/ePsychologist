﻿#pragma checksum "..\..\homePatient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "48BEFD06A5EEB971A2C0B26D1FF9FF5007E56E901376CDFB083E6F07056CB0B9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
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
using ePsychologist;


namespace ePsychologist {
    
    
    /// <summary>
    /// homePatient
    /// </summary>
    public partial class homePatient : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\homePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label homePatientLabel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\homePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label homePatientTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\homePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sicknessInfoButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\homePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame sickInfoFrame;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\homePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editPersonalInfoButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\homePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame editPersonalInfoFrame;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\homePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logOutButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\homePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TryLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/ePsychologist;component/homepatient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\homePatient.xaml"
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
            this.homePatientLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.homePatientTextBox = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.sicknessInfoButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\homePatient.xaml"
            this.sicknessInfoButton.Click += new System.Windows.RoutedEventHandler(this.sicknessInfoButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.sickInfoFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 5:
            this.editPersonalInfoButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\homePatient.xaml"
            this.editPersonalInfoButton.Click += new System.Windows.RoutedEventHandler(this.editPersonalInfoButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.editPersonalInfoFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 7:
            this.logOutButton = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.TryLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

