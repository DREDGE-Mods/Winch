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
using Winch.Config;
using CommandTerminal;
using Sirenix.Utilities;
using Google.Protobuf;

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
    /// Compilation results of programs from dialogue-providing mods.
    /// </summary>
    internal static Dictionary<string, CompilationResult> programCompilationResults = new();

    /// <summary>
    /// Programs from dialogue-providing mods.
    /// </summary>
    internal static Dictionary<string, Program> programs = new();

    /// <summary>
    /// Fix yarn files to use spaces instead of tabs
    /// </summary>
    private static void FixDialogueFiles(string[] yarnFiles)
    {
        foreach (var yarnFile in yarnFiles)
        {
            File.WriteAllText(yarnFile, File.ReadAllText(yarnFile).Replace("\t", "    "));
        }
    }

    internal static void LoadDialogueFiles(string dialogueFolderPath)
    {
        string[] yarnFiles = Directory.GetFiles(dialogueFolderPath).Where(f => f.EndsWith(".yarn")).ToArray();

        FixDialogueFiles(yarnFiles);

        CompilationResult compilationResult = CompileProgram(yarnFiles);
        programCompilationResults.Add(dialogueFolderPath, compilationResult);
        var program = compilationResult.Program;
        if (program != null)
            programs.Add(dialogueFolderPath, program);

        foreach (var diagnotic in compilationResult.Diagnostics)
            WinchCore.Log.Error(diagnotic.FileName + "\n" + diagnotic.ToString());

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

    /// <summary>
    /// Register line metadata to insert later
    /// </summary>
    /// <param name="line">The line to add the metadata to.</param>
    /// <param name="metadata">The metadata that will be added to the line.</param>
    public static void AddLineMetadata(string line, params string[] metadata)
    {
        DialogueUtil.metadata.Add(line, metadata);
    }

    /// <summary>
    /// Manually set the line metadata
    /// </summary>
    /// <param name="line">The line to add the metadata to.</param>
    /// <param name="metadata">The metadata that will be added to the line.</param>
    internal static void SetLineMetadata(string line, params string[] metadata)
    {
        var _lineMetadata = Traverse.Create(GameManager.Instance.DialogueRunner.yarnProject.lineMetadata).Field("_lineMetadata").GetValue<SerializedDictionary<string, string>>();
        var metadataValue = string.Join(" ", metadata);
        if (!string.IsNullOrWhiteSpace(metadataValue))
            _lineMetadata[line] = metadataValue;
        else
            _lineMetadata.Remove(line);
    }

    internal static void InsertInstruction(DredgeInstruction dredgeInstruction)
    {
        Yarn.Instruction instruction = new Instruction();
        instruction.Opcode = dredgeInstruction.OpCode;

        foreach (var operand in dredgeInstruction.Operands)
        {
            if (operand is string stringOperand)
            {
                instruction.Operands.Add(new Operand(stringOperand));
            }
            else if (operand is bool boolOperand)
            {
                instruction.Operands.Add(new Operand(boolOperand));
            }
            else if (operand is float || operand is int)
            {
                instruction.Operands.Add(new Operand(Convert.ToSingle(operand)));
            }
        }

        DredgeDialogueRunner runner = GameManager.Instance.DialogueRunner;
        Program program = Traverse.Create(runner.Dialogue).Field("program").GetValue<Program>();
        if (program.Nodes.TryGetValue(dredgeInstruction.NodeID, out Node node))
        {
            int index = dredgeInstruction.Index;

            if (index != -1)
                node.Instructions.Insert(index, instruction);
            else
            {
                index = node.Instructions.Count;
                node.Instructions.Add(instruction);
            }

            foreach (var label in node.Labels)
            {
                if (label.Value >= index)
                {
                    node.Labels[label.Key] += 1;
                }
            }

            if (!string.IsNullOrWhiteSpace(dredgeInstruction.Label)) node.Labels[dredgeInstruction.Label] = index;
        }
        else
            WinchCore.Log.Error($"Failed to insert instruction into missing node \"{dredgeInstruction.NodeID}\"");
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
        try
        {
            var exportYarnProgram = WinchConfig.GetProperty("ExportYarnProgram", false);

            DredgeDialogueRunner runner = GameManager.Instance.DialogueRunner;
            DredgeLocalizedLineProvider? lineProvider = runner.lineProvider as DredgeLocalizedLineProvider;

            if (lineProvider == null)
            {
                WinchCore.Log.Error("Localized line provider is null");
                return;
            } 

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
            var _lineMetadata = Traverse.Create(runner.yarnProject.lineMetadata).Field("_lineMetadata").GetValue<SerializedDictionary<string, string>>();

            newProgram.Name = oldProgram.Name;

            if (exportYarnProgram)
            {
                WriteYarnProgramToText("YarnProgramVanilla", oldProgram, _lineMetadata);
            }

            foreach (var nodeName in oldProgram.Nodes)
            {
                newProgram.Nodes[nodeName.Key] = nodeName.Value.Clone();
            }
            newProgram.InitialValues.Add(oldProgram.InitialValues);

            foreach (var modProgram in programs.Values)
            {
                foreach (var nodeName in modProgram.Nodes)
                {
                    newProgram.Nodes[nodeName.Key] = nodeName.Value.Clone();
                }
                foreach (var initialValue in modProgram.InitialValues)
                {
                    newProgram.InitialValues[initialValue.Key] = initialValue.Value.Clone();
                }
            }

            runner.Dialogue.SetProgram(newProgram);

            foreach (var metadataEntry in metadata)
            {
                var metadataValue = string.Join(" ", metadataEntry.Value);
                if (!string.IsNullOrWhiteSpace(metadataValue))
                    _lineMetadata.SafeAdd(metadataEntry.Key, metadataValue);
            }
            
            foreach (var instruction in instructions)
            {
                InsertInstruction(instruction);
            }

            if (exportYarnProgram)
            {
                WriteYarnProgramToText("YarnProgramModded", newProgram, _lineMetadata);
            }
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error(ex);
        }
    }

    internal class LinesCSVRecord
    {
        public string Character { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
    }

    public class DredgeInstruction
    {
        public string NodeID { get; set; } = string.Empty;
        public int Index { get; set; }
        public string Label { get; set; } = string.Empty;
        public Yarn.Instruction.Types.OpCode OpCode { get; set; }
        public object[] Operands { get; set; } = new object[0];

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

    public class DredgeOption(Line line, string destination, bool enabled)
    {
        public Line Line { get; set; } = line;
        public string Destination { get; set; } = destination;
        public bool Enabled { get; set; } = enabled;

        public DredgeOption(Line line, string destination) : this(line, destination, true)
        {

        }

        public DredgeOption(string lineID, string destination, bool enabled) : this(new Line { ID = lineID, Substitutions = new string[0] }, destination, enabled)
        {

        }

        public DredgeOption(string lineID, string destination) : this(lineID, destination, true)
        {

        }

        public static implicit operator ValueTuple<Line, string, bool>(DredgeOption option)
            => (option.Line, option.Destination, option.Enabled);
    }

    internal static string GetProgramFileLocation(string fileName) => Path.Combine(WinchCore.WinchInstallLocation, $"{fileName}.txt");

    internal static void WriteYarnProgramToText(string fileName, Program program, SerializedDictionary<string, string> lineMetadata)
    {
        var path = GetProgramFileLocation(fileName);
        File.WriteAllText(path, YarnProgramToText(program, lineMetadata));
        WinchCore.Log.Debug("Yarn program written to " + path);
    }

    internal static string YarnProgramToText(Program program, SerializedDictionary<string, string> lineMetadata)
    {
        var stringified = $"Program {program.Name}:";
        foreach (var nodePair in program.Nodes)
        {
            var node = nodePair.Value;
            stringified += $"\n\n  Node {nodePair.Key} {node.SourceTextStringID}:\n\n{InstructionsToText(node, lineMetadata)}";
        }
        return stringified;
    }

    internal static string InstructionsToText(this Yarn.Node node, SerializedDictionary<string, string> lineMetadata)
    {
        return string.Join("\n", node.Instructions.Select((instruction, i) =>
        {
            var operands = string.Join(" ", instruction.Operands.Select(operand => OperandToText(operand)));
            var labels = node.Labels.Where(label => label.Value == i).Select(label => label.Key);
            var stringifiedLabels = labels.Count() > 0 ? $" [{string.Join(", ", labels)}]" : string.Empty;
            var metadata = (instruction.Opcode == Instruction.Types.OpCode.RunLine || instruction.Opcode == Instruction.Types.OpCode.AddOption) ? (" (" + lineMetadata.GetValueOrDefault(instruction.Operands.FirstOrDefault().StringValue) + ")") : string.Empty;
            return $"   {i} {instruction.Opcode} {operands}{stringifiedLabels}{metadata}";
        }));
    }

    internal static string OperandToText(this Yarn.Operand operand)
    {
        switch (operand.ValueCase)
        {
            case Operand.ValueOneofCase.StringValue:
                return $"{{\"stringValue\": \"{operand.StringValue}\"}}";
            case Operand.ValueOneofCase.BoolValue:
                return $"{{\"boolValue\": {operand.BoolValue}}}";
            case Operand.ValueOneofCase.FloatValue:
                return $"{{\"floatValue\": {operand.FloatValue}}}";
            case Operand.ValueOneofCase.None:
            default:
                return string.Empty;
        }
    }

    internal static void WriteYarnProgramCommand(CommandArg[] args)
    {
        DredgeDialogueRunner runner = GameManager.Instance.DialogueRunner;
        Program program = Traverse.Create(runner.Dialogue).Field("program").GetValue<Program>();
        var _lineMetadata = Traverse.Create(runner.yarnProject.lineMetadata).Field("_lineMetadata").GetValue<SerializedDictionary<string, string>>();
        WriteYarnProgramToText("YarnProgram", program, _lineMetadata);
        Terminal.Buffer.HandleLog("Yarn program written to " + GetProgramFileLocation("YarnProgram"), TerminalLogType.Message);
    }
}