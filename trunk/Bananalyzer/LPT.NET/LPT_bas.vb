Option Strict Off
Option Explicit On
Module LPT_Declare
	
	'Inp and Out declarations for direct port I/O
	'in 32-bit Visual Basic 4+ programs.
	
	Public Declare Function Inp Lib "inpout32.dll"  Alias "Inp32"(ByVal PortAddress As Short) As Short
	Public Declare Sub Out Lib "inpout32.dll"  Alias "Out32"(ByVal PortAddress As Short, ByVal Value As Short)
End Module