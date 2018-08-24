using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using InitComboInMarkupControl.ViewModels;

namespace InitComboInMarkupControl.Controls
{
    public class MyMarkupControl : DotvvmMarkupControl
    {
        public List<BasicDTO> MyDataSource
        {
            get { return (List<BasicDTO>)GetValue(MyDataSourceProperty); }
            set { SetValue(MyDataSourceProperty, value); }
        }
        public static readonly DotvvmProperty MyDataSourceProperty
            = DotvvmProperty.Register<List<BasicDTO>, MyMarkupControl>(c => c.MyDataSource, null);

        public int MyNumber
        {
            get { return (int)GetValue(MyNumberProperty); }
            set { SetValue(MyNumberProperty, value); }
        }
        public static readonly DotvvmProperty MyNumberProperty
            = DotvvmProperty.Register<int, MyMarkupControl>(c => c.MyNumber, default(int));

        [MarkupOptions(AllowHardCodedValue = false)]
        public string MyText
        {
            get { return (string)GetValue(MyTextProperty); }
            set { SetValue(MyTextProperty, value); }
        }
        public static readonly DotvvmProperty MyTextProperty
            = DotvvmProperty.Register<string, MyMarkupControl>(c => c.MyText, null);

        protected override void OnInit(IDotvvmRequestContext context)
        {
            base.OnInit(context);

            // The question is how to initialize ComboBox's DataSource (or other control's property) in code-behind of Custom Markup Control
            // without having to specify special View Model of this Markup Control.
            // (i.e. keeping System.Object to not force to bind MarkupControl's DataContext - it gets unnecessarily complicated then).

            // DOES NOT WORK:
            this.MyDataSource = Enumerable.Range(0, 3).Select(x => new BasicDTO { Id = x, Text = string.Format("Number {0}", x) }).ToList();

            MyText = "abc"; // WORKS
        }

        protected override void OnLoad(IDotvvmRequestContext context)
        {
            base.OnLoad(context);
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            base.OnPreRender(context);

            // DataSource is bound correctly at server-side:
            var comboBox = this.FindControlByClientId<DotVVM.Framework.Controls.ComboBox>("combobox");
            var ds = (List<BasicDTO>)comboBox.DataSource;
            System.Diagnostics.Debug.Assert(ds.Count == 3, "Count should be 3"); // It's OK here, DataSource is bound correctly !!!
        }
    }
}

