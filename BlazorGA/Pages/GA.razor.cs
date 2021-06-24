using BlazorGA.Helpers;
using GeneticSharp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorGA.Pages
{
    public partial class GA
    {
        public string Palavra { get; set; } = "Olá Mundo";
        public string PalavraEmbaralhada { get; set; }
        public int Geracoes { get; set; } = 200;
        public int Populacao { get; set; } = 100;
        public string Selecao { get; set; } = "Roleta";
        public float CrossOverChance { get; set; } = 0.80f;
        public float MutacaoChance { get; set; } = 0.80f;

        public int geracaoResultado { get; set; }
        public float melhorFitness { get; set; } = 1;

        async Task SolverGA()
        {
            melhorFitness = 0;

            Solver resultado = new Solver(Palavra, Geracoes, Populacao, Selecao, CrossOverChance, MutacaoChance);
            GeneticAlgorithm ga = await resultado.getResultado();
            Palavra = getPalavra(ga);
            geracaoResultado = ga.GenerationsNumber;
            melhorFitness = ((float)ga.BestChromosome.Fitness / (float)Palavra.Length) * 100;
        }

        private void EmbaralharPalavra()
        {
            string[] palavras = new string[] { "Ola mundo!", "Cshap > Java", "Senha123", "Windows", "Linux", "Uma frase qualquer bem grande" };
            Random r = new Random();
            int rInt = r.Next(0, palavras.Length);
            Palavra = palavras[rInt];

            char[] array = Palavra.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }

            melhorFitness = 1;
            geracaoResultado = 0;
            PalavraEmbaralhada = new string(array);
        }

        private string getPalavra(GeneticAlgorithm ga)
        {
            string palavra = "";
            foreach (var p in ga.BestChromosome.GetGenes())
            {
                palavra += p;
            }

            return palavra;
        }
    }
}
