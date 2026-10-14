# ProsperoPkgTool (submodule)

ProsperoPkgTool is no longer vendored as a prebuilt DLL.

The engine is built from source via the git submodule at `deps/ProsperoPkgTool`
(pinned to the validated revision recorded in `VERSION.txt`).

```
git submodule update --init --recursive
dotnet build .\PS5PKGTool.slnx -c Release
```
