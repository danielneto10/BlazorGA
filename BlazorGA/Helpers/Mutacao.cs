using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGA.Helpers
{
    class Mutacao : MutationBase
    {
        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            Random r = new Random();
            double randDouble = r.NextDouble();


            if (randDouble <= probability)
            {
                char[] genesPossiveis = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890, .-;:_!#%&/()=?@${[]}><".ToArray();
                int rand = r.Next(0, genesPossiveis.Length);
                int randIndex = r.Next(0, chromosome.Length);

                chromosome.ReplaceGene(randIndex, new Gene(genesPossiveis[rand]));
            }
        }
    }
}
