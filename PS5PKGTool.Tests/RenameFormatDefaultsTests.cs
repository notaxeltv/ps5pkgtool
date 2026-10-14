using PS5PKGTool.Core.Services;
using Xunit;

namespace PS5PKGTool.Tests;

public class RenameFormatDefaultsTests
{
    [Fact]
    public void CustomLabel_IsStable()
    {
        Assert.False(string.IsNullOrWhiteSpace(Ps5RenameFormats.CustomLabel));
        Assert.Contains("Settings", Ps5RenameFormats.CustomLabel, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void TokenNames_IncludeCoreFields()
    {
        Assert.Contains("{TITLE}", Ps5RenameFormatter.TokenNames);
        Assert.Contains("{TITLE_ID}", Ps5RenameFormatter.TokenNames);
        Assert.Contains("{CONTENT_ID}", Ps5RenameFormatter.TokenNames);
    }
}
