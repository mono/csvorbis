all: unix

windows:
	$(CSC) /out:../bin/csogg.dll /target:library *.cs

unix:
	$(MCS) --target library -o ../bin/csogg.dll *.cs

clean:
	rm -f ../bin/csogg.dll

