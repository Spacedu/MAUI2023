using AppShoppingCenter.Models;
using AppShoppingCenter.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Services
{
    public class RestaurantService
    {
        public List<Establishment> GetRestaurants()
        {
            return MockRestaurantService.GetRestaurants();
        }
    }
    public class MockRestaurantService
    {
        public static List<Establishment> GetRestaurants()
        {
            return new List<Establishment>
            {
                new Establishment()
                {
                    Id = 31,
                    Name = "OUTBACK",
                    Description = "Outback Steakhouse",
                    Localization = "3 Andar - Loja 01/02/03/04 - Entrada Sul",
                    Phone = "(61) 3550-1874",
                    Type = EstablishmentType.Restaurant,
                    
                    Logo = "https://botw-pd.s3.amazonaws.com/styles/logo-thumbnail/s3/102014/logo_outback.png?itok=dKkkYi4q",
                    Cover = "https://www.parkshopping.com.br/sites/pks/files/styles/loja670x455/public/lojas/outback-01.jpg?itok=E5clX0sk"
                },
                new Establishment()
                {
                    Id = 32,
                    Name = "GIRAFFAS",
                    Description = "O Giraffas é uma rede de restaurantes de culinária brasileira que serve seus pratos de forma saborosa e criativa.",
                    Localization = "3 Andar - Loja 05/06/07 - Entrada Sul",
                    Phone = "(61) 3550-1874",
                    Type = EstablishmentType.Restaurant,
                    
                    Logo = "https://publicidadeecerveja.files.wordpress.com/2016/03/imagem_release_619527.jpg",
                    Cover = "https://storage.tgs-api.com/storage/images-tgs/uploads/2011/10/giraffas.jpg"
                },
                new Establishment()
                {
                    Id = 33,
                    Name = "MC DONALD’S",
                    Description = "Quiosque de sorvetes e milk shakes do Mc Donald’s.",
                    Localization = "3 Andar - Loja 08/09/10/11 - Entrada Sul",
                    Phone = "(61) 3550-1874",
                    Type = EstablishmentType.Restaurant,
                    
                    Logo = "https://cdn-icons-png.flaticon.com/512/732/732217.png",
                    Cover = "https://designportugal.net/wp-content/uploads/2016/04/m-mcdonalds.jpg"
                },
                new Establishment()
                {
                    Id = 34,
                    Name = "BOB’S",
                    Description = "O Bob’s é uma rede de restaurantes fast-food que busca atender às expectativas do consumidor através de um produto de qualidade e uma equipe sempre motivada.",
                    Localization = "3 Andar - Loja 13/14 - Entrada Sul",
                    Phone = "(61) 3491-1031",
                    Type = EstablishmentType.Restaurant,
                    
                    Logo = "https://logospng.org/download/bobs/logo-bobs-256.png",
                    Cover = "https://media.gazetadopovo.com.br/2017/08/16f83afd03f1a7de43b11b2ca731a8d1-gpLarge.jpg"
                },
                new Establishment()
                {
                    Id = 35,
                    Name = "BURGER KING",
                    Description = "O BURGER KING® é a segunda maior rede de hambúrgueres do mundo. Lar original do WHOPPER®, um dos mais pedidos da franquia.",
                    Localization = "3 Andar - Loja 15/16 - Entrada Sul",
                    Phone = "**",
                    Type = EstablishmentType.Restaurant,
                    
                    Logo = "https://logospng.org/download/burger-king/logo-burger-king-256.png",
                    Cover = "https://revistalivemarketing.com.br/wp-content/uploads/2023/01/Burger-King-oferece-promocoes-exclusivas-no-BK-Drive.png"
                },
                new Establishment()
                {
                    Id = 36,
                    Name = "CHOCOLATES BRASIL CACAU",
                    Description = "A Brasil Cacau é uma bomboniére que oferece produtos diversificados para agradar a todos os tipos de amantes do chocolate.",
                    Localization = "3 Andar - Loja 17/18 - Entrada Sul",
                    Phone = "(61) 3491-2255",
                    Type = EstablishmentType.Restaurant,
                    
                    Logo = "https://3.bp.blogspot.com/-sXotIRuVUp4/T2tI3C89l8I/AAAAAAAAAHE/qcowULZfBWs/s950/Logo%2Bblog.jpg",
                    Cover = "https://media-cdn.tripadvisor.com/media/photo-s/0b/ec/ac/d7/e-uma-lojinha-muito-pequena.jpg"
                },
                new Establishment()
                {
                    Id = 37,
                    Name = "CACAU SHOW",
                    Description = "A Cacau Show é uma loja de chocolates conhecida nacionalmente que oferece produtos variados da área de bomboniére.",
                    Localization = "3 Andar - Loja 19 - Entrada Sul",
                    Phone = "(61) 3475-2779",
                    Type = EstablishmentType.Restaurant,

                    Logo = "https://th.bing.com/th/id/OIP.bu6ExCsGqSc1mE3-76gLWAAAAA?pid=Api&rs=1",
                    Cover = "https://media.gazetadopovo.com.br/2021/10/21185717/BOX-960x540.jpg"
                },
                new Establishment()
                {
                    Id = 38,
                    Name = "DIVINO FOGÃO",
                    Description = "O Divino Fogão é um restaurante que oferece comida típica da fazenda num cardápio saboroso e variado.",
                    Localization = "3 Andar - Loja 20 - Entrada Sul",
                    Phone = "(61) 3491-1124",
                    Type = EstablishmentType.Restaurant,

                    Logo = "https://www.partageshoppingbetim.com.br/wp-content/uploads/sites/3/2022/11/divino_fogao_logo.png",
                    Cover = "https://www.divinofogao.com.br/wp-content/uploads/2021/03/DF-MOGI_GUA%C3%87U-FINAL-CAM2-REV04-01-1024x768.jpg"
                },
                new Establishment()
                {
                    Id = 39,
                    Name = "FRANGO NO POTE",
                    Description = "O Frango no Pote é uma rede que não para de crescer. Oferece porções de frango, refrigerantes e lanches.",
                    Localization = "3 Andar - Loja 21 - Entrada Sul",
                    Phone = "(61) 3475-2786",
                    Type = EstablishmentType.Restaurant,

                    Logo = "https://media.licdn.com/dms/image/C4E0BAQHFWosTfv8UjQ/company-logo_200_200/0/1625835920705?e=2147483647&v=beta&t=THt3PBBL4zW1qb3hZ5BVk_gWGnQ0_1AW6osEMs1XIsI",
                    Cover = "https://i.pinimg.com/originals/a3/83/72/a3837234e132cb530811c4066b45c896.png"
                },
                new Establishment()
                {
                    Id = 40,
                    Name = "SPOLETO",
                    Description = "O Spoleto é um restaurante italiano que visa valorizar as relações, manter a qualidade nos produtos e serviços e aprimorar e inovar cada vez mais com foco nas pessoas e respeito à concorrência.",
                    Localization = "3 Andar - Loja 22 - Entrada Sul",
                    Phone = "(61) 3491-1031",
                    Type = EstablishmentType.Restaurant,

                    Logo = "https://upload.wikimedia.org/wikipedia/pt/thumb/8/80/Spoleto_logo.png/120px-Spoleto_logo.png",
                    Cover = "https://pwaservicesappbr.blob.core.windows.net/imagens-cardapio/image_13032023122809.png"
                },
            };
        }
    }
}
