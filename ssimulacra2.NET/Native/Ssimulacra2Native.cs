namespace ssimulacra2.NET.Native;

using System;
using System.Runtime.InteropServices;
using ssimulacra2.NET.Data;

internal static partial class Ssimulacra2Native
{
    private const string LibraryName = "ssimulacra2";

    [LibraryImport(LibraryName, EntryPoint = "ssimulacra2_compute_from_files")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial double ComputeFromFiles(
        [MarshalAs(UnmanagedType.LPStr)] string originalPath,
        [MarshalAs(UnmanagedType.LPStr)] string distortedPath,
        out Ssimulacra2Result result);

    [LibraryImport(LibraryName, EntryPoint = "ssimulacra2_compute_from_files_with_background")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial double ComputeFromFilesWithBackground(
        [MarshalAs(UnmanagedType.LPStr)] string originalPath,
        [MarshalAs(UnmanagedType.LPStr)] string distortedPath,
        float bgIntensity,
        out Ssimulacra2Result result);

    [LibraryImport(LibraryName, EntryPoint = "ssimulacra2_compute_from_memory")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial double ComputeFromMemory(
        [In] byte[] originalData,
        int originalSize,
        [In] byte[] distortedData,
        int distortedSize,
        out Ssimulacra2Result result);

    [LibraryImport(LibraryName, EntryPoint = "ssimulacra2_compute_from_memory_with_background")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial double ComputeFromMemoryWithBackground(
        [In] byte[] originalData,
        int originalSize,
        [In] byte[] distortedData,
        int distortedSize,
        float bgIntensity,
        out Ssimulacra2Result result);

    [LibraryImport(LibraryName, EntryPoint = "ssimulacra2_get_error_message")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial IntPtr GetErrorMessage(Ssimulacra2Result result);

    [LibraryImport(LibraryName, EntryPoint = "ssimulacra2_get_version")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial IntPtr GetVersionPtr();

    /// <summary>
    /// Get library version string
    /// </summary>
    /// <returns>Version string</returns>
    public static string GetVersion()
    {
        IntPtr ptr = GetVersionPtr();
        return Marshal.PtrToStringAnsi(ptr) ?? "Unknown version";
    }
}
