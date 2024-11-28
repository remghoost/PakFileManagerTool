## Tool for extrating files from UE5 pak/ucas/utoc files.

Built on CUE4Parse.

---

## Usage

```
Usage: PakFileManager <aesKey> <gameVersion> <inputDirectory> <outputDirectory>
```

`<gameVersion>` supports flags like `GAME_UE5_1`.

I need to remove this check and just check it against the pak/ucas/utoc files instead.

But I haven't yet, so it's required. lmao.

## Building
- `git clone`
- `dotnet add package CUE4Parse`
- `dotnet build`