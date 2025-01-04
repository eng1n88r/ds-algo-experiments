using DsAlRankToGlory.Utilities;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsAlRankToGlory.Tests.Utilities;

[TestClass]
[TestSubject(typeof(Bitwise))]
public class BitwiseTest
{
   [TestMethod()]
   public void ApplyTest()
   {
      var result = Bitwise.Add(10, 5);

      Assert.AreEqual(result, 15);
   }
}