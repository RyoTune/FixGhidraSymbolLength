# FixGhidraSymbolLength

Fix Ghidra Error: `Unable to create symbol at X: Symbol name exceeds maximum length of 2000, length=Y`

Ran into the symbol length limit when trying to apply a UE5 PDB and it seemed to stall out the whole process.

This program simply truncates any name longer than the limit.

## Usage

1. In Ghidra, run the `CreatePdbXmlFilesScript` script and select your `.pdb` file. Only single-file is supported, but can probably be adjusted easily for multiple files.

2. Copy the generated `.pdb.xml` file into the same folder as the program.

3. Run the program to generate a fixed `.pdb.xml` with `_fixed` appended to the name.

4. In Ghidra, apply the fixed `.pdb.xml` the same way you would apply a normal `.pdb` with `File -> Load PDB File...`.
