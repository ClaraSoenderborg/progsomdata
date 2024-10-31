	.method public hidebysig static 
		void SelectionSort (
			int32[] arr
		) cil managed 
	{
		// Method begins at RVA 0x20cc
		// Header size: 12
		// Code size: 78 (0x4e)
		.maxstack 4               
		.locals init (
			[0] int32,  // i 
			[1] int32,  // least 
			[2] int32,  // 
			[3] int32,  // j 
			[4] bool,   // if-bool 
			[5] bool,   // inner-loop-bool
			[6] bool    // outer-loop-bool
		)

		IL_0000: nop                    // No Operation 
		IL_0001: ldc.i4.0               // Push constant '0' onto stack (for initialization)
		IL_0002: stloc.0                // Set local variable 'i' to 0
		IL_0003: br.s IL_0041           // Jump to outer loop condition check
		// loop start (head: IL_0041)   // Outer loop starts
			IL_0005: nop                // No Operation 
			IL_0006: ldloc.0            // Load i
			IL_0007: stloc.1            // Store i in 'least'
			IL_0008: ldloc.0            // Load i 
			IL_0009: ldc.i4.1           // Push int 1 to stack
			IL_000a: add                // i + 1 
			IL_000b: stloc.3            // Store i+1 in 'j'
			IL_000c: br.s IL_0022              // Jump to inner loop condition check 
			// loop start (head: IL_0022)      // Inner loop starts 
				IL_000e: ldarg.0               // Load arr
				IL_000f: ldloc.3               // Load 'j'
				IL_0010: ldelem.i4             // Load arr[j] 
				IL_0011: ldarg.0               // Load arr 
				IL_0012: ldloc.1               // Load least
				IL_0013: ldelem.i4             // Load arr[least]
				IL_0014: clt                   // Compare arr[j] < arr[least]
				IL_0016: stloc.s 4             // Store on if-bool
				IL_0018: ldloc.s 4             // Load if-bool 
				IL_001a: brfalse.s IL_001e     // if 'if-bool' is not true then skip to IL_001e 

				IL_001c: ldloc.3               // Load 'j'
				IL_001d: stloc.1               // Store least = j

				IL_001e: ldloc.3               // Load 'j'
				IL_001f: ldc.i4.1              // Push 1 onto stack 
				IL_0020: add                   // 'j' + 1
				IL_0021: stloc.3               // Store 'j' = j + 1 

				IL_0022: ldloc.3               // Load 'j'
				IL_0023: ldarg.0               // Load arr 
				IL_0024: ldlen                 // arr.lenght 
				IL_0025: conv.i4               // convert arr.lenght to int
				IL_0026: clt                   // j < arr.lenght 
				IL_0028: stloc.s 5             // Store inner-loop = j < arr.lenght 
				IL_002a: ldloc.s 5             // Load inner-loop 
				IL_002c: brtrue.s IL_000e      // if inner-loop-bool is true then jump to start of innerloop 
			// end loop

			IL_002e: ldarg.0
			IL_002f: ldloc.0
			IL_0030: ldelem.i4
			IL_0031: stloc.2
			IL_0032: ldarg.0
			IL_0033: ldloc.0
			IL_0034: ldarg.0
			IL_0035: ldloc.1
			IL_0036: ldelem.i4
			IL_0037: stelem.i4
			IL_0038: ldarg.0
			IL_0039: ldloc.1
			IL_003a: ldloc.2
			IL_003b: stelem.i4
			IL_003c: nop
			IL_003d: ldloc.0
			IL_003e: ldc.i4.1
			IL_003f: add
			IL_0040: stloc.0

			IL_0041: ldloc.0
			IL_0042: ldarg.0
			IL_0043: ldlen
			IL_0044: conv.i4
			IL_0045: clt
			IL_0047: stloc.s 6
			IL_0049: ldloc.s 6
			IL_004b: brtrue.s IL_0005
		// end loop

		IL_004d: ret
	} // end of method Selsort::SelectionSort

