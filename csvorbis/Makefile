all: unix

windows:
	$(CSC) /out:..\bin\csvorbis.dll /r:..\bin\csogg.dll /target:library *.cs

unix:
	$(MCS) --target library -L ../bin -r csogg -o ../bin/csvorbis.dll *.cs

clean:
	rm -f ../bin/csvorbis.dll
