using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Models;
namespace AppShoppingCenter.Services
{
    public class StoreService
    {
        public List<Establishment> GetStores()
        {
            return MockStoreService.GetStore();
        }
    }

    public class MockStoreService
    {
        public static List<Establishment> GetStore()
        {
            return new List<Establishment>
            {
                new Establishment
                {
                    Id = 1,
                    Name = "Arezzo", 
                    Description = "Fundada em 1972 pelos irmãos Anderson e Jefferson Birman, a Arezzo comemora 50 anos de uma história dedicada a arte de transitar pelo mundo da moda e traduzir tendências para mulheres da vida real.\r\n\r\nHoje, a Arezzo é a maior marca de varejo de calçados femininos fashion da América Latina e conta com 450 lojas em sua rede de franquias, estando presente em 180 municípios de todos os estados brasileiros",
                    Localization = "1 Piso, Loja 01 - Setor Norte",
                    Phone = "(61) 3154-5583",
                    Type = Models.Enums.EstablishmentType.Store,

                    Logo = "https://logodownload.org/wp-content/uploads/2019/09/arezzo-logo.png",
                    Cover = "https://www.estadao.com.br/resizer/rBqzc0YbW4dBIs4uZIXLJ8qaZTE=/arc-anglerfish-arc2-prod-estadao/public/KP7KNT6STVP5PCSIQOMJMAT3HY.jpg"
                }
            };
        }
    }
}
