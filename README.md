# DebuggingDemos
Demos for .NET Debugging Presentations

## Preparations
1. Install [DebugDiag](https://www.microsoft.com/en-us/download/details.aspx?id=49924)
2. Install [ProcDump](https://technet.microsoft.com/en-us/sysinternals/dd996900.aspx)
3. Install [WinDbg](https://msdn.microsoft.com/en-us/library/windows/hardware/ff551063(v=VS.85).aspx) 
4. Download and compile [Netling](https://github.com/hallatore/Netling) easy load tester 

### Capture demo dumps
1. Crash - Presidents demo - next on Obama
2. Crash - MyShop - Contact - Email=Test --- need to capture with a debug diag rule, dump on first chance stack overflow
3. Hang - MyShop - Products - Netling 8/10/1 (can take with taskmanager if you set up vdir in real IIS 64 bit)
4. Memory - MyShop - News - Netling 4/10/1 (take one baseline before and one leak after)

