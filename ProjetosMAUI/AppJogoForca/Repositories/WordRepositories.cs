using AppJogoForca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJogoForca.Repositories
{
    public class WordRepositories
    {
        private List<Word> _words;
        public WordRepositories() { 
            _words = new List<Word>();
            _words.Add(new Word("Nome", "Maria"));
            _words.Add(new Word("Vegetal", "Cenoura"));
            _words.Add(new Word("Fruta", "Abacate"));
            _words.Add(new Word("Tempero", "Nordestino"));
            _words.Add(new Word("Tempero", "Baiano"));
        }
        public Word GetRandomWord()
        {
            Random rand = new Random();
            var number = rand.Next(0, _words.Count);
            return _words[number];
        }
    }
}
