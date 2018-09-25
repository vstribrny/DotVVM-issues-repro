using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;
using GridViewAndMarkupControlCommand.ViewModels;

namespace GridViewAndMarkupControlCommand.Controls
{
    public class MyMarkupControl : DotvvmMarkupControl
    {
        //public RootItem SampleContext
        //{
        //    get { return (RootItem)GetValue(SampleContextProperty); }
        //    set { SetValue(SampleContextProperty, value); }
        //}
        //public static readonly DotvvmProperty SampleContextProperty = DotvvmProperty.Register<RootItem, MyMarkupControl>(c => c.SampleContext, null);


        /// <summary>
        /// Gets or sets the command that will be triggered when the control text is changed.
        /// </summary>
        public Command Changed
        {
            get { return (Command)GetValue(ChangedProperty); }
            set { SetValue(ChangedProperty, value); }
        }

        public static readonly DotvvmProperty ChangedProperty =
            DotvvmProperty.Register<Command, MyMarkupControl>(t => t.Changed, null);
    }
}

