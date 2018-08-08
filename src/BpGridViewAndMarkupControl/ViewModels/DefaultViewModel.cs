using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.BusinessPack.Controls;

namespace BpGridViewAndMarkupControl.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel, IMyMarkupControlViewMOdel
    {
        public string MyText { get; set; }


        public BusinessPackDataSet<Item> DataSet { get; set; } = new BusinessPackDataSet<Item>();

        public DefaultViewModel()
        {
            DataSet.Items = Enumerable.Range(0, 5).Select(x => new Item { Number = x }).ToList();
        }

        public void SetMyText()
        {
            MyText = DateTime.Now.ToString();
        }
    }

    public class Item
    {
        public double Number { get; set; }
    }

    public interface IMyMarkupControlViewMOdel
    {
        void SetMyText();
    }


}
