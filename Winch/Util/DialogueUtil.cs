using HarmonyLib;
using System.Collections.Generic;
using Yarn.Unity;
using Yarn;
using CsvHelper;
using System.IO;
using Winch.Core;
using CsvHelper.Configuration;
using System;
using System.Linq;
using Yarn.Compiler;
using System.Globalization;
using System.Text;

namespace Winch.Util;

public static class DialogueUtil
{
    /// <summary>
    /// Unlocalized lines indexed by their IDs, loaded from mod .yarn files. Used as fallbacks. Loaded in LoadDialoguesFiles on startup.
    /// </summary>
    internal static Dictionary<string, string> lines = new();

    /// <summary>
    /// Localized lines indexed by their IDs, loaded from mod CSV files. Loaded in LoadLocalizedLines on startup
    /// </summary>
    internal static Dictionary<string, Dictionary<string, string>> localizedLines = new();

    /// <summary>
    /// Hashtags (e.g. #exit #aah) for loaded dialogue lines.
    /// </summary>
    internal static Dictionary<string, string[]> metadata = new();

    /// <summary>
    /// Instructions to insert into a node at a specified index and with operands.
    /// </summary>
    internal static List<DredgeInstruction> instructions = new();

    /// <summary>
    /// Programs from dialogue-providing mods.
    /// </summary>
    internal static List<Program> programs = new();

    internal static void LoadDialogueFiles(string dialogueFolderPath)
    {
        string[] yarnFiles = Directory.GetFiles(dialogueFolderPath).Where(f => f.EndsWith(".yarn")).ToArray();

        CompilationResult compilationResult = CompileProgram(yarnFiles);
        programs.Add(compilationResult.Program);

        // Load "fallback" lines from the Yarn program's string table.
        foreach (var stringEntry in compilationResult.StringTable)
        {
            lines[stringEntry.Key] = stringEntry.Value.text;

            metadata[stringEntry.Key] = stringEntry.Value.metadata.Where(x => !x.StartsWith("line:")).ToArray();
        }
    }

    /// <summary>
    /// Compiles a program.
    /// </summary>
    /// <param name="inputs">List of paths to the source files.</param>
    /// <returns>A compiled <see cref="Yarn.Program" /> and other metadata.</returns>
    private static CompilationResult CompileProgram(string[] inputs)
    {
        // The majority of this method is lifted from https://github.com/YarnSpinnerTool/YarnSpinner-Console, which is licensed MIT.
        var compilationJob = CompilationJob.CreateFromFiles(inputs);

        // Declare the existence of 'visited' and 'visited_count'
        var visitedDecl = new DeclarationBuilder()
            .WithName("visited")
            .WithType(
                new FunctionTypeBuilder()
                    .WithParameter(Yarn.BuiltinTypes.String)
                    .WithReturnType(Yarn.BuiltinTypes.Boolean)
                    .FunctionType)
            .Declaration;

        var visitedCountDecl = new DeclarationBuilder()
            .WithName("visited_count")
            .WithType(
                new FunctionTypeBuilder()
                    .WithParameter(Yarn.BuiltinTypes.String)
                    .WithReturnType(Yarn.BuiltinTypes.Number)
                    .FunctionType)
            .Declaration;

        compilationJob.VariableDeclarations = (compilationJob.VariableDeclarations ?? Array.Empty<Declaration>()).Concat(new[] {
                visitedDecl,
                visitedCountDecl,
            });

        CompilationResult compilationResult;

        compilationResult = Compiler.Compile(compilationJob); // Exceptions will bubble through

        return compilationResult;
    }

    /// <summary>
    /// Inserts an instruction into a node at a specified index and with operands.
    /// </summary>
    /// <param name="nodeID">The ID of the node.</param>
    /// <param name="index">The index to insert the instruction at.</param>
    /// <param name="opCode">The opcode to insert. See <see href="https://github.com/YarnSpinnerTool/YarnSpinner/blob/main/YarnSpinner/yarn_spinner.proto"/> for a list of opcodes.</param>
    /// <param name="operands">Supported types: <see cref="string"/>, <see cref="bool"/>, <see cref="float"/>, <see cref="int"/></param>
    public static void AddInstruction(string nodeID, int index, Yarn.Instruction.Types.OpCode opCode, params object[] operands)
    {
        AddInstruction(new DredgeInstruction(nodeID, index, opCode, operands));
    }

