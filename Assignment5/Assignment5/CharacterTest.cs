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
            var character = new Character("Hero", RaceCategory.Human, 100);

            character.TakeDamage(30);

            ClassicAssert.AreEqual(70, character.Health);
        }

        [Test]
        public void TakeDamage_SetsIsAliveToFalse_WhenHealthIsZeroOrBelow()
        {
            var character = new Character("Hero", RaceCategory.Human, 100);

            character.TakeDamage(100);

            ClassicAssert.IsFalse(character.IsAlive);
            ClassicAssert.AreEqual(0, character.Health);
        }

        [Test]
        public void RestoreHealth_RestoresHealthCorrectly()
        {
            var character = new Character("Hero", RaceCategory.Human, 100);
            character.TakeDamage(50);

            character.RestoreHealth(30);

            ClassicAssert.AreEqual(80, character.Health);
        }

        [Test]
        public void RestoreHealth_SetsIsAliveToTrue_WhenHealthAboveZero()
        {
            var character = new Character("Hero", RaceCategory.Human, 100);
            character.TakeDamage(100);

            character.RestoreHealth(10);

            ClassicAssert.IsTrue(character.IsAlive);
            ClassicAssert.AreEqual(10, character.Health);
        }
    }
}
