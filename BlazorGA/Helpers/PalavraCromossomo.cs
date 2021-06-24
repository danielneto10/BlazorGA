using GeneticSharp.Domain.Chromosomes;
using System;
using System.Linq;

namespace BlazorGA.Helpers
{
    internal class PalavraCromossomo : ChromosomeBase
    {
        public int PalavraTamanho { get; set; }
        public string Palavra { get; set; }

        public PalavraCromossomo(int palavraTamanho, string palavra) : base(palavraTamanho)
        {
            this.PalavraTamanho = palavraTamanho;
            this.Palavra = palavra;
            CreateGenes();
        }
        public override IChromosome CreateNew()
        {
            return new PalavraCromossomo(PalavraTamanho, Palavra);
        }

        public override Gene GenerateGene(int geneIndex)
        {
            Random r = new Random();
            //char[] genesPossiveis = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890, .-;:_!#%&/()=?@${[]}><".ToArray();
            char[] genesPossiveis = Palavra.ToArray();
            int rand = r.Next(0, genesPossiveis.Length);
            return new Gene(genesPossiveis[rand]);
        }
    }
}