#! /bin/sh

src=$(realpath "$(dirname "$0")/../src")
pkgs="$src/pkgs"

publish() {
  dotnet nuget push -s Local "bin/Release/*.nupkg"
}

rm -rf "$pkgs"
mkdir -p "$pkgs/hierarchicalplacehoder/1.0.0"
touch "$pkgs/hierarchicalplacehoder/1.0.0/hierarchicalplacehoder.nuspec"

# Build MyPackage
cd "$src/MyPackage"
dotnet pack -c Release -p:Version=1.0.0
dotnet pack -c Release -p:Version=1.1.0
publish

# Build Lib
cd "$src/MyLib"
dotnet pack -c Release
publish

# Build TestApp
cd "$src/TestApp"
dotnet publish -c Release