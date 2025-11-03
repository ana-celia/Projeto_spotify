using System;

namespace SpotifyListaEncadeada
{
    /// Implementação de uma lista duplamente encadeada para armazenar músicas.
    /// Suporta inserção por relevância (no final) ou ordem alfabética.
    public class MinhaListaDeMusicas
    {
        private No inicio;
        private No fim;
        private int count;

        public int Count => count;

        public MinhaListaDeMusicas()
        {
            inicio = null;
            fim = null;
            count = 0;
        }

        /// Insere uma música na lista de acordo com o tipo de ordenação especificado.
        /// <param name="musica">A música a ser inserida</param>
        /// <param name="tipoOrdem">RELEVANCIA (insere no final) ou NOME_MUSICA (ordem alfabética)</param>
        public void Inserir(Musica musica, string tipoOrdem)
        {
            if (tipoOrdem == "RELEVANCIA")
            {
                InserirNoFinal(musica);
            }
            else if (tipoOrdem == "NOME_MUSICA")
            {
                InserirOrdenado(musica);
            }
            else
            {
                Console.WriteLine($"\nERRO: Tipo de ordem '{tipoOrdem}' inválido. Use RELEVANCIA ou NOME_MUSICA.\n");
            }
        }

        /// Insere uma música no final da lista (usado para RELEVANCIA).
        private void InserirNoFinal(Musica musica)
        {
            No novoNo = new No(musica);

            // Caso 1: Lista vazia
            if (inicio == null)
            {
                inicio = novoNo;
                fim = novoNo;
            }
            // Caso 2: Lista tem elementos
            else
            {
                fim.Proximo = novoNo;
                novoNo.Anterior = fim;
                fim = novoNo;
            }

            count++;
        }

        /// Insere uma música mantendo a lista ordenada alfabeticamente pelo nome da música.
        private void InserirOrdenado(Musica musica)
        {
            No novoNo = new No(musica);

            // Caso 1: Lista vazia
            if (inicio == null)
            {
                inicio = novoNo;
                fim = novoNo;
                count++;
                return;
            }

            // Caso 2: Inserir no início (novo nome vem antes do primeiro)
            if (string.Compare(musica.NomeMusica, inicio.Musica.NomeMusica, StringComparison.OrdinalIgnoreCase) < 0)
            {
                novoNo.Proximo = inicio;
                inicio.Anterior = novoNo;
                inicio = novoNo;
                count++;
                return;
            }

            // Caso 3: Inserir no meio ou no final
            No noAtual = inicio;
            while (noAtual != null)
            {
                // Se o novo nome vem antes do atual, inserir antes dele
                if (string.Compare(musica.NomeMusica, noAtual.Musica.NomeMusica, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    novoNo.Anterior = noAtual.Anterior;
                    novoNo.Proximo = noAtual;
                    noAtual.Anterior.Proximo = novoNo;
                    noAtual.Anterior = novoNo;
                    count++;
                    return;
                }

                // Se chegou no último nó e ainda não inseriu, inserir no final
                if (noAtual.Proximo == null)
                {
                    noAtual.Proximo = novoNo;
                    novoNo.Anterior = noAtual;
                    fim = novoNo;
                    count++;
                    return;
                }

                noAtual = noAtual.Proximo;
            }
        }

        /// Busca uma música pelo nome exato (case-insensitive) e exibe seus detalhes.
        /// <param name="nomeMusica">Nome da música a ser buscada</param>
        public void Buscar(string nomeMusica)
        {
            if (inicio == null)
            {
                Console.WriteLine("\nAVISO: A lista está vazia.\n");
                return;
            }

            No noAtual = inicio;
            while (noAtual != null)
            {
                // Comparação case-insensitive
                if (string.Equals(noAtual.Musica.NomeMusica, nomeMusica, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n=== MÚSICA ENCONTRADA ===");
                    ExibirDetalhesMusica(noAtual.Musica);
                    return;
                }
                noAtual = noAtual.Proximo;
            }

            // Se chegou aqui, não encontrou
            Console.WriteLine($"\nMúsica '{nomeMusica}' não encontrada.\n");
        }
        /// Lista todas as músicas armazenadas na lista, na ordem em que estão.
        public void ListarTodos()
        {
            if (inicio == null)
            {
                Console.WriteLine("\nAVISO: A lista está vazia. Nenhuma música para exibir.\n");
                return;
            }

            Console.WriteLine($"\n=== LISTAGEM DE MÚSICAS ({count} no total) ===\n");

            No noAtual = inicio;
            int contador = 1;

            while (noAtual != null)
            {
                Console.WriteLine($"{contador}. {noAtual.Musica.NomeMusica}");
                Console.WriteLine($"   Artista........: {noAtual.Musica.NomeArtista}");
                Console.WriteLine($"   Álbum..........: {noAtual.Musica.NomeAlbum}");
                Console.WriteLine($"   Ano............: {noAtual.Musica.Ano}");
                Console.WriteLine($"   Link da Música.: {noAtual.Musica.UrlMusica}");
                Console.WriteLine($"   Link da Capa...: {noAtual.Musica.UrlCapa}");
                Console.WriteLine();

                contador++;
                noAtual = noAtual.Proximo;
            }
        }

        /// Método auxiliar para exibir detalhes de uma música específica.
        private void ExibirDetalhesMusica(Musica musica)
        {
            Console.WriteLine($"Música.........: {musica.NomeMusica}");
            Console.WriteLine($"Artista........: {musica.NomeArtista}");
            Console.WriteLine($"Álbum..........: {musica.NomeAlbum}");
            Console.WriteLine($"Ano............: {musica.Ano}");
            Console.WriteLine($"Link da Música.: {musica.UrlMusica}");
            Console.WriteLine($"Link da Capa...: {musica.UrlCapa}");
            Console.WriteLine();
        }
    }
}