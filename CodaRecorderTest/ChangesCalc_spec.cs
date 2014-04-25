using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodaRecorder
{
    [TestFixture]
    class ChangesCalc_spec
    {

        [Test]
        public void provides_has_empty_sets_for_empty_input_dictionaries()
        {
            var calc = new ChangesCalc(new Dictionary<string, int>(), new Dictionary<string, int>());
            calc.CalculateChanges();
            Assert.That(calc.InsertedKeys, Is.Empty);
            Assert.That(calc.DeletedKeys, Is.Empty);
        }

        [Test]
        public void new_keys_returned_in_inserted_keys()
        {
            var newValues = new Dictionary<string, int>();
            newValues.Add("key1", 1);
            newValues.Add("key2", 2);

            var calc = new ChangesCalc(new Dictionary<string, int>(), newValues);
            calc.CalculateChanges();

            Assert.That(calc.InsertedKeys, Is.EqualTo(newValues.Keys));
            Assert.That(calc.DeletedKeys, Is.Empty);
        }

        [Test]
        public void removed_keys_returned_in_deleted_keys()
        {
            var oldValues = new Dictionary<string, int>();
            oldValues.Add("key1", 1);
            oldValues.Add("key2", 2);

            var newValues = new Dictionary<string, int>();

            var calc = new ChangesCalc(oldValues, newValues);
            calc.CalculateChanges();

            Assert.That(calc.InsertedKeys, Is.Empty);
            Assert.That(calc.DeletedKeys, Is.EqualTo(oldValues.Keys));
        }
    }
}
