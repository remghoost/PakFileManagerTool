## Tool for extrating files from UE5 pak/ucas/utoc files.

Built on CUE4Parse.

---

## Usage

**I think it currently only supports entire directories, not single files.** <br />I can't remember, it's late and I've been up all night.<br /> Definitely need to fix that... haha.

```
Usage: PakFileManagerTool <aesKey> <gameVersion> <inputDirectory> <outputDirectory>
```

- `<gameVersion>` supports flags like `GAME_UE5_1`. <br />
I need to remove this check and just check it against the pak/ucas/utoc files instead. <br />
But I haven't yet, so it's required. lmao.

- Not sure if `<aesKey>` supports null/blank. <br />
Haven't tried it.

Example command:

```
PakFileManagerTool 0x123456 GAME_UE5_3 C:\gameName\Content\Paks\~mods\modName C:\export
```


## Building
- `git clone --recurse-submodules https://github.com/remghoost/PakFileManagerTool`
- `dotnet add package CUE4Parse`
<br /> <br />
Then depending on if you want a build or a published, single exe:<br /><br />
- `dotnet build`<br />
or 
- `dotnet publish -c Release -r win-x64 --self-contained /p:PublishSingleFile=true`
