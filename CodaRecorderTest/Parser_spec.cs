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

        [TestCase("value key 2", "key", 2)]
        [TestCase("value key2 1", "key2", 1)]
        public void parser_creates_upsert_from_valid_value_string(String message, String key, int value)
        {
            var command = parser.Parse(message);

            Assert.That(command, Is.InstanceOf<Upsert>());
            Assert.That(command.Key, Is.EqualTo(key));
            Assert.That(command.Value, Is.EqualTo(value));
        }

    }
}
