using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodaRecorder
{
    [TestFixture]
    class Parser_spec
    {
        private Parser parser = new Parser();

        [Test]
        public void parser_creates_upsert_from_valid_value_string()
        {
            var command = parser.Parse("value key 2");

            Assert.That(command, Is.InstanceOf<Upsert>());
            Assert.That(command.Key, Is.EqualTo("key"));
            Assert.That(command.Value, Is.EqualTo(2));
        }
    }
}
