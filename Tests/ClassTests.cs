using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vancouver.Tests {
    public class ClassTests<T> : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            type = typeof(T);
        }
    }
}