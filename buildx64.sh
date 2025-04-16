#!/bin/bash
# Lua 5.4 is required
# Linux x64 only, arm64 is explicitly NOT in support

set -e

RELEASE="release/"
BIN="bin/release/net9.0/linux-x64/"
ASSETS="assets/"
# Remove existing release directory if it exists
if [ -d "$RELEASE" ]; then
    rm -rf "$RELEASE"
fi

dotnet build --ucr -c Release -v diag
mkdir -p "$RELEASE"
cp -r "$ASSETS" "$RELEASE"
cp -r ${BIN}* "$RELEASE"

# Remove unnecessary files from the release directory
find "$RELEASE" -type f -name "*.pdb" -exec rm -f {} \;
lua manifest-tool.lua -maj 1 -min 1 -ptc 0 -stg PRE-ALPHA
cp manifest.json "$RELEASE"
rm -f manifest.json
echo "NeonDreams build is ready."
