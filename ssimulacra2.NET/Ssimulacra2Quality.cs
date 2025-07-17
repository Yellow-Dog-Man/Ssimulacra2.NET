namespace ssimulacra2.NET;

public enum Ssimulacra2Quality : int
{
    ExtremelyLow = 0,
    VeryLow = 10,
    Low = 30,
    Medium = 50,
    High = 70,
    VeryHigh = 80,
    Excellent = 85,
    VisuallyLossless = 90,
    Lossless = 100
}
public static class Ssimulacra2QualityConversion
{
    public static Ssimulacra2Quality FromScore(double score)
    {
        if (score <= (int)Ssimulacra2Quality.ExtremelyLow)
            return Ssimulacra2Quality.ExtremelyLow;

        if (score <= (int)Ssimulacra2Quality.VeryLow)
            return Ssimulacra2Quality.VeryLow;

        if (score <= (int)Ssimulacra2Quality.Low)
            return Ssimulacra2Quality.Low;

        if (score <= (int)Ssimulacra2Quality.Medium)
            return Ssimulacra2Quality.Medium;

        if (score <= (int)Ssimulacra2Quality.High)
            return Ssimulacra2Quality.High;

        if (score <= (int)Ssimulacra2Quality.VeryHigh)
            return Ssimulacra2Quality.VeryHigh;

        if (score <= (int)Ssimulacra2Quality.Excellent)
            return Ssimulacra2Quality.Excellent;

        if (score <= (int)Ssimulacra2Quality.VisuallyLossless)
            return Ssimulacra2Quality.VisuallyLossless;

        return Ssimulacra2Quality.Lossless;
    }
}
