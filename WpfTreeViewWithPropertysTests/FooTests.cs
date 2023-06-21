using System;
using System.Collections.Generic;
using NUnit.Framework;
using WpfTreeViewWithProperties.Core;

namespace WpfTreeViewWithPropertysTests {
    [TestFixture]
    public class Tests {
        [Test]
        public void TO_CREATE_A_CLASS_TEST() {
            BaseFoo baseFoo = new BaseFoo();
            
            Assert.NotNull(baseFoo);
        }
        
        [Test]
        public void SET_THE_FIELDS_OF_THE_CLASS_AND_VERIFY_THEIR_RECEIPT_TEST() {
            BaseFoo baseFoo = new BaseFoo();
            Dictionary<string, object> expected = new Dictionary<string, object>
            {
                { "PositionNumber", 13 },
                { "PositionName", "Pump" },
                { "PositionPower", 13.3 }
            };

            baseFoo.PositionNumber = 13;
            baseFoo.PositionName = "Pump";
            baseFoo.PositionPower = 13.3;
            var actual = baseFoo.FooFields;
            
            Assert.AreEqual(expected,actual);
        }
        
        [Test]
        public void SET_CLASS_FIELDS_THROUGH_THE_DICTIONARY_TEST() {
            BaseFoo baseFoo = new BaseFoo();
            Dictionary<string, object> expected = new Dictionary<string, object>
            {
                { "PositionNumber", 13 },
                { "PositionName", "Pump" },
                { "PositionPower", 13.3 }
            };

            baseFoo.FooFields = expected;
            var actual = baseFoo.FooFields;
            
            Assert.AreEqual(expected,actual);
        }
    }
}