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

        private Recorder recorder = new Recorder();

        [Test]
        public void Upsert_command_adds_new_key_and_value()
        {
            var command = new Upsert("key", 2);

            command.ActOn(recorder);

            Assert.That(recorder.KeyCount, Is.EqualTo(1));
            Assert.That(recorder.Get("key"), Is.EqualTo(2));

        }
    }
}
