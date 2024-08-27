using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Assignment5
{
    [TestFixture]
    public class CharacterTest
    {
        [Test]
        public void TakeDamage_ReducesHealthCorrectly()
        {
            // Arrange
            var character = new Character("Hero", RaceCategory.Human, 100);

            // Act
            character.TakeDamage(30);

            // ClassicAssert
            ClassicAssert.AreEqual(70, character.Health);
        }

        [Test]
        public void TakeDamage_SetsIsAliveToFalse_WhenHealthIsZeroOrBelow()
        {
            // Arrange
            var character = new Character("Hero", RaceCategory.Human, 100);

            // Act
            character.TakeDamage(100);

            // ClassicAssert
            ClassicAssert.IsFalse(character.IsAlive);
            ClassicAssert.AreEqual(0, character.Health);
        }

        [Test]
        public void RestoreHealth_RestoresHealthCorrectly()
        {
            // Arrange
            var character = new Character("Hero", RaceCategory.Human, 100);
            character.TakeDamage(50);

            // Act
            character.RestoreHealth(30);

            // ClassicAssert
            ClassicAssert.AreEqual(80, character.Health);
        }

        [Test]
        public void RestoreHealth_SetsIsAliveToTrue_WhenHealthAboveZero()
        {
            // Arrange
            var character = new Character("Hero", RaceCategory.Human, 100);
            character.TakeDamage(100);

            // Act
            character.RestoreHealth(10);

            // ClassicAssert
            ClassicAssert.IsTrue(character.IsAlive);
            ClassicAssert.AreEqual(10, character.Health);
        }
    }
}