    /// <summary>
    /// Inserts an instruction into a node at a specified index and with a label/operands.
    /// </summary>
    /// <param name="nodeID">The ID of the node.</param>
    /// <param name="index">The index to insert the instruction at.</param>
    /// <param name="label">The label ID of this instruction.</param>
    /// <param name="opCode">The opcode to insert. See <see href="https://github.com/YarnSpinnerTool/YarnSpinner/blob/main/YarnSpinner/yarn_spinner.proto"/> for a list of opcodes.</param>
    /// <param name="operands">Supported types: <see cref="string"/>, <see cref="bool"/>, <see cref="float"/>, <see cref="int"/></param>
    public static void AddInstruction(string nodeID, int index, string label, Yarn.Instruction.Types.OpCode opCode, params object[] operands)
    {
        AddInstruction(new DredgeInstruction(nodeID, index, label, opCode, operands));
    }

    /// <summary>
    /// Register an instruction to insert later
    /// </summary>
    /// <param name="instruction">The instruction to insert.</param>
    public static void AddInstruction(DredgeInstruction instruction)
    {
        instructions.Add(instruction);
    }

    /// <summary>
    /// Register instructions to insert later
    /// </summary>
    /// <param name="instructions">The instructions to insert.</param>
    public static void AddInstructions(params DredgeInstruction[] instructions)
    {
        DialogueUtil.instructions.AddRange(instructions);
    }

    internal static void InsertInstruction(DredgeInstruction dredgeInstruction)
    {
        Yarn.Instruction instruction = new Instruction();
        instruction.Opcode = dredgeInstruction.OpCode;

        foreach (var operand in dredgeInstruction.Operands)
        {
            if (operand is string)
            {
                instruction.Operands.Add(new Operand((string)operand));
            }
            else if (operand is bool)
            {
                instruction.Operands.Add(new Operand((bool)operand));
            }
            else if (operand is float || operand is int)
            {
                instruction.Operands.Add(new Operand(Convert.ToSingle(operand)));
            }
        }

        DredgeDialogueRunner runner = GameManager.Instance.DialogueRunner;
        Program program = Traverse.Create(runner.Dialogue).Field("program").GetValue<Program>();
        Node node = program.Nodes[dredgeInstruction.NodeID];

        node.Instructions.Insert(dredgeInstruction.Index, instruction);

        foreach (var label in node.Labels)
        {
            if (label.Value >= dredgeInstruction.Index)
            {
                node.Labels[label.Key] += 1;
            }
        }

        if (!string.IsNullOrWhiteSpace(dredgeInstruction.Label)) node.Labels[dredgeInstruction.Label] = dredgeInstruction.Index;
    }

    private static Dictionary<string, string> GetLinesForLocale(string localeId)
    {
        if (localizedLines.ContainsKey(localeId))
            return localizedLines[localeId];
        else
        {
            var lines = new Dictionary<string, string>();
            localizedLines.Add(localeId, lines);
            return lines;
        }
    }

