using System;
using System.Collections.Generic;

namespace SpotifyListaEncadeada
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  SISTEMA DE BUSCA DE MÚSICAS - SPOTIFY");
            Console.WriteLine("========================================\n");

            try
            {
                // 1. Ler parâmetros do arquivo busca.txt
                Console.WriteLine(">>> Lendo arquivo de parâmetros...");
                ParametrosBusca parametros = ParametrosBusca.LerArquivo("busca_txt.txt");
                
                Console.WriteLine($"Artista............: {parametros.NomeArtista}");
                Console.WriteLine($"Quantidade.........: {parametros.QuantidadeMusicas}");
                Console.WriteLine($"País...............: {parametros.PaisBusca}");
                Console.WriteLine($"Tipo de Ordenação..: {parametros.TipoOrdem}\n");

                // 2. Inicializar cliente Spotify (Mock)
                SpotifyClientMock spotifyClient = new SpotifyClientMock();

                // 3. Buscar músicas na API (Mock)
                List<Musica> musicasEncontradas = spotifyClient.BuscarMusicasArtista(
                    parametros.NomeArtista, 
                    parametros.QuantidadeMusicas, 
                    parametros.PaisBusca);

                if (musicasEncontradas.Count == 0)
                {
                    Console.WriteLine($"Nenhuma música encontrada para '{parametros.NomeArtista}'.\n");
                    return;
                }

                // 4. Criar a estrutura de dados (lista duplamente encadeada)
                MinhaListaDeMusicas lista = new MinhaListaDeMusicas();

                // 5. Inserir músicas na lista de acordo com o tipo de ordenação
                Console.WriteLine($">>> Inserindo {musicasEncontradas.Count} músicas na lista (Tipo: {parametros.TipoOrdem})...\n");
                
                foreach (Musica musica in musicasEncontradas)
                {
                    lista.Inserir(musica, parametros.TipoOrdem);
                }

                Console.WriteLine($"Inserção concluída! Total de músicas: {lista.Count}\n");

                // 6. Listar todas as músicas
                lista.ListarTodos();

                // 7. Demonstrar busca (opcional)
                Console.WriteLine("\n========================================");
                Console.WriteLine("  DEMONSTRAÇÃO DE BUSCA");
                Console.WriteLine("========================================\n");

                // Buscar uma música que existe
                Console.WriteLine("Buscando música existente:");
                if (musicasEncontradas.Count > 0)
                {
                    string nomePrimeira = musicasEncontradas[0].NomeMusica;
                    lista.Buscar(nomePrimeira);
                }

                // Buscar uma música que não existe
                Console.WriteLine("\nBuscando música inexistente:");
                lista.Buscar("Música Que Não Existe");

                Console.WriteLine("\n========================================");
                Console.WriteLine("  PROGRAMA FINALIZADO COM SUCESSO");
                Console.WriteLine("========================================\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO] {ex.Message}\n");
                Console.WriteLine("Detalhes do erro:");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
