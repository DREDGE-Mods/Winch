using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Winch
{
    /// <summary>
    /// A value type for holding Unity versions
    /// </summary>
    public readonly partial struct UnityVersion : IEquatable<UnityVersion>, IComparable, IComparable<UnityVersion>
    {
        private const int majorOffset = 48;
        private const int minorOffset = 32;
        private const int buildOffset = 16;
        private const int typeOffset = 8;

        private const ulong byteMask = 0xFFUL;
        private const ulong ushortMask = 0xFFFFUL;

        private readonly ulong m_data;

        /// <summary>
        /// The first number in a Unity version string
        /// </summary>
        public ushort Major => unchecked((ushort)((m_data >> majorOffset) & ushortMask));

        /// <summary>
        /// The second number in a Unity version string
        /// </summary>
        public ushort Minor => unchecked((ushort)((m_data >> minorOffset) & ushortMask));

        /// <summary>
        /// The third number in a Unity version string
        /// </summary>
        public ushort Build => unchecked((ushort)((m_data >> buildOffset) & ushortMask));

        /// <summary>
        /// The letter in a Unity version string
        /// </summary>
        public VersionType Type => (VersionType)unchecked((byte)((m_data >> typeOffset) & byteMask));

        /// <summary>
        /// The last number in a Unity version string
        /// </summary>
        public byte TypeNumber => unchecked((byte)(m_data & byteMask));

        /// <summary>
        /// The minimum value this type can have
        /// </summary>
        public static UnityVersion MinVersion { get; } = new UnityVersion(0UL);

        /// <summary>
        /// The maximum value this type can have
        /// </summary>
        public static UnityVersion MaxVersion { get; } = new UnityVersion(ulong.MaxValue);

        /// <summary>
        /// Construct a new Unity version
        /// </summary>
        public UnityVersion(ushort major, ushort minor, ushort build) : this(major, minor, build, VersionType.Final, 1)
        {
        }

        /// <summary>
        /// Construct a new Unity version
        /// </summary>
        public UnityVersion(ushort major, ushort minor, ushort build, VersionType type, byte typeNumber) : this(
                ((ulong)major << majorOffset) | ((ulong)minor << minorOffset) | ((ulong)build << buildOffset)
                    | ((ulong)type << typeOffset) | typeNumber
            )
        {
        }

        private UnityVersion(ulong data)
        {
            m_data = data;
        }

        /// <summary>
        /// Converts this to its binary representation
        /// </summary>
        /// <returns>An unsigned long integer having the same bits as this</returns>
        public ulong GetBits() => m_data;

        /// <summary>
        /// Converts a binary representation into its respective version
        /// </summary>
        /// <param name="bits">An unsigned long integer having the relevant bits</param>
        /// <returns>A new Unity version with the cooresponding bits</returns>
        public static UnityVersion FromBits(ulong bits) => new UnityVersion(bits);

        /// <summary>
        /// Compare to another object
        /// </summary>
        /// <param name="obj">Another object</param>
        /// <returns>
        /// 1 if this is larger or the other is not a Unity version<br/>
        /// -1 if this is smaller<br/>
        /// 0 if equal
        /// </returns>
        public int CompareTo(object? obj)
        {
            return obj is UnityVersion version ? CompareTo(version) : 1;
        }

        /// <summary>
        /// Compare two Unity versions
        /// </summary>
        /// <param name="other">Another Unity version</param>
        /// <returns>
        /// 1 if this is larger<br/>
        /// -1 if this is smaller<br/>
        /// 0 if equal
        /// </returns>
        public int CompareTo(UnityVersion other)
        {
            return m_data.CompareTo(other.m_data);
        }

        /// <summary>
        /// Check equality with another object
        /// </summary>
        /// <param name="obj">Another object</param>
        /// <returns>True if they're equal; false otherwise</returns>
        public override bool Equals(object? obj)
        {
            return obj is UnityVersion version && this == version;
        }

        /// <summary>
        /// Check equality with another Unity version
        /// </summary>
        /// <param name="other">Another Unity version</param>
        /// <returns>True if they're equal; false otherwise</returns>
        public bool Equals(UnityVersion other) => this == other;

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return m_data.GetHashCode();
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">The left Unity version</param>
        /// <param name="right">The right Unity version</param>
        /// <returns></returns>
        public static bool operator ==(UnityVersion left, UnityVersion right)
        {
            return left.m_data == right.m_data;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">The left Unity version</param>
        /// <param name="right">The right Unity version</param>
        /// <returns></returns>
        public static bool operator !=(UnityVersion left, UnityVersion right)
        {
            return left.m_data != right.m_data;
        }

        /// <summary>
        /// Greater than
        /// </summary>
        /// <param name="left">The left Unity version</param>
        /// <param name="right">The right Unity version</param>
        /// <returns></returns>
        public static bool operator >(UnityVersion left, UnityVersion right)
        {
            return left.m_data > right.m_data;
        }

        /// <summary>
        /// Greater than or equal to
        /// </summary>
        /// <param name="left">The left Unity version</param>
        /// <param name="right">The right Unity version</param>
        /// <returns></returns>
        public static bool operator >=(UnityVersion left, UnityVersion right)
        {
            return left.m_data >= right.m_data;
        }

        /// <summary>
        /// Less than
        /// </summary>
        /// <param name="left">The left Unity version</param>
        /// <param name="right">The right Unity version</param>
        /// <returns></returns>
        public static bool operator <(UnityVersion left, UnityVersion right)
        {
            return left.m_data < right.m_data;
        }

        /// <summary>
        /// Less than or equal to
        /// </summary>
        /// <param name="left">The left Unity version</param>
        /// <param name="right">The right Unity version</param>
        /// <returns></returns>
        public static bool operator <=(UnityVersion left, UnityVersion right)
        {
            return left.m_data <= right.m_data;
        }

        private const ulong subMajorMask = 0x0000FFFFFFFFFFFFUL;
        private const ulong subMinorMask = 0x00000000FFFFFFFFUL;
        private const ulong subBuildMask = 0x000000000000FFFFUL;
        private const ulong subTypeMask = 0x00000000000000FFUL;

        public bool Equals(ushort major) => this == From(major);
        public bool Equals(ushort major, ushort minor) => this == From(major, minor);
        public bool Equals(ushort major, ushort minor, ushort build) => this == From(major, minor, build);
        public bool Equals(ushort major, ushort minor, ushort build, VersionType type) => this == From(major, minor, build, type);
        public bool Equals(ushort major, ushort minor, ushort build, VersionType type, byte typeNumber) => this == new UnityVersion(major, minor, build, type, typeNumber);
        public bool Equals(string version) => this == Parse(version);

        public bool LessThan(ushort major) => this < From(major);
        public bool LessThan(ushort major, ushort minor) => this < From(major, minor);
        public bool LessThan(ushort major, ushort minor, ushort build) => this < From(major, minor, build);
        public bool LessThan(ushort major, ushort minor, ushort build, VersionType type) => this < From(major, minor, build, type);
        public bool LessThan(ushort major, ushort minor, ushort build, VersionType type, byte typeNumber) => this < new UnityVersion(major, minor, build, type, typeNumber);
        public bool LessThan(string version) => this < Parse(version);

        public bool LessThanOrEquals(ushort major) => this <= From(major);
        public bool LessThanOrEquals(ushort major, ushort minor) => this <= From(major, minor);
        public bool LessThanOrEquals(ushort major, ushort minor, ushort build) => this <= From(major, minor, build);
        public bool LessThanOrEquals(ushort major, ushort minor, ushort build, VersionType type) => this <= From(major, minor, build, type);
        public bool LessThanOrEquals(ushort major, ushort minor, ushort build, VersionType type, byte typeNumber) => this <= new UnityVersion(major, minor, build, type, typeNumber);
        public bool LessThanOrEquals(string version) => this <= Parse(version);

        public bool GreaterThan(ushort major) => this > From(major);
        public bool GreaterThan(ushort major, ushort minor) => this > From(major, minor);
        public bool GreaterThan(ushort major, ushort minor, ushort build) => this > From(major, minor, build);
        public bool GreaterThan(ushort major, ushort minor, ushort build, VersionType type) => this > From(major, minor, build, type);
        public bool GreaterThan(ushort major, ushort minor, ushort build, VersionType type, byte typeNumber) => this > new UnityVersion(major, minor, build, type, typeNumber);
        public bool GreaterThan(string version) => this > Parse(version);

        public bool GreaterThanOrEquals(ushort major) => this >= From(major);
        public bool GreaterThanOrEquals(ushort major, ushort minor) => this >= From(major, minor);
        public bool GreaterThanOrEquals(ushort major, ushort minor, ushort build) => this >= From(major, minor, build);
        public bool GreaterThanOrEquals(ushort major, ushort minor, ushort build, VersionType type) => this >= From(major, minor, build, type);
        public bool GreaterThanOrEquals(ushort major, ushort minor, ushort build, VersionType type, byte typeNumber) => this >= new UnityVersion(major, minor, build, type, typeNumber);
        public bool GreaterThanOrEquals(string version) => this >= Parse(version);

        private UnityVersion From(ushort major)
        {
            ulong data = ((ulong)major << majorOffset) | subMajorMask & m_data;
            return new UnityVersion(data);
        }
        private UnityVersion From(ushort major, ushort minor)
        {
            ulong data = ((ulong)major << majorOffset) | ((ulong)minor << minorOffset) | subMinorMask & m_data;
            return new UnityVersion(data);
        }
        private UnityVersion From(ushort major, ushort minor, ushort build)
        {
            ulong data = ((ulong)major << majorOffset) | ((ulong)minor << minorOffset) | ((ulong)build << buildOffset) |
                subBuildMask & m_data;
            return new UnityVersion(data);
        }
        private UnityVersion From(ushort major, ushort minor, ushort build, VersionType type)
        {
            ulong data = ((ulong)major << majorOffset) | ((ulong)minor << minorOffset) | ((ulong)build << buildOffset) |
                ((ulong)(ushort)type << typeOffset) | subTypeMask & m_data;
            return new UnityVersion(data);
        }

        /// <summary>
        /// Serialize the version as a string with type.
        /// </summary>
        /// <returns>A new string like 2019.4.3f1</returns>
        public override string ToString() => ToString(false);

        /// <summary>
        /// Serialize the version as a string
        /// </summary>
        /// <param name="flags">The flags to control how the version is formatted</param>
        /// <returns>A new string containing the formatted version.</returns>
        public string ToString(bool excludeType)
        {
            return excludeType
                ? ToStringWithoutType()
                : $"{Major}.{Minor}.{Build}{ToCharacter(Type)}{TypeNumber}";
        }

        /// <summary>
        /// Serialize the version as a string using only <see cref="Major"/>, <see cref="Minor"/>, and <see cref="Build"/>.
        /// </summary>
        /// <returns>A new string like 2019.4.3</returns>
        public string ToStringWithoutType()
        {
            return $"{Major}.{Minor}.{Build}";
        }

        /// <summary>
        /// Parse a normal Unity version string
        /// </summary>
        /// <param name="s">A string to parse</param>
        /// <returns>The parsed Unity version</returns>
        /// <exception cref="ArgumentException">If the string is in an invalid format</exception>
        public static UnityVersion Parse(string s) => Parse(s, out _);

        /// <summary>
        /// Parse a normal Unity version string
        /// </summary>
        /// <param name="s">A string to parse</param>
        /// <param name="customEngine">Not null if this version was generated by a custom Unity Engine.</param>
        /// <returns>The parsed Unity version</returns>
        /// <exception cref="ArgumentException">If the string is in an invalid format</exception>
        public static UnityVersion Parse(string s, out string? customEngine)
        {
            return TryParse(s, out UnityVersion version, out customEngine)
                ? version
                : throw new ArgumentException($"Invalid version format: {s}", nameof(s));
        }


        private static readonly Regex normalRegex = new Regex(@"([0-9]+)\.([0-9]+)\.([0-9]+)\.?([abcfpx])([0-9]+)((?:.|[\r\n])+)?", RegexOptions.Compiled);

        public static bool TryMatch(Regex regex, string input, out Match? match)
        {
            match = regex.Match(input);
            if (match.Success)
            {
                return true;
            }
            else
            {
                match = null;
                return false;
            }
        }

        /// <summary>
        /// Try to parse a normal Unity version string
        /// </summary>
        /// <param name="s">A string to parse</param>
        /// <param name="version">The parsed Unity version</param>
        /// <param name="customEngine">Not null if this version was generated by a custom Unity Engine.</param>
        /// <returns>True if parsing was successful</returns>
        public static bool TryParse(string s, out UnityVersion version, out string? customEngine)
        {
            if(!string.IsNullOrEmpty(s) && TryMatch(normalRegex, s, out var match))
            {
                int major = int.Parse(match.Groups[1].Value);
                int minor = int.Parse(match.Groups[2].Value);
                int build = int.Parse(match.Groups[3].Value);
                char type = match.Groups[4].Value[0];
                int typeNumber = int.Parse(match.Groups[5].Value);
                customEngine = GetNullableString(match.Groups[6]);
                version = new UnityVersion((ushort)major, (ushort)minor, (ushort)build, ToVersionType(type), (byte)typeNumber);
                return true;
            }
            else
            {
                customEngine = null;
                version = default;
                return false;
            }

            static string? GetNullableString(Capture capture) => capture.Length == 0 ? null : capture.Value;
        }

        /// <summary>
        /// Change <see cref="Major"/>.
        /// </summary>
        /// <param name="value">The new value</param>
        /// <returns>A new <see cref="UnityVersion"/> with the changed value.</returns>
        public UnityVersion ChangeMajor(ushort value) => new UnityVersion(value, Minor, Build, Type, TypeNumber);

        /// <summary>
        /// Change <see cref="Minor"/>.
        /// </summary>
        /// <param name="value">The new value</param>
        /// <returns>A new <see cref="UnityVersion"/> with the changed value.</returns>
        public UnityVersion ChangeMinor(ushort value) => new UnityVersion(Major, value, Build, Type, TypeNumber);

        /// <summary>
        /// Change <see cref="Build"/>.
        /// </summary>
        /// <param name="value">The new value</param>
        /// <returns>A new <see cref="UnityVersion"/> with the changed value.</returns>
        public UnityVersion ChangeBuild(ushort value) => new UnityVersion(Major, Minor, value, Type, TypeNumber);

        /// <summary>
        /// Change <see cref="Type"/>.
        /// </summary>
        /// <param name="value">The new value</param>
        /// <returns>A new <see cref="UnityVersion"/> with the changed value.</returns>
        public UnityVersion ChangeType(VersionType value) => new UnityVersion(Major, Minor, Build, value, TypeNumber);

        /// <summary>
        /// Change <see cref="TypeNumber"/>.
        /// </summary>
        /// <param name="value">The new value</param>
        /// <returns>A new <see cref="UnityVersion"/> with the changed value.</returns>
        public UnityVersion ChangeTypeNumber(byte value) => new UnityVersion(Major, Minor, Build, Type, value);

        /// <summary>
        /// A maximizing function for Unity versions
        /// </summary>
        /// <param name="left">A Unity version</param>
        /// <param name="right">A Unity version</param>
        /// <returns>The larger Unity version</returns>
        public static UnityVersion Max(UnityVersion left, UnityVersion right)
        {
            return left > right ? left : right;
        }

        /// <summary>
        /// A minimizing function for Unity versions
        /// </summary>
        /// <param name="left">A Unity version</param>
        /// <param name="right">A Unity version</param>
        /// <returns>The smaller Unity version</returns>
        public static UnityVersion Min(UnityVersion left, UnityVersion right)
        {
            return left < right ? left : right;
        }

        /// <summary>
        /// A distance function for measuring version proximity
        /// </summary>
        /// <remarks>
        /// The returned value is ordinal and should not be saved anywhere.
        /// It's only for runtime comparisons, such as finding the closest version in a list.
        /// </remarks>
        /// <param name="left">A Unity version</param>
        /// <param name="right">A Unity version</param>
        /// <returns>
        /// An ordinal number representing the distance between 2 versions. 
        /// A value of zero means they're equal.
        /// </returns>
        public static ulong Distance(UnityVersion left, UnityVersion right)
        {
            return left.m_data < right.m_data
                ? right.m_data - left.m_data
                : left.m_data - right.m_data;
        }

        /// <summary>
        /// Get the closest Unity version in an array of versions using <see cref="Distance(UnityVersion, UnityVersion)"/>
        /// </summary>
        /// <param name="versions">The Unity version array</param>
        /// <returns>The closest Unity version</returns>
        /// <exception cref="ArgumentNullException">The array is null</exception>
        /// <exception cref="ArgumentException">The array is empty</exception>
        public UnityVersion GetClosestVersion(UnityVersion[] versions)
        {
            if (versions is null)
            {
                throw new ArgumentNullException(nameof(versions));
            }

            if (versions.Length == 0)
            {
                throw new ArgumentException("Length cannot be zero", nameof(versions));
            }

            UnityVersion result = versions[0];
            ulong currentDistance = Distance(this, result);
            for (int i = 1; i < versions.Length; i++)
            {
                ulong newDistance = Distance(this, versions[i]);
                if (newDistance < currentDistance)
                {
                    currentDistance = newDistance;
                    result = versions[i];
                }
            }

            return result;
        }

        /// <summary>
        /// An enumeration representing the letter in a Unity Version string
        /// </summary>
        public enum VersionType : byte
        {
            /// <summary>
            /// a
            /// </summary>
            Alpha = 0,
            /// <summary>
            /// b
            /// </summary>
            Beta,
            /// <summary>
            /// c
            /// </summary>
            China,
            /// <summary>
            /// f
            /// </summary>
            Final,
            /// <summary>
            /// p
            /// </summary>
            Patch,
            /// <summary>
            /// x
            /// </summary>
            Experimental,

            /// <summary>
            /// The minimum valid value for this enumeration
            /// </summary>
            MinValue = Alpha,
            /// <summary>
            /// The maximum valid value for this enumeration
            /// </summary>
            MaxValue = Experimental,
        }

        public static VersionType ToVersionType(char c)
        {
            return c switch
            {
                'a' => VersionType.Alpha,
                'b' => VersionType.Beta,
                'c' => VersionType.China,
                'f' => VersionType.Final,
                'p' => VersionType.Patch,
                'x' => VersionType.Experimental,
                _ => throw new ArgumentException($"There is no version type {c}", nameof(c)),
            };
        }

        /// <summary>
        /// Convert to the relevant character
        /// </summary>
        /// <param name="type">A Unity version type</param>
        /// <returns>The character this value represents</returns>
        /// <exception cref="ArgumentOutOfRangeException">The type is not a valid value</exception>
        public static char ToCharacter(VersionType type)
        {
            return type switch
            {
                VersionType.Alpha => 'a',
                VersionType.Beta => 'b',
                VersionType.China => 'c',
                VersionType.Final => 'f',
                VersionType.Patch => 'p',
                VersionType.Experimental => 'x',
                _ => 'u',//unknown
            };
        }
    }
}
