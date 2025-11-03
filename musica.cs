namespace SpotifyListaEncadeada
{
    /// Representa uma música com suas informações básicas.
    /// Propriedades imutáveis (init) para garantir consistência dos dados.
    public class Musica
    {
        public string NomeArtista { get; init; }
        public string NomeMusica { get; init; }
        public int Ano { get; init; }
        public string NomeAlbum { get; init; }
        public string UrlMusica { get; init; }
        public string UrlCapa { get; init; }

        /// Construtor que inicializa todos os campos obrigatórios
        public Musica(string nomeArtista, string nomeMusica, int ano, 
                      string nomeAlbum, string urlMusica, string urlCapa)
        {
            NomeArtista = nomeArtista;
            NomeMusica = nomeMusica;
            Ano = ano;
            NomeAlbum = nomeAlbum;
            UrlMusica = urlMusica;
            UrlCapa = urlCapa;
        }
        /// Retorna uma representação textual formatada da música
        public override string ToString()
        {
            return $"{NomeMusica} - {NomeArtista} ({Ano})";
        }
    }
}