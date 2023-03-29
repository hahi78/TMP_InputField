############################################################################
#	
############################################################################

ADB_EXE=/mnt/d/Unity/2021.3.16f1/Editor/Data/PlaybackEngines/AndroidPlayer/SDK/platform-tools/adb.exe

# デバイス
P30LITE=STP0220109001292

APK_FILE=./output/InputFieldTest.apk

install:
	$(ADB_EXE) -s $(P30LITE) install $(APK_FILE)

dev:
	$(ADB_EXE) devices