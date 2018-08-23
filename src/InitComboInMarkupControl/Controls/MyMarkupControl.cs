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
        public List<Item> DataSource
        {
            get { return (List<Item>)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }
        public static readonly DotvvmProperty DataSourceProperty
            = DotvvmProperty.Register<List<Item>, MyMarkupControl>(c => c.DataSource, null);

        public List<BasicDTO> ComboBoxDataSource
        {
            get { return (List<BasicDTO>)GetValue(ComboBoxDataSourceProperty); }
            set { SetValue(ComboBoxDataSourceProperty, value); }
        }
        public static readonly DotvvmProperty ComboBoxDataSourceProperty
            = DotvvmProperty.Register<List<BasicDTO>, MyMarkupControl>(c => c.ComboBoxDataSource, null);

        public int SelectedNumber
        {
            get { return (int)GetValue(SelectedNumberProperty); }
            set { SetValue(SelectedNumberProperty, value); }
        }
        public static readonly DotvvmProperty SelectedNumberProperty
            = DotvvmProperty.Register<int, MyMarkupControl>(c => c.SelectedNumber, default(int));


        protected override void OnInit(IDotvvmRequestContext context)
        {
            base.OnInit(context);

            // The question is how to initialize ComboBox's DataSource in code-behind of Custom Markup Control
            // without having to specify special View Model of this Markup Control.
            // (i.e. keeping System.Object to not force to bind MarkupControl's DataContext - it gets unnecessarily complicated then).
            InitComboBoxDataSource();
        }

        private void InitComboBoxDataSource()
        {
            this.ComboBoxDataSource = Enumerable.Range(0, 3).Select(x => new BasicDTO { Id = x, Text = string.Format("Number {0}", x) }).ToList();
        }


        protected override void OnLoad(IDotvvmRequestContext context)
        {
            base.OnLoad(context);
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            base.OnPreRender(context);

            var placeholder = this.Children.OfType<PlaceHolder>().Single();
            var topCombo = placeholder.Children.OfType<ComboBox>().Single();
            AssertComboBoxDataSource(topCombo);

            var repeater = placeholder.Children.OfType<Repeater>().Single();
            foreach (var container in repeater.Children.Cast<DataItemContainer>())
            {
                var comboBox = container.Children.OfType<ComboBox>().Single();
                AssertComboBoxDataSource(comboBox);
            }

        }

        private void AssertComboBoxDataSource(ComboBox comboBox)
        {
            var ds = (List<BasicDTO>)comboBox.DataSource;
            System.Diagnostics.Debug.Assert(ds.Count == 3, "Count should be 3"); // It's OK here, DataSource is bound correctly!
        }
    }
}

