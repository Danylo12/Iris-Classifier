DOTNET = dotnet
PROJECT = PO2.csproj

all: build

build:
	$(DOTNET) build $(PROJECT)

run:
	$(DOTNET) run --project $(PROJECT)

clean:
	$(DOTNET) clean
	rm -rf bin/ obj/