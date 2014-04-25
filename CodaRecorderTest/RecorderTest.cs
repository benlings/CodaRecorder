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
        private Recorder testRecorder;

        [SetUp]
        public void SetUpTestRecorder()
        {
            testRecorder = new Recorder();
        }

        [Test]
        public void new_recorder_key_count_is_zero()
        {
            Assert.That(testRecorder.KeyCount, Is.EqualTo(0));
        }

        [Test]
        public void insert_new_key_increments_key_count()
        {
            testRecorder.Upsert("testKey", 1);

            Assert.That(testRecorder.KeyCount, Is.EqualTo(1));
        }

        [Test]
        public void insert_existing_key_maintains_key_count()
        {
            testRecorder.Upsert("testKey", 1);
            testRecorder.Upsert("testKey", 2);

            Assert.That(testRecorder.KeyCount, Is.EqualTo(1));
        }

        [TestCase("testKey1", 1)]
        [TestCase("testKey2", 2)]
        public void requesting_inserted_key_gives_associated_value(string key, int value)
        {
            testRecorder.Upsert(key, value);

            Assert.That(testRecorder.Get(key), Is.EqualTo(value));
        }

        [Test]
        public void insert_existing_key_updates_associated_value()
        {
            testRecorder.Upsert("testKey", 1);
            testRecorder.Upsert("testKey", 2);

            Assert.That(testRecorder.Get("testKey"), Is.EqualTo(2));
        }

        [Test]
        public void deleting_key_after_inserting_removes_key()
        {
            testRecorder.Upsert("testKey", 1);

            testRecorder.Delete("testKey");

            Assert.That(testRecorder.KeyCount, Is.EqualTo(0));
        }

        [Test]
        public void running_value_command_sets_value()
        {
            testRecorder.Do("value key 2");

            Assert.That(testRecorder.Get("key"), Is.EqualTo(2));
        }
    }
}
