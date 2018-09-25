using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace GridViewAndMarkupControlCommand.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public RootItem RootItem { get; set; } = new RootItem { MyText = "init text" };

        public List<Item> MyDataSource { get; set; }

        public DefaultViewModel()
        {
            MyDataSource = Enumerable.Range(0, 5).Select(x => new Item { Number = x }).ToList();
        }

        public void OnValueChanged(int collectionIndex)
        {
        }
    }

    public class RootItem
    {
        public string MyText { get; set; }
    }

    public class Item
    {
        public double Number { get; set; }
    }

    public class MyService
    {
        [AllowStaticCommand]
        public void OnChanged(Item item, RootItem rootItem) // DOES NOT WORK
        {
            rootItem.MyText = item.Number.ToString();
        }

        [AllowStaticCommand]
        public System.Delegate OnChangedHacked(Item item, RootItem rootItem) // WORKS
        {
            rootItem.MyText = item.Number.ToString();
            return new DotVVM.Framework.Binding.Expressions.Command(DummyTask);
        }

        private Task DummyTask()
        {
            return Task.CompletedTask;
        }
    }
}
