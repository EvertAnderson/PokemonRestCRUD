using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestPokemon.DatabaseCSV;
using RestPokemon.Models;
using RestPokemon.PokemonData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Test_RestPokemon
{
    [TestClass]
    public class PokemonControllerTests
    {
        [TestMethod]
        public void TestGetPokemons()
        {
            //Arrange
            List<Pokemon> lPokemon = new CSVReadWrite().GetPokemonList();
            var controller = new MockPokemonData();

            //Act
            var actionResult = controller.GetPokemons();

            //Assert
            Assert.AreEqual(lPokemon.Count, actionResult.Count);
        }

        [TestMethod]
        public void TestNotFoundPokemon()
        {
            //Arrange
            var controller = new MockPokemonData();

            //Act
            var actionResult = controller.GetPokemon(-1);

            //Assert
            Assert.AreEqual(null, actionResult);
        }

        [TestMethod]
        public void TestGetPokemon()
        {
            //Arrange
            var controller = new MockPokemonData();
            var pokemon = new Pokemon() { Id = int.MaxValue, Name = "Test Pokemon", Attack = 100 };

            //Act
            var actionResult = controller.AddPokemon(pokemon);

            //Assert
            Assert.AreEqual(pokemon, actionResult);
        }

        [TestMethod]
        public void TestDeletePokemon()
        {
            //Arrange
            var controller = new MockPokemonData();
            var pokemon = new Pokemon() { Id = int.MaxValue, Name = "Test Pokemon", Attack = 100 };

            //Act
            var addResult = controller.AddPokemon(pokemon);
            controller.DeletePokemon(pokemon);
            var actionResult = controller.GetPokemon(int.MaxValue);

            //Assert
            Assert.AreEqual(null, actionResult);
        }

        [TestMethod]
        public void TestEditPokemon()
        {
            //Arrange
            var controller = new MockPokemonData();
            var pokemon = new Pokemon() { Id = int.MaxValue, Name = "Test Pokemon", Attack = 100 };

            //Act
            controller.AddPokemon(pokemon);
            pokemon.Name = "New Pokemon";
            var actionResult = controller.EditPokemon(pokemon);

            //Assert
            Assert.AreEqual("New Pokemon", actionResult.Name);
        }
    }
    
}
