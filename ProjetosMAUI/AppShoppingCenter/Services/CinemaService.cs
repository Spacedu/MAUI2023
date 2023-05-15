using AppShoppingCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Services
{
    public class CinemaService
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>
            {

            };
        }
    }

    public class MockCinemaService
    {
        public static List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Animais fantásticos\r\nO segredo de Dumbledore",
                    Description = "O professor Alvo Dumbledore (Jude Law) sabe que o poderoso mago das trevas Gellert Grindelwald (Mads Mikkelsen) está se movimentando para assumir o controle do mundo mágico. Incapaz de detê-lo sozinho, ele pede ao magizoologista Newt Scamander (Eddie Redmayne) para liderar uma intrépida equipe de b",
                    Duration = new TimeOnly(2, 23,0),
                    
                    Cover = "https://upload.wikimedia.org/wikipedia/pt/b/b7/Fantastic_Beasts_The_Secrets_of_Dumbledore_poster_IMP.jpg",
                    Trailer = ""
                },
                new Movie
                {
                    Id = 2,
                    Name = "Os Três Mosqueteiros: D’Artagnan",
                    Description = "D'Artagnan, um jovem gascão espirituoso, é deixado para morrer depois de tentar salvar uma jovem de ser sequestrada. Ao chegar a Paris, ele tenta por todos os meios encontrar seus agressores. Ele não sabe que sua busca o levará ao centro de uma guerra real onde o futuro da França está em jogo.",
                    Duration = new TimeOnly(2, 1,0),

                    Cover = "https://br.web.img3.acsta.net/c_310_420/pictures/23/04/14/22/00/1046089.jpg",
                    Trailer = ""
                },
                new Movie
                {
                    Id = 3,
                    Name = "Super Mario Bros. O Filme",
                    Description = "Mario é um encanador junto com seu irmão Luigi. Um dia, eles vão parar no reino dos cogumelos, governado pela Princesa Peach, mas ameaçado pelo rei dos Koopas, que faz de tudo para conseguir reinar em todos os lugares.",
                    Duration = new TimeOnly(1, 32,0),

                    Cover = "https://br.web.img2.acsta.net/pictures/23/04/03/19/45/2854005.jpg",
                    Trailer = ""
                },

            };
        }

    }
}
