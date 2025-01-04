using DsAlRankToGlory.Problems.MatrixProblems;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsAlRankToGlory.Tests.Problems.MatrixProblems;

[TestClass]
[TestSubject(typeof(MatrixRotation))]
public class MatrixRotationTest
{
    private readonly MatrixRotation rotator = new MatrixRotation();

    [TestMethod()]
    public void RotateTest()
    {
        var matrix = new int[3][] {
            new int[3] { 1, 2, 3 },
            new int[3] { 4, 5, 6 },
            new int[3] { 6, 7, 8 }
        };

        rotator.Rotate(matrix);

        Assert.Fail();
    }
}