## Tool for extrating files from UE5 pak/ucas/utoc files.

Built on CUE4Parse.

---

## Usage

**I think it currently only supports entire directories, not single files. I can't remember, it's late and I've been up all night.** Definitely need to fix that... haha.

```
Usage: PakFileManagerTool <aesKey> <gameVersion> <inputDirectory> <outputDirectory>
```

`<gameVersion>` supports flags like `GAME_UE5_1`.

I need to remove this check and just check it against the pak/ucas/utoc files instead.

But I haven't yet, so it's required. lmao.

Not sure if `<aesKey>` supports null/blank. Haven't tried it.

Example command:

```
PakFileManagerTool 0x123456 GAME_UE5_3 C:\gameName\Content\Paks\~mods\modName C:\export
```

## Building
- `git clone`
- `dotnet add package CUE4Parse`
- `dotnet build`