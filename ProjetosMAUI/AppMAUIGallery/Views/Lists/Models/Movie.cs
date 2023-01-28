using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Lists.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public TimeSpan Duration { get; set; }
        public short LaunchYear { get; set; }
    }

    public class MovieList
    {
        public static List<Movie> GetList()
        {
            List<Movie> list = new List<Movie>();
            list.Add(new Movie() { 
                Id = 1, 
                Name = "Emancipation", 
                Description = "Emancipation é um longa-metragem thriller de ação e drama histórico estadunidense dirigido por Antonie Fuqua, escrito por Willian N.Collage, estrelado por Will Smith lançado em 2022 acerca de um homem",
                LaunchYear = 2022,
                Duration = new TimeSpan(2, 12, 0)
            });
            list.Add(new Movie()
            {
                Id = 2,
                Name = "Tudo em Todo o Lugar ao Mesmo Tempo",
                Description = "Uma ruptura interdimensional bagunça a realidade e uma inesperada heroína precisa usar seus novos poderes para lutar contra os perigos bizarros do multiverso.",
                LaunchYear = 2022,
                Duration = new TimeSpan(2, 19, 0)
            });
            list.Add(new Movie() { 
                Id = 3,
                Name = "O menu",
                Description = "Uma ruptura interdimensional bagunça a realidade e uma inesperada heroína precisa usar seus novos poderes para lutar contra os perigos bizarros do multiverso.",
                LaunchYear = 2022,
                Duration = new TimeSpan(1, 46, 0)
            });
            list.Add(new Movie()
            {
                Id = 4,
                Name = "Não! Não Olhe!",
                Description = "Os cuidadores de um rancho de cavalos na Califórnia encontram uma força misteriosa que afeta o comportamento humano e animal.",
                LaunchYear = 2022,
                Duration = new TimeSpan(2, 10, 0)
            });
            list.Add(new Movie()
            {
                Id = 5,
                Name = "Irmãos de Honra",
                Description = "A história de Jesse Brown, o primeiro aviador negro na história da Marinha, e seu colega piloto de caça Tom Hudner. Ajudando a virar a maré na batalha mais brutal da Guerra da Coreia, seus sacrifícios heroicos os tornam os alas mais importantes.",
                LaunchYear = 2022,
                Duration = new TimeSpan(2, 19, 0)
            });
            list.Add(new Movie()
            {
                Id = 6,
                Name = "Trem-Bala (Bullet Train)",
                Description = "Em um trem-bala indo rapidamente de Tóquio a Morioka, cinco assassinos profissionais descobrem que possuem o mesmo objetivo.",
                LaunchYear = 2022,
                Duration = new TimeSpan(2, 6, 0)
            });
            list.Add(new Movie() { 
                Id = 7,
                Name = "The Pale Blue Eye",
                Description = "Um detetive aposentado recruta um cadete chamado Edgar Allan Poe para ajudar a investigar um terrível assassinato na Academia Militar dos EUA.",
                LaunchYear = 2022,
                Duration = new TimeSpan(2, 8, 0)
            });
            list.Add(new Movie()
            {
                Id = 8,
                Name = "Casamento Armado (Shotgun Wedding)",
                Description = "Shotgun Wedding é um futuro filme de comédia romântica estadunidense dirigido por Jason Moore com roteiro de Mark Hammer e Liz Meriwether. O filme é estrelado por Josh Duhamel e Jennifer Lopez e será distribuído pela Lionsgate Films. ",
                LaunchYear = 2022,
                Duration = new TimeSpan(1, 40, 0)
            });
            list.Add(new Movie()
            {
                Id = 9,
                Name = "Sorria",
                Description = "Após um paciente cometer um suicídio brutal em sua frente, a psiquiatra Rose é perseguida por uma entidade maligna que muda de forma. Enquanto tenta escapar desse pesadelo, Rose também precisa enfrentar seu passado conturbado para sobreviver.",
                LaunchYear = 2022,
                Duration = new TimeSpan(1, 55, 0)
            });
            list.Add(new Movie()
            {
                Id = 10,
                Name = "O Telefone Preto",
                Description = "Finney Shaw, de 13 anos, é sequestrado por um sádico assassino mascarado e mantido em um porão à prova de som. Até que um telefone desconectado na parede começa a tocar, e ele logo descobre que pode ouvir as vozes das vítimas anteriores do maníaco.",
                LaunchYear = 2021,
                Duration = new TimeSpan(1, 42, 0)
            });
            
            return list;
        }
    }
}
