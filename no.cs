namespace SpotifyListaEncadeada
{
    /// Representa um nó da lista duplamente encadeada.
    /// Cada nó armazena uma música e referências para o nó anterior e próximo.
    public class No
    {
        public Musica Musica { get; set; }
        public No Anterior { get; set; }
        public No Proximo { get; set; }

        /// Construtor que cria um novo nó com uma música.
        /// Inicialmente, o nó não está conectado a nenhum outro (Anterior e Proximo = null)
        public No(Musica musica)
        {
            Musica = musica;
            Anterior = null;
            Proximo = null;
        }
    }
}