﻿#pragma checksum "..\..\..\..\..\Views\Popup\CustomDayButton.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "400D01C8AAFC70CCE9A5CB05410D7F6E9C2F352C"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using DiaryApp.Views.Popup;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace DiaryApp.Views.Popup {
    
    
    /// <summary>
    /// CustomDayButton
    /// </summary>
    public partial class CustomDayButton : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\Views\Popup\CustomDayButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DayButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\Views\Popup\CustomDayButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DayText;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Views\Popup\CustomDayButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DayImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DiaryApp;component/views/popup/customdaybutton.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Popup\CustomDayButton.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DayButton = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.DayText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.DayImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
