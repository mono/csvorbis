all: unix

windows:
	$(CSC) /out:../bin/OggDecoder.exe /r:../bin/csogg.dll /r:../bin/csvorbis.dll *.cs

unix:
	$(MCS) -L ../bin/ -r csvorbis -r csogg -o ../bin/OggDecoder.exe *.cs

clean:
	rm -f ../bin/OggDecoder.exe
