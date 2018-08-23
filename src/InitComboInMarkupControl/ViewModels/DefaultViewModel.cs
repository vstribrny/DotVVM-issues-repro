using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.BusinessPack.Controls;

namespace InitComboInMarkupControl.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public List<Item> Items { get; set; }

        public DefaultViewModel()
        {
            Items = Enumerable.Range(0, 3).Select(x => new Item { Number = x }).ToList();
        }
    }

    public class Item
    {
        public int Number { get; set; }
    }

    public class BasicDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }

}
