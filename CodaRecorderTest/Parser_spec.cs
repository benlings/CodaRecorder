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

        
        [TestCase("clear")]
        public void parser_creates_delete_from_valid_drop_message_string(String message)
        {
            var command = parser.Parse(message);

            Assert.That(command, Is.InstanceOf<Clear>());
        }
        [TestCase("value key space 2", "Incorrectly formatted value string")]
        [TestCase("value key nonint", "Non-integer value")]
        [TestCase("value key", "Incorrectly formatted value string")]
        [TestCase("drop", "Incorrectly formatted drop string")]
        [TestCase("drop key 2", "Incorrectly formatted drop string")]
        [TestCase("not_value key nonint", "Unknown command")]
        [TestCase("", "Unknown command")]
        public void parser_returns_invalid_command_for_non_valid_message_string(String message, String errorMessage)
        {
            var command = parser.Parse(message);

            Assert.That(command, Is.InstanceOf<Invalid>());
            var invalidCommand = (Invalid)command;
            Assert.That(invalidCommand.Message, Is.EqualTo(errorMessage));
        
        }

        [TestCase("drop key", "key")]
        [TestCase("drop other_key", "other_key")]
        public void parser_creates_delete_from_valid_drop_message_string(String message, String key)
        {
            var command = parser.Parse(message);

            Assert.That(command, Is.InstanceOf<Delete>());
            Assert.That(command.Key, Is.EqualTo(key));
        }


    }
}
