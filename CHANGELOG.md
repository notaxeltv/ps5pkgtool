# Changelog

## Unreleased

### Features

- Tools output filenames now follow **Settings → Naming** when the source is a library item (#17).
- Context menu **Remove from Library** drops list entries without deleting files; works for missing sources (#19, #20).
- File → Add / Open and Settings → Add Folder support multi-select; folder dialogs show the description as the title (#22).
- DarkUI and ProsperoPkgTool are git submodules under `deps/` and are listed in the solution (#18, #21).
- In-repo `PS5PKGTool.Tests` project and GitHub Actions CI on Windows.

### Notes

- AC (additional content) package builds remain unsupported.
- Generated packages/images are still untested on a jailbroken PS5 (#16).
