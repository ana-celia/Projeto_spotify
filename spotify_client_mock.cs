using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotifyListaEncadeada
{
    /// Classe mock que simula o cliente da API do Spotify.
    /// Retorna dados fictícios de músicas para teste da estrutura de dados.
    ///Seria substituída por um cliente real usando SpotifyAPI-NET.
    public class SpotifyClientMock
    {
        private readonly Dictionary<string, List<Musica>> bancoDeDados;

        public SpotifyClientMock()
        {
            Console.WriteLine("Inicializando cliente Spotify (Mock)...");
            bancoDeDados = InicializarDados();
            Console.WriteLine("Cliente mock autenticado com sucesso.\n");
        }

        /// Busca músicas de um artista (simulação).
        /// <param name="nomeArtista">Nome do artista</param>
        /// <param name="quantidade">Quantidade de músicas desejadas</param>
        /// <param name="pais">Código do país (não usado no mock)</param>
        /// <returns>Lista de músicas do artista</returns>
        public List<Musica> BuscarMusicasArtista(string nomeArtista, int quantidade, string pais)
        {
            Console.WriteLine($"Buscando músicas de '{nomeArtista}'...");
            
            // Busca case-insensitive
            var artistaKey = bancoDeDados.Keys.FirstOrDefault(k => 
                k.Equals(nomeArtista, StringComparison.OrdinalIgnoreCase));

            if (artistaKey == null)
            {
                Console.WriteLine($"Artista '{nomeArtista}' não encontrado no mock.\n");
                return new List<Musica>();
            }

            var musicasDisponiveis = bancoDeDados[artistaKey];
            var musicasRetornadas = musicasDisponiveis.Take(quantidade).ToList();
            
            Console.WriteLine($"Encontradas {musicasRetornadas.Count} músicas.\n");
            return musicasRetornadas;
        }

        /// Inicializa o banco de dados mock com músicas de várias bandas.
        private Dictionary<string, List<Musica>> InicializarDados()
        {
            var dados = new Dictionary<string, List<Musica>>();

            // Red Hot Chili Peppers
            dados["Red Hot Chili Peppers"] = new List<Musica>
            {
                new Musica("Red Hot Chili Peppers", "Californication", 1999, "Californication", 
                    "https://open.spotify.com/track/48UPSzbZjgc449aqz8bxox", "https://i.scdn.co/image/californication"),
                new Musica("Red Hot Chili Peppers", "Under the Bridge", 1991, "Blood Sugar Sex Magik", 
                    "https://open.spotify.com/track/3d9DChrdc6BOeFsbrZ3Is0", "https://i.scdn.co/image/bloodsugar"),
                new Musica("Red Hot Chili Peppers", "Scar Tissue", 1999, "Californication", 
                    "https://open.spotify.com/track/1G391cbiT3v3Cywg8T7DM1", "https://i.scdn.co/image/californication"),
                new Musica("Red Hot Chili Peppers", "Otherside", 1999, "Californication", 
                    "https://open.spotify.com/track/64BbK9SAKQ0zuMzaności", "https://i.scdn.co/image/californication"),
                new Musica("Red Hot Chili Peppers", "Can't Stop", 2002, "By the Way", 
                    "https://open.spotify.com/track/3ZOEytgrvLwQaqXreDs2Jx", "https://i.scdn.co/image/bytheway"),
                new Musica("Red Hot Chili Peppers", "Dani California", 2006, "Stadium Arcadium", 
                    "https://open.spotify.com/track/3RiPr603aXAoi4GHyXx0uy", "https://i.scdn.co/image/stadium"),
                new Musica("Red Hot Chili Peppers", "Snow (Hey Oh)", 2006, "Stadium Arcadium", 
                    "https://open.spotify.com/track/2aibwv5hGXSgw7Yru8IYTO", "https://i.scdn.co/image/stadium"),
                new Musica("Red Hot Chili Peppers", "Give It Away", 1991, "Blood Sugar Sex Magik", 
                    "https://open.spotify.com/track/1AEKJx2f6vFmXUAGIFIuxF", "https://i.scdn.co/image/bloodsugar")
            };

            // The Offspring
            dados["The Offspring"] = new List<Musica>
            {
                new Musica("The Offspring", "Self Esteem", 1994, "Smash", 
                    "https://open.spotify.com/track/5LsvN8G9rZdQQ5pFFxPBAM", "https://i.scdn.co/image/smash"),
                new Musica("The Offspring", "Come Out and Play", 1994, "Smash", 
                    "https://open.spotify.com/track/0UImpRadZvB8K5DrZq40PZ", "https://i.scdn.co/image/smash"),
                new Musica("The Offspring", "The Kids Aren't Alright", 1998, "Americana", 
                    "https://open.spotify.com/track/3LYHOAgjYDa8SFjIyMoQKu", "https://i.scdn.co/image/americana"),
                new Musica("The Offspring", "Pretty Fly (For a White Guy)", 1998, "Americana", 
                    "https://open.spotify.com/track/0UImpRadZvB8K5DrZq40PZ", "https://i.scdn.co/image/americana"),
                new Musica("The Offspring", "You're Gonna Go Far, Kid", 2008, "Rise and Fall, Rage and Grace", 
                    "https://open.spotify.com/track/48y0OXmqWYBr5RJrpqmVlY", "https://i.scdn.co/image/riseandfall"),
                new Musica("The Offspring", "Gone Away", 1997, "Ixnay on the Hombre", 
                    "https://open.spotify.com/track/0cBXJS3x3zvWJMKKJhxPG1", "https://i.scdn.co/image/ixnay")
            };

            // Tame Impala
            dados["Tame Impala"] = new List<Musica>
            {
                new Musica("Tame Impala", "The Less I Know the Better", 2015, "Currents", 
                    "https://open.spotify.com/track/6K4t31amVTZDgR3sKmwUJJ", "https://i.scdn.co/image/currents"),
                new Musica("Tame Impala", "Let It Happen", 2015, "Currents", 
                    "https://open.spotify.com/track/2X485T9Z5Ly0xyaghN73ed", "https://i.scdn.co/image/currents"),
                new Musica("Tame Impala", "Feels Like We Only Go Backwards", 2012, "Lonerism", 
                    "https://open.spotify.com/track/4HbeGjbt75y26m7gHHrZzP", "https://i.scdn.co/image/lonerism"),
                new Musica("Tame Impala", "Borderline", 2019, "The Slow Rush", 
                    "https://open.spotify.com/track/5XVGErjSWoGcPCELJQ9wW9", "https://i.scdn.co/image/slowrush"),
                new Musica("Tame Impala", "Elephant", 2012, "Lonerism", 
                    "https://open.spotify.com/track/2dHHgzDwk4HSdV5W3fho0b", "https://i.scdn.co/image/lonerism"),
                new Musica("Tame Impala", "New Person, Same Old Mistakes", 2015, "Currents", 
                    "https://open.spotify.com/track/35MitmkrY7KBRsKpKOLyRJ", "https://i.scdn.co/image/currents")
            };

            // The Beatles
            dados["The Beatles"] = new List<Musica>
            {
                new Musica("The Beatles", "Hey Jude", 1968, "Hey Jude", 
                    "https://open.spotify.com/track/0aym2LBJBk9DAYuHHutrIl", "https://i.scdn.co/image/heyjude"),
                new Musica("The Beatles", "Let It Be", 1970, "Let It Be", 
                    "https://open.spotify.com/track/7iN1s7xHE4ifF5povM6A48", "https://i.scdn.co/image/letitbe"),
                new Musica("The Beatles", "Come Together", 1969, "Abbey Road", 
                    "https://open.spotify.com/track/2EqlS6tkEnglzr7tkKAAYD", "https://i.scdn.co/image/abbeyroad"),
                new Musica("The Beatles", "Here Comes the Sun", 1969, "Abbey Road", 
                    "https://open.spotify.com/track/6dGnYIeXmHdcikdzNNDMm2", "https://i.scdn.co/image/abbeyroad"),
                new Musica("The Beatles", "Yesterday", 1965, "Help!", 
                    "https://open.spotify.com/track/3BQHpFgAp4l80e1XslIjNI", "https://i.scdn.co/image/help"),
                new Musica("The Beatles", "A Day in the Life", 1967, "Sgt. Pepper's Lonely Hearts Club Band", 
                    "https://open.spotify.com/track/0hKRSZhUGEhKU6aNSPBACZ", "https://i.scdn.co/image/sgtpepper"),
                new Musica("The Beatles", "While My Guitar Gently Weeps", 1968, "The Beatles (White Album)", 
                    "https://open.spotify.com/track/3MdG2aX8jXwAtCIecukW4B", "https://i.scdn.co/image/whitealbum"),
                new Musica("The Beatles", "Something", 1969, "Abbey Road", 
                    "https://open.spotify.com/track/7lPN2DXiMsVn7XUKtOW1CS", "https://i.scdn.co/image/abbeyroad")
            };

            return dados;
        }
    }
}
