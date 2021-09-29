using RestPokemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPokemon.PokemonData
{
    public interface IPokemonData
    {
        List<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon AddPokemon(Pokemon pokemon);
        void DeletePokemon(Pokemon pokemon);
        Pokemon EditPokemon(Pokemon pokemon);
    }
}
