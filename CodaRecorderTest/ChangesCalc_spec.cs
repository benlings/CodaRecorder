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
    }
}
