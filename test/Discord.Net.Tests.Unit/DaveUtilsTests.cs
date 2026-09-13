using Discord.LibDave;
using System.Globalization;
using System.Text;
using Xunit;

namespace Discord;

public class DaveUtilsTests
{
    [Fact]
    public unsafe void ToCStringTerminatesSnowflake()
    {
        const ulong id = ulong.MaxValue;

        using var allocation = Discord.LibDave.Utils.ToCString(id, out var bytes);

        Assert.Equal(id.ToString(CultureInfo.InvariantCulture), Encoding.UTF8.GetString(bytes));
        Assert.Equal(0, ((byte*)allocation.Pointer)[bytes.Length]);
    }
}
