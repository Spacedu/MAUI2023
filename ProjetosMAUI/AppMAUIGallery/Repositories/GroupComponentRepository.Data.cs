using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Repositories
{
    public partial class GroupComponentRepository : IGroupComponentRepository
    {
        private void LoadData()
        {
            _components = new List<Component>();
            _groupComponents = new List<GroupComponent>();

            LoadLayout();
        }

        private void LoadLayout()
        {
            var components = new List<Component> {
                new Component {
                    Title = "StackLayout",
                    Description = "Organização sequencial dos elementos.",
                    Page = typeof(StackLayoutPage)
                },
                new Component
                {
                    Title = "Grid",
                    Description = "Organiza os elementos dentro de uma tabela.",
                    Page = typeof(GridLayoutPage)
                },
                new Component
                {
                    Title = "AbsoluteLayout",
                    Description = "Liberdade total para posicionar e dimensionar os elementos na tela.",
                    Page = typeof(AbsoluteLayoutPage)
                },
                new Component
                {
                    Title = "FlexLayout",
                    Description = "Organiza os elementos de forma sequencial com muitas opções de personalização.",
                    Page = typeof(FlexLayoutPage)
                }
            };

            var group = new GroupComponent() { Name = "Layout" };
            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }
    }
}
