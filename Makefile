#BINDDIR=/src/binding
#XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
#PROJECT_ROOT=XMBindingLibrarySample
#PROJECT=$(PROJECT_ROOT)/XMBindingLibrarySample.xcodeproj
#TARGET=XMBindingLibrarySample
#BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT=MMDrawerController.xcodeproj
TARGET=MMDrawerController

all: libMMDrawerController.a

libMMDrawerController-i386.a:
	xcodebuild -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv build/Release-iphonesimulator/lib$(TARGET).a $@

libMMDrawerController-armv6.a:
	xcodebuild -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv build/Release-iphoneos/lib$(TARGET).a $@

libMMDrawerController-armv7.a:
	xcodebuild -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv build/Release-iphoneos/lib$(TARGET).a $@

libMMDrawerController.a: libMMDrawerController-armv7.a libMMDrawerController-i386.a
	lipo -create -output $@ $^

#XMBindingLibrary.dll: AssemblyInfo.cs XMBindingLibrarySample.cs extras.cs libXMBindingLibrarySampleUniversal.a
	#$(BTOUCH) -unsafe -out:$@ XMBindingLibrarySample.cs -x=AssemblyInfo.cs -x=extras.cs --link-with=libXMBindingLibrarySampleUniversal.a,libXMBindingLibrarySampleUniversal.a

clean:
	-rm -f *.a *.dll
