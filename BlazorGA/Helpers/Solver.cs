using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorGA.Helpers
{
    public class Solver
    {
        private string palavra;
        private int geracoes;
        private int populacao;
        private string selecao;
        private float crossOverChance;
        private float mutacaoChance;
        public Solver(string palavra, int geracoes, int populacao, string selecao, float crossOverChance, float mutacaoChance)
        {
            this.palavra = palavra;
            this.geracoes = geracoes;
            this.populacao = populacao;
            this.selecao = selecao;
            this.crossOverChance = crossOverChance;
            this.mutacaoChance = mutacaoChance;
        }

        public async Task<GeneticAlgorithm> getResultado()
        {
            var fitness = new PalavraFitness(palavra);
            var chromosome = new PalavraCromossomo(palavra.Length, palavra);
            var crossover = new UniformCrossover();
            var mutation = new Mutacao();

            SelectionBase selection;
            switch (selecao)
            {
                case "Torneio":
                    selection = new TournamentSelection();
                    break;
                case "Roleta":
                    selection = new RouletteWheelSelection();
                    break;
                case "Elite":
                    selection = new EliteSelection();
                    break;
                default:
                    selection = new RouletteWheelSelection();
                    break;
            }

            var population = new Population(populacao, populacao, chromosome);
            GeneticAlgorithm ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);

            ga.MutationProbability = mutacaoChance;
            ga.CrossoverProbability = crossOverChance;

            ga.Start();
            for (int i = 0; i < geracoes; i++)
            {
                if (ga.BestChromosome.Fitness == palavra.Length)
                {
                    break;
                }

                await Task.Delay(1);
                ga.Termination = new GenerationNumberTermination(i + 1);
                ga.Resume();
            }
            return ga;
        }
    }
}
