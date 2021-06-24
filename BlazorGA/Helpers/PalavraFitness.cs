using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;

namespace BlazorGA.Helpers
{
    internal class PalavraFitness : IFitness
    {
        string palavraFinal;

        public PalavraFitness(string palavraFinal)
        {
            this.palavraFinal = palavraFinal;
        }

        public double Evaluate(IChromosome chromosome)
        {
            int fitness = palavraFinal.Length;

            for (int i = 0; i < palavraFinal.Length; i++)
            {
                if ((char)chromosome.GetGene(i).Value != palavraFinal[i])
                {
                    fitness--;
                }
            }

            return fitness;
        }
    }
}