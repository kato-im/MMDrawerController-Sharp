LIBRARY=MMDrawerController
XCODE_PROJECT=$(LIBRARY).xcodeproj
XAMARIN_PROJECT=$(LIBRARY)-Sharp

all: $(XAMARIN_PROJECT)/lib$(LIBRARY).a

libMMDrawerController-i386.a:
	xcodebuild -project $(XCODE_PROJECT) -target $(LIBRARY) -sdk iphonesimulator -configuration Release clean build
	-mv build/Release-iphonesimulator/lib$(LIBRARY).a $@

libMMDrawerController-armv6.a:
	xcodebuild -project $(XCODE_PROJECT) -target $(LIBRARY) -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv build/Release-iphoneos/lib$(LIBRARY).a $@

libMMDrawerController-armv7.a:
	xcodebuild -project $(XCODE_PROJECT) -target $(LIBRARY) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv build/Release-iphoneos/lib$(LIBRARY).a $@

$(XAMARIN_PROJECT)/lib$(LIBRARY).a: libMMDrawerController-armv7.a libMMDrawerController-i386.a
	lipo -create -output $@ $^

#XMBindingLibrary.dll: AssemblyInfo.cs XMBindingLibrarySample.cs extras.cs libXMBindingLibrarySampleUniversal.a
	#$(BTOUCH) -unsafe -out:$@ XMBindingLibrarySample.cs -x=AssemblyInfo.cs -x=extras.cs --link-with=libXMBindingLibrarySampleUniversal.a,libXMBindingLibrarySampleUniversal.a

clean:
	-rm -f *.a $(XAMARIN_PROJECT)/*.a *.dll
