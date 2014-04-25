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

            Assert.That(testRecorder.KeyCount, Is.EqualTo(0));
        }

        [Test]
        public void insert_new_key_increments_key_count()
        {
            Recorder testRecorder = new Recorder();
            testRecorder.Upsert("testKey", 1);

            Assert.That(testRecorder.KeyCount, Is.EqualTo(1));
        }

        [TestCase("testKey1", 1)]
        [TestCase("testKey2", 2)]
        public void requesting_inserted_key_gives_associated_value(string key, int value)
        {
            Recorder testRecorder = new Recorder();
            testRecorder.Upsert(key, value);

            Assert.That(testRecorder.Get(key), Is.EqualTo(value));
        }

        
    }
}
