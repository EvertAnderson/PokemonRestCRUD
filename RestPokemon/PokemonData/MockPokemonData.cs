using RestPokemon.DatabaseCSV;
using RestPokemon.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestPokemon.PokemonData
{
    public class MockPokemonData : IPokemonData
    {
        private List<Pokemon> lPokemon = new CSVReadWrite().GetPokemonList();

        public Pokemon AddPokemon(Pokemon pokemon)
        {
            //GetLastId from csv
            int lastId = lPokemon.Max(x => x.Id) + 1;
            pokemon.Id = lastId;
            lPokemon.Add(pokemon);

            return pokemon;
        }

        public void DeletePokemon(Pokemon pokemon)
        {
            lPokemon.Remove(pokemon);
        }

        public Pokemon EditPokemon(Pokemon pokemon)
        {
            var existPokemon = GetPokemon(pokemon.Id);
            existPokemon.Id = pokemon.Id;
            existPokemon.Name = pokemon.Name;
            existPokemon.Type1 = pokemon.Type1;
            existPokemon.Type2 = pokemon.Type2;
            existPokemon.Total = pokemon.Total;
            existPokemon.HP = pokemon.HP;
            existPokemon.Attack = pokemon.Attack;
            existPokemon.Defense = pokemon.Defense;
            existPokemon.Sp_Atk = pokemon.Sp_Atk;
            existPokemon.Sp_Def = pokemon.Sp_Def;
            existPokemon.Speed = pokemon.Speed;
            existPokemon.Generation = pokemon.Generation;
            existPokemon.Legendary = pokemon.Legendary;
            return existPokemon;
        }

        public Pokemon GetPokemon(int id)
        {
            return lPokemon.FirstOrDefault(x => x.Id == id);
        }

        public List<Pokemon> GetPokemons()
        {
            return lPokemon;
        }
    }
}
