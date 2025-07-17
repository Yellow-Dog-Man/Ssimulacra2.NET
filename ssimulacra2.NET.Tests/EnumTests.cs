namespace ssimulacra2.NET.Tests;

[TestClass]
public class EnumTests
{
    [DataRow(-1, Ssimulacra2Quality.ExtremelyLow)]
    [DataRow(-400, Ssimulacra2Quality.ExtremelyLow)]

    [DataRow(0, Ssimulacra2Quality.ExtremelyLow)]
    [DataRow(10, Ssimulacra2Quality.VeryLow)]
    [DataRow(30, Ssimulacra2Quality.Low)]
    [DataRow(50, Ssimulacra2Quality.Medium)]
    [DataRow(70, Ssimulacra2Quality.High)]
    [DataRow(80, Ssimulacra2Quality.VeryHigh)]
    [DataRow(85, Ssimulacra2Quality.Excellent)]
    [DataRow(90, Ssimulacra2Quality.VisuallyLossless)]
    [DataRow(100, Ssimulacra2Quality.Lossless)]
    
    [TestMethod]
    public void TestEnumConversion(double score, Ssimulacra2Quality expectedQuality)
    {
        Assert.AreEqual(expectedQuality, Ssimulacra2QualityConversion.FromScore(score));
    }
}


