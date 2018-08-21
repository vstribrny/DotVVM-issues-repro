using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.BusinessPack.Controls;

namespace BpComboBoxInItemsControl.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public int DataSourceId { get; set; } = 1;

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<BasicDTO> DataSources { get; set; }

        public List<Item> Items { get; set; }
        private readonly DataSourceService _dataSourceService;

        public DefaultViewModel(DataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;

            this.DataSources = new List<BasicDTO>(new[] { new BasicDTO { Id = 0, Text = "Empty Items" },  new BasicDTO { Id = 1, Text = "DataSource 1" }, new BasicDTO { Id = 2, Text = "DataSource 2" } });
        }

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                Items = _dataSourceService.GetDataSource(DataSourceId);
            }

            return base.PreRender();
        }
    }

    public class Item
    {
        public int Number { get; set; }
        public List<BasicDTO> Numbers { get; set; }
    }

    public class BasicDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }

    public class DataSourceService
    {
        [AllowStaticCommand]
        public List<Item> GetDataSource(int dataSourceId)
        {
            var ítems = new List<Item>();
            if (dataSourceId == 0)
                return ítems;

            var numbers1 = new[] { 1, 2, 3 }.Select(x => new BasicDTO { Id = x, Text = string.Format("Number {0}", x) }).ToList();
            var numbers2 = new[] { 4, 5, 6 }.Select(x => new BasicDTO { Id = x, Text = string.Format("Number {0}", x) }).ToList();

            ítems.Add(new Item { Number = 2, Numbers = numbers1 });
            ítems.Add(new Item { Number = 5, Numbers = numbers2 });

            if (dataSourceId == 2)
            {
                ítems.Reverse(); // in-place reverse (returns void)
            }

            return ítems;
        }
    }
}
