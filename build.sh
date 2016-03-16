#!/bin/bash
set -x

# usage: ./fake.sh

# uncomment line below to gather verbose output from "mono"
# export MONO_LOG_LEVEL=debug

export CORE=/Library/Frameworks/Mono.framework/Versions/4.0.3/lib/mono/4.5
export FSHARPCORE=/Library/Frameworks/Mono.framework/Versions/4.0.3/lib/mono/gac/FSharp.Core/4.3.1.0__b03f5f7f11d50a3a

export MONO_PATH=${FSHARPCORE}:${CORE}

mono .paket/paket.exe restore
mono .paket/paket.exe install
mono packages/FAKE/tools/FAKE.exe build.fsx "$@"