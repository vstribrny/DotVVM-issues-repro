using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.BusinessPack.Controls;

namespace GridViewAndMarkupControlCommand.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public string MyText { get; set; }

        public BusinessPackDataSet<Item> DataSet { get; set; } = new BusinessPackDataSet<Item>();

        public DefaultViewModel()
        {
            DataSet.Items = Enumerable.Range(0, 5).Select(x => new Item { Number = x }).ToList();
        }

        public void OnValueChanged(int collectionIndex)
        {
            var item = DataSet.Items[collectionIndex];
            MyText = item.Number.ToString();

            if (collectionIndex == 0)
            {
                DataSet.Items[collectionIndex + 1].Number = item.Number + 1;
            }
        }
    }


    public class Item
    {
        public double Number { get; set; }
    }
}
