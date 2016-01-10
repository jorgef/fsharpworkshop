#!/bin/bash
mono --runtime=v4.0 ../.paket/paket.bootstrapper.exe
mono --runtime=v4.0 ../.paket/paket.exe restore
mono --runtime=v4.0 ../packages/FAKE/tools/FAKE.exe RunApp.fsx $@