    /// <summary>
    /// Loads localized lines from CSV files at path.
    /// </summary>
    internal static void LoadLocalizedLines(string dialogueFolderPath)
    {
        string[] csvFiles = Directory.GetFiles(dialogueFolderPath).Where(f => f.EndsWith(".csv")).ToArray();

        foreach (var linesPath in csvFiles)
        {
            // Language code (i.e. "en", "es", "pt-BR") from game settings.
            string localeId = Path.GetFileNameWithoutExtension(linesPath);
            var localizedLines = GetLinesForLocale(localeId);

            var config = new Configuration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = (header, index) => header.ToLowerInvariant(),
            };

            using (var reader = new StreamReader(linesPath, Encoding.UTF8))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<LinesCSVRecord>();

                foreach (var record in records)
                {
                    if (record.Id.Length == 0) continue;

                    localizedLines[record.Id] = record.Character.Length > 0 ? $"{record.Character}: {record.Text}" : record.Text;
                }
            }
        }
    }

    /// <summary>
    /// Inject all loaded dialogue lines into the game.
    /// </summary>
    /// <remarks>
    /// Only call this after GameManager has been instantiated.
    /// </remarks>
    internal static void Inject()
    {
        DredgeDialogueRunner runner = GameManager.Instance.DialogueRunner;
        DredgeLocalizedLineProvider lineProvider = runner.lineProvider as DredgeLocalizedLineProvider;

        foreach (var line in lines)
        {
            lineProvider.stringTable.AddEntry(line.Key, line.Value);
        }

        // Override localized lines.
        foreach (var localizedLine in GetLinesForLocale(GameManager.Instance.SettingsSaveData.localeId))
        {
            lineProvider.stringTable.AddEntry(localizedLine.Key, localizedLine.Value);
        }

        var newProgram = new Program();

        Program oldProgram = Traverse.Create(runner.Dialogue).Field("program").GetValue<Program>();
        foreach (var nodeName in oldProgram.Nodes)
        {
            newProgram.Nodes[nodeName.Key] = nodeName.Value.Clone();
        }
        newProgram.InitialValues.Add(oldProgram.InitialValues);

        foreach (var modProgram in programs)
        {
            foreach (var nodeName in modProgram.Nodes)
            {
                newProgram.Nodes[nodeName.Key] = nodeName.Value.Clone();
            }
            newProgram.InitialValues.Add(modProgram.InitialValues);
        }

        runner.Dialogue.SetProgram(newProgram);

        var _lineMetadata = Traverse.Create(runner.yarnProject.lineMetadata).Field("_lineMetadata").GetValue<SerializedDictionary<string, string>>();

        foreach (var metadataEntry in metadata)
        {
            _lineMetadata.Add(metadataEntry.Key, string.Join(" ", metadataEntry.Value));
        }

        foreach (var instruction in instructions)
        {
            InsertInstruction(instruction);
        }
    }

    internal class LinesCSVRecord
    {
        public string Character { get; set; }
        public string Text { get; set; }
        public string Id { get; set; }
    }

    public class DredgeInstruction
    {
        public string NodeID { get; set; }
        public int Index { get; set; }
        public string Label { get; set; } = string.Empty;
        public Yarn.Instruction.Types.OpCode OpCode { get; set; }
        public object[] Operands { get; set; }

        /// <summary>
        /// Create an instruction
        /// </summary>
        /// <param name="nodeID">The ID of the node.</param>
        /// <param name="index">The index to insert the instruction at.</param>
        /// <param name="opCode">The opcode to insert. See <see href="https://github.com/YarnSpinnerTool/YarnSpinner/blob/main/YarnSpinner/yarn_spinner.proto"/> for a list of opcodes.</param>
        /// <param name="operands">Supported types: <see cref="string"/>, <see cref="bool"/>, <see cref="float"/>, <see cref="int"/></param>
        public DredgeInstruction(string nodeID, int index, Yarn.Instruction.Types.OpCode opCode, params object[] operands)
        {
            NodeID = nodeID;
            Index = index;
            OpCode = opCode;
            Operands = operands;
        }

        /// <summary>
        /// Create an instruction with a label
        /// </summary>
        /// <param name="nodeID">The ID of the node.</param>
        /// <param name="index">The index to insert the instruction at.</param>
        /// <param name="label">The label ID of this instruction.</param>
        /// <param name="opCode">The opcode to insert. See <see href="https://github.com/YarnSpinnerTool/YarnSpinner/blob/main/YarnSpinner/yarn_spinner.proto"/> for a list of opcodes.</param>
        /// <param name="operands">Supported types: <see cref="string"/>, <see cref="bool"/>, <see cref="float"/>, <see cref="int"/></param>
        public DredgeInstruction(string nodeID, int index, string label, Yarn.Instruction.Types.OpCode opCode, params object[] operands)
        {
            NodeID = nodeID;
            Index = index;
            Label = label;
            OpCode = opCode;
            Operands = operands;
        }
    }
}