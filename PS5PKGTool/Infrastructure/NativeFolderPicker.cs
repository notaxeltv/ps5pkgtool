namespace PS5PKGTool.Infrastructure;

/// <summary>
/// Folder selection helper. Uses the Vista dialog with the description as the title, and can
/// collect multiple folders by reopening after each pick.
/// </summary>
internal static class NativeFolderPicker
{
    /// <summary>
    /// Shows a folder browser. When <paramref name="allowMultiple"/> is true,
    /// <paramref name="askAddAnother"/> is required and is called after each successful pick.
    /// </summary>
    public static IReadOnlyList<string> PickFolders(
        IWin32Window owner,
        string title,
        bool allowMultiple = false,
        Func<string, bool>? askAddAnother = null)
    {
        if (allowMultiple && askAddAnother is null)
            throw new ArgumentNullException(nameof(askAddAnother));

        using var dialog = new FolderBrowserDialog
        {
            Description = title,
            UseDescriptionForTitle = true,
            ShowNewFolderButton = false,
        };

        var paths = new List<string>();
        while (true)
        {
            if (dialog.ShowDialog(owner) != DialogResult.OK)
                break;

            string path = dialog.SelectedPath;
            if (!string.IsNullOrWhiteSpace(path) &&
                !paths.Contains(path, StringComparer.OrdinalIgnoreCase))
                paths.Add(path);

            if (!allowMultiple || paths.Count == 0)
                break;

            if (!askAddAnother!(path))
                break;
        }

        return paths;
    }
}
