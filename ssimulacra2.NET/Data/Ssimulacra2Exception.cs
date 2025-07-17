namespace ssimulacra2.NET.Data;

using ssimulacra2.NET.Native;
using System;
using System.Runtime.InteropServices;

/// <summary>
/// Exception thrown by SSIMULACRA2 operations
/// </summary>
public class Ssimulacra2Exception : Exception
{
    public Ssimulacra2Result ResultCode { get; }

    public Ssimulacra2Exception(string message, Ssimulacra2Result resultCode) : base(message)
    {
        ResultCode = resultCode;
    }

    public Ssimulacra2Exception(Ssimulacra2Result resultCode): base("Failed to compute SSIMULACRA2 score: " + GetErrorMessage(resultCode))
    {
        ResultCode = resultCode;
    }

    public Ssimulacra2Exception(string message, Ssimulacra2Result resultCode, Exception innerException)
        : base(message, innerException)
    {
        ResultCode = resultCode;
    }

    /// <summary>
    /// Get error message for a result code
    /// </summary>
    /// <param name="result">Result code</param>
    /// <returns>Error message string</returns>
    public static string GetErrorMessage(Ssimulacra2Result result)
    {
        IntPtr ptr = Ssimulacra2Native.GetErrorMessage(result);
        return Marshal.PtrToStringAnsi(ptr) ?? "Unknown error";
    }
}
