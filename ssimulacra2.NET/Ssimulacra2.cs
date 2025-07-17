using ssimulacra2.NET.Data;
using ssimulacra2.NET.Native;

namespace ssimulacra2.NET;

public class Ssimulacra2
{
    /// <summary>
    /// Compute SSIMULACRA2 score between two image files
    /// </summary>
    /// <param name="originalPath">Path to the original image</param>
    /// <param name="distortedPath">Path to the distorted image</param>
    /// <returns>SSIMULACRA2 score (range -inf to 100)</returns>
    /// <exception cref="Ssimulacra2Exception">Thrown when computation fails</exception>
    public static double ComputeFromFiles(string originalPath, string distortedPath)
    {
        double score = Ssimulacra2Native.ComputeFromFiles(originalPath, distortedPath, out Ssimulacra2Result result);

        if (result != Ssimulacra2Result.Ok)
        {
            throw new Ssimulacra2Exception(result);
        }

        return score;
    }

    /// <summary>
    /// Compute SSIMULACRA2 score between two image files with custom background intensity for alpha blending
    /// </summary>
    /// <param name="originalPath">Path to the original image</param>
    /// <param name="distortedPath">Path to the distorted image</param>
    /// <param name="backgroundIntensity">Background intensity for alpha blending (0.0 to 1.0)</param>
    /// <returns>SSIMULACRA2 score (range -inf to 100)</returns>
    /// <exception cref="Ssimulacra2Exception">Thrown when computation fails</exception>
    public static double ComputeFromFiles(string originalPath, string distortedPath, float backgroundIntensity)
    {
        double score = Ssimulacra2Native.ComputeFromFilesWithBackground(originalPath, distortedPath, backgroundIntensity, out Ssimulacra2Result result);

        if (result != Ssimulacra2Result.Ok)
        {
            throw new Ssimulacra2Exception(result);
        }

        return score;
    }

    /// <summary>
    /// Compute SSIMULACRA2 score between two images from memory buffers
    /// </summary>
    /// <param name="originalData">Original image data (PNG/JPEG bytes)</param>
    /// <param name="distortedData">Distorted image data (PNG/JPEG bytes)</param>
    /// <returns>SSIMULACRA2 score (range -inf to 100)</returns>
    /// <exception cref="Ssimulacra2Exception">Thrown when computation fails</exception>
    public static double ComputeFromMemory(byte[] originalData, byte[] distortedData)
    {
        ArgumentNullException.ThrowIfNull(originalData, nameof(originalData));
        ArgumentNullException.ThrowIfNull(distortedData, nameof(distortedData));

        double score = Ssimulacra2Native.ComputeFromMemory(
            originalData, originalData.Length,
            distortedData, distortedData.Length,
            out Ssimulacra2Result result);

        if (result != Ssimulacra2Result.Ok)
        {
            throw new Ssimulacra2Exception(result);
        }

        return score;
    }

    /// <summary>
    /// Compute SSIMULACRA2 score between two images from memory buffers with custom background intensity
    /// </summary>
    /// <param name="originalData">Original image data (PNG/JPEG bytes)</param>
    /// <param name="distortedData">Distorted image data (PNG/JPEG bytes)</param>
    /// <param name="backgroundIntensity">Background intensity for alpha blending (0.0 to 1.0)</param>
    /// <returns>SSIMULACRA2 score (range -inf to 100)</returns>
    /// <exception cref="Ssimulacra2Exception">Thrown when computation fails</exception>
    public static double ComputeFromMemory(byte[] originalData, byte[] distortedData, float backgroundIntensity)
    {
        ArgumentNullException.ThrowIfNull(originalData, nameof(originalData));
        ArgumentNullException.ThrowIfNull(distortedData, nameof(distortedData));

        double score = Ssimulacra2Native.ComputeFromMemoryWithBackground(
            originalData, originalData.Length,
            distortedData, distortedData.Length,
            backgroundIntensity,
            out Ssimulacra2Result result);

        if (result != Ssimulacra2Result.Ok)
        {
            throw new Ssimulacra2Exception(result);
        }

        return score;
    }
}
