using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WpfTreeViewWithProperties.Core;

namespace WpfTreeViewWithPropertysTests {
    [TestFixture]
    public class FooConsumerTest {
        [Test]
        public void TO_CREATE_A_CLASS_TEST() {
            BaseFoo baseFoo = new FooConsumer();
            
            Assert.NotNull(baseFoo);
        }

        [Test]
        public void SET_THE_FIELDS_OF_THE_CLASS_AND_VERIFY_THEIR_RECEIPT_TEST() {
            FooConsumer fooConsumer = new FooConsumer();
            Dictionary<string, object> expected = new Dictionary<string, object>
            {
                { "PositionNumber", 13 },
                { "PositionName", "Pump" },
                { "PositionCosPower", 0.1 },
                { "PositionTanPower", 0.2 },
                { "PositionKiPower", 0.3 },
                { "PositionPower", 13.3 },
            };

            fooConsumer.PositionNumber = 13;
            fooConsumer.PositionName = "Pump";
            fooConsumer.PositionCosPower = 0.1;
            fooConsumer.PositionTanPower = 0.2;
            fooConsumer.PositionKiPower = 0.3;
            fooConsumer.PositionPower = 13.3;
            var actual = fooConsumer.FooFields;

            expected.OrderBy(x => x.Key);
            actual.OrderBy(x => x.Key);
            
            Assert.That(actual,Is.EqualTo(expected));
        }
        
        [Test]
        public void SET_CLASS_FIELDS_THROUGH_THE_DICTIONARY_TEST() {
            FooConsumer fooConsumer = new FooConsumer();
            Dictionary<string, object> expected = new Dictionary<string, object>
            {
                { "PositionNumber", 13 },
                { "PositionTanPower", 0.2 },
                { "PositionName", "Pump" },
                { "PositionCosPower", 0.1 },
                { "PositionPower", 13.3 },
                { "PositionKiPower", 0.3 }
            };

            fooConsumer.FooFields = expected;
            Dictionary<string, object> actual = fooConsumer.FooFields;
            
            
            expected.OrderBy(x => x.Key);
            actual.OrderBy(x => x.Value);
            
            Assert.That(actual,Is.EqualTo(expected));
        }
    }
}