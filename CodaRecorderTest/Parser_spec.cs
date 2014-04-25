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
            var upsertCommand = (Upsert)command;
            Assert.That(upsertCommand.Key, Is.EqualTo(key));
            Assert.That(upsertCommand.Value, Is.EqualTo(value));
        }


        [TestCase("drop key", "key")]
        [TestCase("drop other_key", "other_key")]
        public void parser_creates_delete_from_valid_drop_message_string(String message, String key)
        {
            var command = parser.Parse(message);

            Assert.That(command, Is.InstanceOf<Delete>());
            var deleteCommand = (Delete)command;
            Assert.That(deleteCommand.Key, Is.EqualTo(key));
        }
        
        [TestCase("clear")]
        public void parser_creates_delete_from_valid_drop_message_string(String message)
        {
            var command = parser.Parse(message);

            Assert.That(command, Is.InstanceOf<Clear>());
        }

    }

    [TestFixture]
    class InvalidParse_spec
    {
        private Parser parser = new Parser();
        
        [TestCase("", "Unknown command")]
        public void empty_message_returns_invalid_command(String message, String errorMessage)
        {
            AssertThatInvalidMessageReturnsInvalidCommand(message, errorMessage);
        }


        [TestCase("value key space 2", "Incorrectly formatted value string")]
        [TestCase("value key nonint", "Non-integer value")]
        [TestCase("value key", "Incorrectly formatted value string")]
        public void non_valid_value_string_returns_invalid_command(String message, String errorMessage)
        {
            AssertThatInvalidMessageReturnsInvalidCommand(message, errorMessage);
        }


        [TestCase("drop", "Incorrectly formatted drop string")]
        [TestCase("drop key 2", "Incorrectly formatted drop string")]
        public void non_valid_drop_string_returns_invalid_command(String message, String errorMessage)
        {
            AssertThatInvalidMessageReturnsInvalidCommand(message, errorMessage);
        }

        [TestCase("not_value key nonint", "Unknown command")]
        public void unknown_comand_return_invalid_command(String message, String errorMessage)
        {
            AssertThatInvalidMessageReturnsInvalidCommand(message, errorMessage);
        }

        private void AssertThatInvalidMessageReturnsInvalidCommand(String message, String errorMessage)
        {

            var command = parser.Parse(message);

            Assert.That(command, Is.InstanceOf<Invalid>());
            var invalidCommand = (Invalid)command;
            Assert.That(invalidCommand.Message, Is.EqualTo(errorMessage));
        }

    }
}
