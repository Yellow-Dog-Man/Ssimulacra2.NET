namespace ssimulacra2.NET.Data;

/// <summary>
/// Error codes returned by SSIMULACRA2 functions
/// </summary>
public enum Ssimulacra2Result
{
    Ok = 0,
    InvalidInput = -1,
    FileNotFound = -2,
    UnsupportedFormat = -3,
    SizeMismatch = -4,
    TooSmall = -5,
    OutOfMemory = -6,
    Unknown = -99
}
