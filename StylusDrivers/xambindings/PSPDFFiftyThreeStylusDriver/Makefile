MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
XAMPROJECT=PSPDFFiftyThreeStylusDriver

all: build

build:
	$(MONOXBUILD) /p:Configuration=Release $(XAMPROJECT).csproj
	cp bin/Release/$(XAMPROJECT).dll ../../$(XAMPROJECT).dll

clean:
	-rm -rf bin/ obj/ *.userprefs
