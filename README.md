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
e1. Open crash 1 in WinDbg
2. Add commands to scratchpad
3. Walk through commands and explain what we can find in a memory dump

          ~* kb
          .loadby sos clr
          !clrstack
          !dso
          !do <exception>
          !objsize <exception>
          !click <message>
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

## Hang 1
1. Browse to Products (MyShop)
2. Netling 8/10/1 + task manager (check CPU)
3. Netling again - dump with task manager
(*) Windbg - show lots of same stacks
4. Debug Diag 
- show wait
- http context report
5. Visual studio (Mixed??)
- Parallel stacks

## Hang 2
1. Open presidents, show slowness on next
2. Analyze/Performance Profiler
- Performance wizard
- Instrumentation
3. Repro / Stop profiling
4. Summary - App.Run - move down path

## Memory 1
1. Browse news
2. dump for comparison
3. Netling 4/10/1 
4. Dump leak
5. Open in VS
- sort by size diff bytes
- newscontroller root down
6. Open in Debug Diag
- see cache

(*) open in Windbg and debug with !gcroot etc.

Slides at http://www.slideshare.net/TessFerrandez
