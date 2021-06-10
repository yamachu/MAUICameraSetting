DOTNET = dotnet
PROJECT = MAUICameraSetting

CONFIGURATION = Debug # or Release

restore:
	$(DOTNET) restore $(PROJECT)

run/mac:
	$(DOTNET) build -t:Run -f net6.0-maccatalyst -c $(CONFIGURATION) $(PROJECT)
