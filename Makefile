LIBRARY=MMDrawerController
XCODE_PROJECT=$(LIBRARY).xcodeproj

all: lib$(LIBRARY).a

libMMDrawerController-i386.a:
	xcodebuild -project $(XCODE_PROJECT) -target $(LIBRARY) -sdk iphonesimulator -configuration Release clean build
	-mv build/Release-iphonesimulator/lib$(LIBRARY).a $@

libMMDrawerController-armv6.a:
	xcodebuild -project $(XCODE_PROJECT) -target $(LIBRARY) -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv build/Release-iphoneos/lib$(LIBRARY).a $@

libMMDrawerController-armv7.a:
	xcodebuild -project $(XCODE_PROJECT) -target $(LIBRARY) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv build/Release-iphoneos/lib$(LIBRARY).a $@

lib$(LIBRARY).a: libMMDrawerController-armv7.a libMMDrawerController-i386.a
	lipo -create -output $@ $^

clean:
	-rm -f *.a *.dll
