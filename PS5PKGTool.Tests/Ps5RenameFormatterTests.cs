using PS5PKGTool.Core.Services;
using Xunit;

namespace PS5PKGTool.Tests;

public class Ps5RenameFormatterTests
{
    [Fact]
    public void Expand_ReplacesKnownTokens()
    {
        var tokens = new Ps5RenameTokens(Title: "Demo Game", TitleId: "PPSA12345", Version: "01.00");
        string result = Ps5RenameFormatter.Expand("{TITLE} [{TITLE_ID}] [{VERSION}]", tokens, "fallback");
        Assert.Equal("Demo Game [PPSA12345] [01.00]", result);
    }

    [Fact]
    public void Expand_DropsEmptyBracketGroups()
    {
        var tokens = new Ps5RenameTokens(Title: "Alone", TitleId: "", Version: "");
        string result = Ps5RenameFormatter.Expand("{TITLE} [{TITLE_ID}] [{VERSION}]", tokens, "fallback");
        Assert.Equal("Alone", result);
    }

    [Fact]
    public void Expand_UsesFallbackWhenFormatEmpty()
    {
        string result = Ps5RenameFormatter.Expand("   ", Ps5RenameTokens.Empty, "Fallback Name");
        Assert.Equal("Fallback Name", result);
    }

    [Fact]
    public void Sanitize_ReplacesInvalidFileNameCharacters()
    {
        // Path.GetInvalidFileNameChars() is OS-specific; '/' is invalid on every platform.
        string result = Ps5RenameFormatter.Sanitize("Part/Name");
        Assert.Equal("Part_Name", result);
    }

    [Theory]
    [InlineData("CON")]
    [InlineData("nul")]
    [InlineData("COM1")]
    public void Sanitize_PrefixesReservedDeviceNames(string reserved)
    {
        string result = Ps5RenameFormatter.Sanitize(reserved);
        Assert.Equal("_" + reserved, result);
    }

    [Fact]
    public void Presets_ContainDefaultTitleIdPattern()
    {
        Assert.Contains(Ps5RenameFormats.Presets, preset =>
            preset.Format.Equals("{TITLE} [{TITLE_ID}]", StringComparison.OrdinalIgnoreCase));
    }
}
