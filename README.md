# DebuggingDemos
Demos for .NET Debugging Presentations

## Preparations
1. Install [DebugDiag](https://www.microsoft.com/en-us/download/details.aspx?id=49924)
2. Install [ProcDump](https://technet.microsoft.com/en-us/sysinternals/dd996900.aspx)
3. Install [WinDbg](https://msdn.microsoft.com/en-us/library/windows/hardware/ff551063(v=VS.85).aspx) 
4. Download and compile [Netling](https://github.com/hallatore/Netling) easy load tester 

Use magnifier with bar to manify command in windbg

### Capture demo dumps
1. Crash - Presidents demo - next on Obama
2. Crash - MyShop - Contact - Email=Test --- need to capture with a debug diag rule, dump on first chance stack overflow
3. Hang - MyShop - Products - Netling 8/10/1 (can take with taskmanager if you set up vdir in real IIS 64 bit)
4. Memory - MyShop - News - Netling 4/10/1 (take one baseline before and one leak after)

# Script

## Dump walkthrough
1. Open crash 1 in WinDbg
2. Add commands to scratchpad
3. Walk through commands and explain what we can find in a memory dump

~* kb
.loadby sos clr
!clrstack
!dso
!do <exception>
!objsize <exception>
click <message>
!gcroot <message>
lm
!eeheap -gc
!dumpheap -stat

## Crash 1
1. Repro crash in presidents - next on Obama
2. Procdump -ma ThePresidents.exe -e
3. in Windbg !clrstack and !dso
4. Open in Debug Diag
- exception on stack 0
- stack of T0
- previous exceptions
- discuss SOF/OOM/EE
5. Open in Visual Studio (managed)
6. Open event viewer

(*) debug diag rules 

