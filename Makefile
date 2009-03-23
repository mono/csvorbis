DIRS=csogg csvorbis OggDecoder
CSC=csc
MCS=mcs
SMCS="smcs -d:NET_2_1"

all: unix

windows:
	-mkdir bin
	for i in $(DIRS); do				\
		(cd $$i; CSC=$(CSC) make windows) || exit 1;\
	done;

moon: 
	-mkdir bin
	for i in $(DIRS); do				\
		(cd $$i; MCS=$(SMCS) make) || exit 1;\
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
