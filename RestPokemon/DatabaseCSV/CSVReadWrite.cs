using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using RestPokemon.Models;
using System.Collections.Generic;

namespace RestPokemon.DatabaseCSV
{
    public class CSVReadWrite
    {
        private List<Pokemon> PokemonList;

        public CSVReadWrite()
        {
            using (var streamReader = new StreamReader(@".\DatabaseCSV\pokemon.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<PokemonClassMap>();
                    PokemonList = csvReader.GetRecords<Pokemon>().ToList();
                }
            }
        }

        public List<Pokemon> GetPokemonList()
        {
            return PokemonList;
        }
    }

    public class PokemonClassMap : ClassMap<Pokemon>
    {
        public PokemonClassMap()
        {
            Map(m => m.Id).Name("#");
            Map(m => m.Name).Name("Name");
            Map(m => m.Type1).Name("Type 1");
            Map(m => m.Type2).Name("Type 2");
            Map(m => m.Total).Name("Total");
            Map(m => m.HP).Name("HP");
            Map(m => m.Attack).Name("Attack");
            Map(m => m.Defense).Name("Defense");
            Map(m => m.Sp_Atk).Name("Sp. Atk");
            Map(m => m.Sp_Def).Name("Sp. Def");
            Map(m => m.Speed).Name("Speed");
            Map(m => m.Generation).Name("Generation");
            Map(m => m.Legendary).Name("Legendary");
        }
    }
}
