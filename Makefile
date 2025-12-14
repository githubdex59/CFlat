BUILD_LEVEL ?= Debug 

#SHELL := $(/usr/bin/env bash) 

test:
	dotnet run --project Tests/Tests.csproj
	
build:
	dotnet build CFlat/ -c $(BUILD_LEVEL)
	
docs:
	rm -r Doc/html Docs/Static/* || true
	doxygen
	cp -r Doc/html/* Docs/Static

prepare_for_commit: docs
	git add .
	git diff HEAD > .changes