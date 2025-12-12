BUILD_LEVEL ?= Debug 

test:
	dotnet run --project Tests/Tests.csproj
	
build:
	dotnet build CFlat/ -c $(BUILD_LEVEL)
	
