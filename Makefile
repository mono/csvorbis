DIRS=csogg csvorbis OggDecoder
CSC=csc.exe
MCS=mcs

all: unix

windows:
	-mkdir bin
	for i in $(DIRS); do				\
		(cd $$i; CSC=$(CSC) make windows) || exit 1;\
	done;

unix: 
	-mkdir bin
	for i in $(DIRS); do				\
		(cd $$i; MCS=$(MCS) make) || exit 1;\
	done;

clean:
	for i in $(DIRS); do				\
		(cd $$i; make clean) || exit 1;	\
	done;
	-rm -rf bin
