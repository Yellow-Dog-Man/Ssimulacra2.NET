namespace ssimulacra2.NET.Tests;

public static class SnapshotUtilities
{
    public static byte[] Load(string relativePath)
    {
        var path = CurrentFile.Relative(Path.Combine("Resources", relativePath));
        
        Assert.IsTrue(File.Exists(path), "Input file must exist!");
        var bytes = File.ReadAllBytes(path);

        Assert.IsGreaterThan(0, bytes.Length, "Image must contain bytes");

        return bytes;
    }
}
