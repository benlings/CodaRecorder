using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodaRecorder
{
    [TestFixture]
    public class RecorderTest
    {
        [Test]
        public void new_recorder_key_count_is_zero()
        {
            Recorder testRecorder = new Recorder();

            Assert.That(testRecorder.KeyCount(), Is.EqualTo(0));
        }

        [Test]
        public void insert_new_key_increments_key_count()
        {
            Recorder testRecorder = new Recorder();
            testRecorder.Upsert("testKey", 1);

            Assert.That(testRecorder.KeyCount(), Is.EqualTo(1));
        }

        [Test]
        public void requesting_inserted_key_gives_associated_value()
        {
            Recorder testRecorder = new Recorder();
            testRecorder.Upsert("testKey", 1);

            Assert.That(testRecorder.Get("testKey"), Is.EqualTo(1));

        }
    }
}
