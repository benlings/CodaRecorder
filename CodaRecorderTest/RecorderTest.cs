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

    [TestFixture]
    class Notification_spec
    {
        private Recorder testRecorder;

        [SetUp]
        public void SetUpTestRecorder()
        {
            testRecorder = new Recorder();
        }

        [Test]
        public void notification_fired_every_valid_message()
        {
            var observer = new MockObserver();
            testRecorder.RegisterObserver(observer);
            testRecorder.Do("value key 2");

            Assert.That(observer.Called);

            Assert.That(observer.Added, Is.EquivalentTo(new[]{"key"}));
            Assert.That(observer.Removed, Is.EquivalentTo(new string[]{}));
        }
    }

    class MockObserver : IRecorderObserver
    {
        public bool Called { get; set; }
        public List<String> Added { get; private set; }
        public List<String> Removed { get; private set; }
        public void  KeysChanged(ISet<string> added, ISet<string> removed, IDictionary<string, int> updated)
        {
            this.Called = true;
            this.Added = added.ToList<string>();
            this.Removed = removed.ToList<string>();
        }
}

}
