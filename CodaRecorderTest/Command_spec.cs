using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodaRecorder;
using NUnit.Framework;

namespace CodaRecorder
{
    [TestFixture]
    class Command_spec
    {

        private Recorder recorder;

        [SetUp]
        public void SetUpTestRecorder()
        {
            recorder = new Recorder();
        }

        [Test]
        public void Upsert_command_adds_new_key_and_value()
        {
            var command = new Upsert("key", 2);

            command.ActOn(recorder);

            Assert.That(recorder.KeyCount, Is.EqualTo(1));
            Assert.That(recorder.Get("key"), Is.EqualTo(2));

        }

        [Test]
        public void Delete_command_removes_existing_key_and_value()
        {
            this.recorder.Upsert("key", 2);

            var command = new Delete("key");
            command.ActOn(recorder);

            Assert.That(recorder.KeyCount, Is.EqualTo(0));
        }

        [Test]
        public void Clear_command_removes_all_existing_keys_and_values()
        {
            this.recorder.Upsert("key1", 2);
            this.recorder.Upsert("key2", 3);

            var command = new Clear();
            command.ActOn(recorder);

            Assert.That(recorder.KeyCount, Is.EqualTo(0));
        }
    }
}
