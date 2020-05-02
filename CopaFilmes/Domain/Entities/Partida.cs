namespace CopaFilmes.Domain.Entities
{
    public static class Partida
    {
        /// <summary>
        /// Método que realiza uma disputa entre dois Filmes.
        /// </summary>
        /// <param name="competidorX">Competidor.</param>
        /// <param name="competidorY">Competidor.</param>
        /// <returns>Retorna o objeto <see cref="Filme"/> vencedor.</returns>
        public static Filme Disputar(Filme competidorX, Filme competidorY)
        {
            if (competidorX.Nota > competidorY.Nota)
            {
                return competidorX;
            }
            else if (competidorX.Nota < competidorY.Nota)
            {
                return competidorY;
            }
            else
            {
                return Desempate(competidorX, competidorY);
            }
        }

        /// <summary>
        /// Método que realiza um desempate entre dois competidores.
        /// </summary>
        /// <param name="competidorX">Competidor.</param>
        /// <param name="competidorY">Competidor.</param>
        /// <returns>Retorna o <see cref="Filme"/> vencedor.</returns>
        private static Filme Desempate(Filme competidorX, Filme competidorY)
        {
            const int POSICAO_VENCEDOR = 1;

            int desempate = string.Compare(competidorX.Titulo, competidorY.Titulo, true);

            return desempate == POSICAO_VENCEDOR ? competidorX : competidorY;
        }
    }
}
