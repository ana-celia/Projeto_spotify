using System;
using System.Collections.Generic;
using System.IO;

namespace SpotifyListaEncadeada
{
    /// Record que armazena os parâmetros de busca lidos do arquivo busca.txt.
    /// Imutável - os valores não podem ser alterados após a criação.
    public record ParametrosBusca(
        string NomeArtista, 
        int QuantidadeMusicas, 
        string PaisBusca, 
        string TipoOrdem)
    {
        /// Lê o arquivo busca.txt e retorna um objeto ParametrosBusca com os valores parseados.
        /// Formato esperado do arquivo:
        /// NOME_ARTISTA = Iron Maiden
        /// QUANTIDADE_MUSICAS = 50
        /// PAIS_BUSCA = BR
        /// TIPO_ORDEM = NOME_MUSICA
        /// <param name="caminhoArquivo">Caminho para o arquivo de parâmetros</param>
        /// <returns>Objeto ParametrosBusca preenchido</returns>
        public static ParametrosBusca LerArquivo(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException($"Arquivo '{caminhoArquivo}' não encontrado.");
            }

            // Dicionário para armazenar chave-valor do arquivo
            Dictionary<string, string> parametros = new Dictionary<string, string>();

            // Lê todas as linhas do arquivo
            string[] linhas = File.ReadAllLines(caminhoArquivo);

            // Processa cada linha
            foreach (string linha in linhas)
            {
                // Ignora linhas vazias ou comentários
                if (string.IsNullOrWhiteSpace(linha) || linha.TrimStart().StartsWith("#"))
                    continue;

                // Divide a linha pelo '='
                string[] partes = linha.Split('=');
                
                if (partes.Length == 2)
                {
                    string chave = partes[0].Trim().ToUpper();
                    string valor = partes[1].Trim();
                    parametros[chave] = valor;
                }
            }

            // Valida se todas as chaves necessárias existem
            ValidarParametros(parametros);

            // Extrai e converte os valores
            string nomeArtista = parametros["NOME_ARTISTA"];
            
            if (!int.TryParse(parametros["QUANTIDADE_MUSICAS"], out int quantidadeMusicas))
            {
                throw new FormatException("QUANTIDADE_MUSICAS deve ser um número inteiro válido.");
            }

            string paisBusca = parametros.ContainsKey("PAIS_BUSCA") && !string.IsNullOrEmpty(parametros["PAIS_BUSCA"]) 
                ? parametros["PAIS_BUSCA"] 
                : "BR";

            string tipoOrdem = parametros["TIPO_ORDEM"].ToUpper();

            // Valida o tipo de ordem
            if (tipoOrdem != "RELEVANCIA" && tipoOrdem != "NOME_MUSICA")
            {
                throw new ArgumentException($"TIPO_ORDEM inválido: '{tipoOrdem}'. Use RELEVANCIA ou NOME_MUSICA.");
            }

            return new ParametrosBusca(nomeArtista, quantidadeMusicas, paisBusca, tipoOrdem);
        }

        /// Valida se todos os parâmetros obrigatórios existem no dicionário.
        private static void ValidarParametros(Dictionary<string, string> parametros)
        {
            string[] chavesObrigatorias = { "NOME_ARTISTA", "QUANTIDADE_MUSICAS", "TIPO_ORDEM" };

            foreach (string chave in chavesObrigatorias)
            {
                if (!parametros.ContainsKey(chave) || string.IsNullOrWhiteSpace(parametros[chave]))
                {
                    throw new ArgumentException($"Parâmetro obrigatório '{chave}' não encontrado ou vazio no arquivo.");
                }
            }
        }
    }
}