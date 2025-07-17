namespace ssimulacra2.NET.Tests
{
    [TestClass]
    public sealed class ScoringTests
    {
        [DataRow("carrots.png")]
        [DataRow("apples.png")]
        [DataRow("bananas.png")]
        [TestMethod]
        public void TestIdentical(string file)
        {
            var bytes = SnapshotUtilities.Load(file);
            var score = Ssimulacra2.ComputeFromMemory(bytes, bytes);
            Assert.AreEqual(100, score, "Identical images must have max score");
        }

        [TestMethod]
        public void TestCompletelyDifferent()
        {
            var bytes = SnapshotUtilities.Load("carrots.png");
            var bytes2 = SnapshotUtilities.Load("apples.png");
            var score = Ssimulacra2.ComputeFromMemory(bytes, bytes2);

            Assert.IsLessThan(0, score, "Different images must have negative scores");
        }

        [DataRow(Ssimulacra2Quality.ExtremelyLow, "apples.png", "apples_flipped.png")]
        [DataRow(Ssimulacra2Quality.ExtremelyLow, "apples.png", "apples_shifted.png")]
        [DataRow(Ssimulacra2Quality.Medium, "apples.png", "apples_quality.png")]
        [TestMethod]
        public void Test2Paths(Ssimulacra2Quality expectedQuality, string fileA, string fileB)
        {
            var bytes = SnapshotUtilities.Load(fileA);
            var bytes2 = SnapshotUtilities.Load(fileB);
            var score = Ssimulacra2.ComputeFromMemory(bytes, bytes2);

            Assert.AreEqual(expectedQuality, Ssimulacra2QualityConversion.FromScore(score));
        }
        
    }
}
