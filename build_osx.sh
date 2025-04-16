#!/bin/bash
# Requires Lua 5.4
# Apple Silicon only

set -e  # Exit on error
RELEASE="release/"
BIN="bin/release/net9.0/osx-arm64/"
ASSETS="assets/"

# Clean up any previous release directory
if [ -d "$RELEASE" ]; then
    rm -rf "$RELEASE"
fi

dotnet build --ucr -c Release -v diag
mkdir -p "$RELEASE"
cp -r "$ASSETS" "$RELEASE"
cp -r "${BIN}"* "$RELEASE"
find "$RELEASE" -type f -name "*.pdb" -exec rm -f {} \;

lua manifest-tool.lua -maj 1 -min 1 -ptc 0 -stg PRE-ALPHA
mv "manifest.json" "$RELEASE"
echo "NeonDreams is ready."
