using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using IIS.SLSharp.Core.Expressions;
using Mono.Reflection;

namespace IIS.SLSharp.Core.Reflection
{
    public sealed class Decompiler
    {
        private class LabelInformation
        {
            private readonly List<Tuple<int, Instruction>> _crossRefs = new List<Tuple<int, Instruction>>();

            public LabelTarget Label { get; private set; }

            public List<Tuple<int, Instruction>> CrossRefs
            {
                get { return _crossRefs; }
            }

            public LabelInformation(LabelTarget target)
            {
                Label = target;
            }
        }

        private delegate void InstructionHandler(Instruction inst);

        private readonly Dictionary<OpCode, InstructionHandler> _handlers = new Dictionary<OpCode, InstructionHandler>();

        private readonly List<Expression> _stack = new List<Expression>();

        private readonly List<Expression> _statements = new List<Expression>();

        private readonly Dictionary<int, ParameterExpression> _locs = new Dictionary<int, ParameterExpression>();

        private readonly Expression[] _args;

        private readonly Expression _block;

        private readonly bool _hasThis;

        private readonly int _labelsEmmited;

        private readonly Dictionary<int, LabelInformation> _labels = new Dictionary<int, LabelInformation>();

        public static Expression DecompileMethod(MethodInfo m)
        {
            var d = new Decompiler(m);
            return d._block;
        }

        private void WidenTypes(ref Expression lhs, ref Expression rhs)
        {
            if (TryWiden(ref lhs, ref rhs) || TryWiden(ref rhs, ref lhs))
                return;

            throw new NotImplementedException();
        }

        private static bool TryWiden(ref Expression lhs, ref Expression rhs)
        {
            if (lhs.Type == rhs.Type)
                return true;

            if (lhs.Type == typeof(bool) && rhs.Type == typeof(int))
            {
                lhs = Expression.Convert(lhs, typeof(int));
                return true;
            }

            return false;
        }

        private void SetupHandlers()
        {
            _handlers[OpCodes.Ldarg_0] = _ =>
            {
                Push(_args[0]);
            };

            _handlers[OpCodes.Ldarg_1] = _ =>
            {
                Push(_args[1]);
            };

            _handlers[OpCodes.Ldarg_2] = _ =>
            {
                Push(_args[2]);
            };

            _handlers[OpCodes.Ldarg_3] = _ =>
            {
                Push(_args[3]);
            };

            _handlers[OpCodes.Ldarg] = InstLdarg;

            _handlers[OpCodes.Ldarg_S] = InstLdarg;

            _handlers[OpCodes.Starg] = InstStarg;

            _handlers[OpCodes.Starg_S] = InstStarg;

            _handlers[OpCodes.Ldfld] = i =>
            {
                Push(Expression.Field(Pop(), (FieldInfo)i.Operand));
            };

            _handlers[OpCodes.Stfld] = i =>
            {
                var fld = (FieldInfo)i.Operand;
                var rhs = Pop();
                PushStatement(Expression.Assign(Expression.Field(Pop(), fld), rhs));
            };

            _handlers[OpCodes.Stsfld] = i =>
            {
                var fld = (FieldInfo)i.Operand;
                var rhs = Pop();
                PushStatement(Expression.Assign(Expression.Field(null, fld), rhs));
            };

            _handlers[OpCodes.Ldsfld] = i =>
            {
                Push(Expression.Field(null, (FieldInfo)i.Operand));
            };

            _handlers[OpCodes.Call] = InstCall;

            _handlers[OpCodes.Callvirt] = InstCall;

            _handlers[OpCodes.Conv_R4] = _ =>
            {
                Push(Expression.Convert(Pop(), typeof(float)));
            };

            _handlers[OpCodes.Conv_R8] = _ =>
            {
                Push(Expression.Convert(Pop(), typeof(double)));
            };

            _handlers[OpCodes.Conv_I4] = _ =>
            {
                Push(Expression.Convert(Pop(), typeof(int)));
            };

            _handlers[OpCodes.Conv_U4] = _ =>
            {
                Push(Expression.Convert(Pop(), typeof(uint)));
            };

            _handlers[OpCodes.Stloc_0] = _ =>
            {
                PushStatement(Expression.Assign(_locs[0], Pop()));
            };

            _handlers[OpCodes.Stloc_1] = _ =>
            {
                PushStatement(Expression.Assign(_locs[1], Pop()));
            };

            _handlers[OpCodes.Stloc_2] = _ =>
            {
                PushStatement(Expression.Assign(_locs[2], Pop()));
            };

            _handlers[OpCodes.Stloc_3] = _ =>
            {
                PushStatement(Expression.Assign(_locs[3], Pop()));
            };

            _handlers[OpCodes.Stloc] = InstStloc;

            _handlers[OpCodes.Stloc_S] = InstStloc;

            _handlers[OpCodes.Ldloc_0] = _ =>
            {
                Push(_locs[0]);
            };

            _handlers[OpCodes.Ldloc_1] = _ =>
            {
                Push(_locs[1]);
            };

            _handlers[OpCodes.Ldloc_2] = _ =>
            {
                Push(_locs[2]);
            };

            _handlers[OpCodes.Ldloc_3] = _ =>
            {
                Push(_locs[3]);
            };

            _handlers[OpCodes.Ldloc] = InstLdloc;

            _handlers[OpCodes.Ldloc_S] = InstLdloc;

            _handlers[OpCodes.Dup] = _ =>
            {
                Push(_stack.Last());
            };

            _handlers[OpCodes.Newobj] = i =>
            {
                var ctor = (ConstructorInfo)i.Operand;
                var args = ctor.GetParameters().Length;
                Push(Expression.New(ctor, Pop(args)));
            };

            _handlers[OpCodes.Ldc_R4] = InstLdc;

            _handlers[OpCodes.Ldc_R8] = InstLdc;

            _handlers[OpCodes.Ldc_I4] = InstLdc;

            _handlers[OpCodes.Ldc_I4_S] = InstLdc;

            _handlers[OpCodes.Ldc_I4_0] = _ =>
            {
                Push(Expression.Constant(0));
            };

            _handlers[OpCodes.Ldc_I4_1] = _ =>
            {
                Push(Expression.Constant(1));
            };

            _handlers[OpCodes.Ldc_I4_2] = _ =>
            {
                Push(Expression.Constant(2));
            };

            _handlers[OpCodes.Ldc_I4_3] = _ =>
            {
                Push(Expression.Constant(3));
            };

            _handlers[OpCodes.Ldc_I4_4] = _ =>
            {
                Push(Expression.Constant(4));
            };

            _handlers[OpCodes.Ldc_I4_5] = _ =>
            {
                Push(Expression.Constant(5));
            };

            _handlers[OpCodes.Ldc_I4_6] = _ =>
            {
                Push(Expression.Constant(6));
            };

            _handlers[OpCodes.Ldc_I4_7] = _ =>
            {
                Push(Expression.Constant(7));
            };

            _handlers[OpCodes.Ldc_I4_8] = _ =>
            {
                Push(Expression.Constant(8));
            };

            _handlers[OpCodes.Ldc_I4_M1] = _ =>
            {
                Push(Expression.Constant(-1));
            };

            _handlers[OpCodes.Add] = _ =>
            {
                var a = Pop();
                var b = Pop();
                Push(Expression.Add(b, a));
            };

            _handlers[OpCodes.Mul] = _ =>
            {
                var a = Pop();
                var b = Pop();
                Push(Expression.Multiply(b, a));
            };

            _handlers[OpCodes.Div] = InstDiv;

            _handlers[OpCodes.Div_Un] = InstDiv;

            _handlers[OpCodes.Sub] = _ =>
            {
                var a = Pop();
                var b = Pop();
                Push(Expression.Subtract(b, a));
            };

            _handlers[OpCodes.Rem] = InstRem;

            _handlers[OpCodes.Rem_Un] = InstRem;

            _handlers[OpCodes.Or] = _ =>
            {
                var a = Pop();
                var b = Pop();
                Push(Expression.Or(b, a));
            };

            _handlers[OpCodes.Xor] = _ =>
            {
                var a = Pop();
                var b = Pop();
                Push(Expression.ExclusiveOr(b, a));
            };

            _handlers[OpCodes.And] = _ =>
            {
                var a = Pop();
                var b = Pop();
                Push(Expression.And(b, a));
            };

            _handlers[OpCodes.Shl] = _ =>
            {
                var a = Pop();
                var b = Pop();
                Push(Expression.LeftShift(b, a));
            };

            _handlers[OpCodes.Shr] = InstShr;

            _handlers[OpCodes.Shr_Un] = InstShr;

            _handlers[OpCodes.Neg] = _ =>
            {
                Push(Expression.Negate(Pop()));
            };

            _handlers[OpCodes.Not] = _ =>
            {
                Push(Expression.OnesComplement(Pop()));
            };

            _handlers[OpCodes.Starg_S] = i =>
            {
                var arg = (ParameterInfo)i.Operand;
                var pos = arg.Position;
                if (_hasThis)
                    pos++;

                PushStatement(Expression.Assign(_args[pos], Pop()));
            };

            _handlers[OpCodes.Br] = InstBr;

            _handlers[OpCodes.Br_S] = InstBr;

            _handlers[OpCodes.Blt] = InstBlt;

            _handlers[OpCodes.Blt_Un] = InstBlt;

            _handlers[OpCodes.Blt_S] = InstBlt;

            _handlers[OpCodes.Blt_Un_S] = InstBlt;

            _handlers[OpCodes.Bgt] = InstBgt;

            _handlers[OpCodes.Bgt_Un] = InstBgt;

            _handlers[OpCodes.Bgt_S] = InstBgt;

            _handlers[OpCodes.Bgt_Un_S] = InstBgt;

            _handlers[OpCodes.Ble] = InstBle;

            _handlers[OpCodes.Ble_Un] = InstBle;

            _handlers[OpCodes.Ble_S] = InstBle;

            _handlers[OpCodes.Ble_Un_S] = InstBle;

            _handlers[OpCodes.Brtrue] = InstBrtrue;

            _handlers[OpCodes.Brtrue_S] = InstBrtrue;

            _handlers[OpCodes.Ldelem_Ref] = i =>
            {
                var index = Pop();
                var array = Pop();
                Push(Expression.ArrayIndex(array, index));
            };

            _handlers[OpCodes.Clt] = InstClt;

            _handlers[OpCodes.Clt_Un] = InstClt;

            _handlers[OpCodes.Cgt] = InstCgt;

            _handlers[OpCodes.Cgt_Un] = InstCgt;

            _handlers[OpCodes.Ceq] = _ =>
            {
                var v1 = Pop();
                var v2 = Pop();
                WidenTypes(ref v1, ref v2);
                Push(Expression.Equal(v1, v2));
            };

            _handlers[OpCodes.Pop] = _ =>
            {
                Pop();
            };

            // opcodes that don't have any real meaning to us; we just ignore them
            AddNopOpCodes(OpCodes.Prefix1, OpCodes.Prefix2, OpCodes.Prefix3, OpCodes.Prefix4, OpCodes.Prefix5, OpCodes.Prefix6, OpCodes.Prefix7,
                OpCodes.Prefixref, OpCodes.Nop, OpCodes.Break, OpCodes.Ret, OpCodes.Tailcall, OpCodes.Volatile, OpCodes.Unaligned, OpCodes.Readonly,
                OpCodes.Initobj);

            // these are opcodes that we can't sensibly translate to GLSL

            // overflow-checked opcodes
            AddIllegalOpCodes(OpCodes.Add_Ovf, OpCodes.Add_Ovf_Un, OpCodes.Mul_Ovf, OpCodes.Mul_Ovf_Un, OpCodes.Sub_Ovf, OpCodes.Sub_Ovf_Un,
                OpCodes.Conv_Ovf_I, OpCodes.Conv_Ovf_I_Un, OpCodes.Conv_Ovf_I1, OpCodes.Conv_Ovf_I1_Un, OpCodes.Conv_Ovf_I2, OpCodes.Conv_Ovf_I2_Un,
                OpCodes.Conv_Ovf_I4, OpCodes.Conv_Ovf_I4_Un, OpCodes.Conv_Ovf_U, OpCodes.Conv_Ovf_U_Un, OpCodes.Conv_Ovf_U1, OpCodes.Conv_Ovf_U1_Un,
                OpCodes.Conv_Ovf_U2, OpCodes.Conv_Ovf_U2_Un, OpCodes.Conv_Ovf_U4, OpCodes.Conv_Ovf_U4_Un, OpCodes.Ckfinite);

            // 64-bit integer opcodes
            AddIllegalOpCodes(OpCodes.Ldc_I8, OpCodes.Ldelem_I8, OpCodes.Ldind_I8, OpCodes.Stelem_I8, OpCodes.Stind_I8, OpCodes.Conv_U8,
                OpCodes.Conv_Ovf_I8, OpCodes.Conv_Ovf_I8_Un, OpCodes.Conv_Ovf_U8, OpCodes.Conv_Ovf_U8_Un, OpCodes.Ldind_I8, OpCodes.Conv_I8,
                OpCodes.Conv_U8);

            // unsupported conversions
            AddIllegalOpCodes(OpCodes.Conv_I1, OpCodes.Conv_I2, OpCodes.Conv_U1, OpCodes.Conv_U2);

            // address opcodes
            AddIllegalOpCodes(OpCodes.Ldind_I1, OpCodes.Ldind_I2, OpCodes.Ldind_I4, OpCodes.Ldind_U1, OpCodes.Ldind_U2, OpCodes.Ldind_U4);

            // typed references (see C#'s __arglist, __makeref, __reftype, __refvalue (undocumenteded keywords in MS C#))
            AddIllegalOpCodes(OpCodes.Arglist, OpCodes.Mkrefany, OpCodes.Refanytype, OpCodes.Refanyval);

            // exception handling
            AddIllegalOpCodes(OpCodes.Leave, OpCodes.Leave_S, OpCodes.Endfilter, OpCodes.Endfinally, OpCodes.Throw, OpCodes.Rethrow);

            // reflection and types
            AddIllegalOpCodes(OpCodes.Isinst, OpCodes.Castclass, OpCodes.Ldtoken, OpCodes.Box, OpCodes.Unbox, OpCodes.Unbox_Any, OpCodes.Sizeof,
                OpCodes.Constrained);

            // unmanaged/native operations
            AddIllegalOpCodes(OpCodes.Initblk, OpCodes.Cpblk, OpCodes.Ldftn, OpCodes.Ldvirtftn, OpCodes.Ldind_I, OpCodes.Conv_I);

            // other unsupported opcodes
            AddIllegalOpCodes(OpCodes.Ldnull, OpCodes.Ldstr); // GLSL doesn't know null, nor strings

            // TODO: these are not actually restricted, but need further investigation for a proper implementation; if you
            // run into an exception with one of these, then please report it with some source code we can reproduce it with!
            AddToDoOpCodes(OpCodes.Calli);
        }

        private void AddNopOpCodes(params OpCode[] opCodes)
        {
            foreach (var opCode in opCodes)
                _handlers[opCode] = InstNop;
        }

        private void AddIllegalOpCodes(params OpCode[] opCodes)
        {
            foreach (var opCode in opCodes)
                _handlers[opCode] = null;
        }

        private void AddToDoOpCodes(params OpCode[] opCodes)
        {
            foreach (var opCode in opCodes)
            {
                _handlers[opCode] = i =>
                {
                    throw new NotSupportedException("Encountered TODO opcode " + i);
                };
            }
        }

        private void InstNop(Instruction inst)
        {
        }

        private void InstStarg(Instruction inst)
        {
            var top = Pop();
            var pos = (int)inst.Operand;
            if (_hasThis)
                pos++;

            _args[pos] = top;
        }

        private void InstLdarg(Instruction inst)
        {
            var arg = (ParameterInfo)inst.Operand;
            var pos = arg.Position;
            if (_hasThis)
                pos++;

            Push(_args[pos]);
        }

        private void InstBlt(Instruction inst)
        {
            var target = GetTarget(inst);
            var v2 = Pop();
            var v1 = Pop();
            var conditional = new DualLogicalExpression(
                Expression.LessThan(v1, v2),
                Expression.GreaterThanOrEqual(v1, v2));

            HandleConditionalBranch(inst, target, conditional);
        }

        private void InstBgt(Instruction inst)
        {
            var target = GetTarget(inst);
            var v2 = Pop();
            var v1 = Pop();
            var conditional = new DualLogicalExpression(
                Expression.GreaterThan(v1, v2),
                Expression.LessThanOrEqual(v1, v2));

            HandleConditionalBranch(inst, target, conditional);
        }

        private void InstBle(Instruction inst)
        {
            var target = GetTarget(inst);
            var v2 = Pop();
            var v1 = Pop();
            var conditional = new DualLogicalExpression(
                Expression.LessThanOrEqual(v1, v2),
                Expression.GreaterThan(v1, v2));

            HandleConditionalBranch(inst, target, conditional);
        }

        private void InstBrtrue(Instruction inst)
        {
            var target = GetTarget(inst);
            var next = inst.Offset + inst.Size;
            var v1 = Pop();
            if (target == next)
                return;

            var conditional = new DualLogicalExpression(Expression.Not(v1), v1);
            HandleConditionalBranch(inst, target, conditional);
        }

        private void InstBr(Instruction inst)
        {
            var target = GetTarget(inst);
            var next = inst.Offset + inst.Size;
            if (target != next)
                PushStatement(Expression.Goto(_labels[target].Label));
        }

        private void InstCall(Instruction inst)
        {
            var m = (MethodInfo)inst.Operand;
            var args = m.GetParameters().Length;

            if (HasThis(m))
            {
                var a = Pop(args);
                Push(Expression.Call(Pop(), m, a));
            }
            else
                Push(Expression.Call(m, Pop(args)));
        }

        private void InstRem(Instruction inst)
        {
            var a = Pop();
            var b = Pop();
            Push(Expression.Modulo(b, a));
        }

        private void InstShr(Instruction inst)
        {
            var a = Pop();
            var b = Pop();
            Push(Expression.RightShift(b, a));
        }

        private void InstDiv(Instruction inst)
        {
            var a = Pop();
            var b = Pop();
            Push(Expression.Divide(b, a));
        }

        private void InstLdc(Instruction inst)
        {
            Push(Expression.Constant(inst.Operand));
        }

        private void InstClt(Instruction inst)
        {
            var v1 = Pop();
            var v2 = Pop();
            Push(Expression.LessThan(v1, v2));
        }

        private void InstCgt(Instruction inst)
        {
            var v1 = Pop();
            var v2 = Pop();
            Push(Expression.GreaterThan(v1, v2));
        }

        private void InstStloc(Instruction inst)
        {
            var lv = (LocalVariableInfo)inst.Operand;
            PushStatement(Expression.Assign(_locs[lv.LocalIndex], Pop()));
        }

        private void InstLdloc(Instruction inst)
        {
            var lv = (LocalVariableInfo)inst.Operand;
            Push(_locs[lv.LocalIndex]);
        }

        private Decompiler(MethodInfo m)
        {
            SetupHandlers();

            var l = m.GetParameters().Select(p => Expression.Parameter(p.ParameterType, p.Name)).ToList();
            _hasThis = HasThis(m);
            if (_hasThis)
                l.Insert(0, Expression.Parameter(m.DeclaringType, "this")); // this

            _args = l.ToArray();

            var body = m.GetMethodBody();
            if (body == null)
                throw new Exception("Method body is null"); // TODO: will this ever happen?

            foreach (var v in body.LocalVariables)
                _locs[v.LocalIndex] = Expression.Variable(v.LocalType, "_l" + v.LocalIndex);

            var instructions = m.GetInstructions();
            try
            {
                CollectBranches(instructions);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't process:");
                foreach (var iinner in m.GetInstructions())
                    Console.WriteLine("{2}: \t{0} {1}", iinner, iinner.Operand, iinner.Offset);

                Console.WriteLine(e.Message);
            }

            foreach (var inst in instructions)
            {
                try
                {
                    LabelInformation label;
                    if (_labels.TryGetValue(inst.Offset, out label))
                    {
                        HandleTarget(label);
                        _labelsEmmited++;
                    }

                    InstructionHandler handler;
                    if (_handlers.TryGetValue(inst.OpCode, out handler))
                    {
                        if (handler == null)
                            throw new NotSupportedException("Encountered illegal opcode " + inst);

                        handler(inst);
                    }
                    else
                        throw new NotImplementedException("Encountered unimplemented opcode " + inst);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Can't process:");
                    foreach (var iinner in m.GetInstructions())
                        Console.WriteLine("{2}: \t{0} {1}", iinner, iinner.Operand, iinner.Offset);

                    Console.WriteLine(e.Message);
                    Console.WriteLine("Failed at {2}: \t{0} {1}", inst, inst.Operand, inst.Offset);
                    throw;
                }
            }

            switch (_stack.Count)
            {
                case 0:
                    break;
                case 1:
                    PushStatement(Pop());
                    //PushStatement(Expression.Return(Expression.Label("ret"), Pop()));
                    //PushStatement(Expression.Default(m.ReturnType));
                    break;
                default:
                    Console.WriteLine("Stack mismatch in:");
                    foreach (var iinner in m.GetInstructions())
                        Console.WriteLine("{2}: {0} {1}", iinner, iinner.Operand, iinner.Offset);

                    throw new NotImplementedException();
            }

            if (_labelsEmmited != _labels.Count)
                throw new Exception("Failed to place all labels");

            var reduced = LoopReducer.Reduce(_statements, _locs);
            if (reduced.Count() == 0)
                reduced = new[] { Expression.Block(m.ReturnType, _locs.Values, Expression.Default(m.ReturnType)) };

            _block = Expression.Block(m.ReturnType, _locs.Values, reduced.ToArray());
        }

        private static int GetTarget(Instruction inst)
        {
            return ((Instruction)inst.Operand).Offset;
        }

        private void CollectBranches(IEnumerable<Instruction> instructions)
        {
            var handlers = new Dictionary<OpCode, InstructionHandler>();

            handlers[OpCodes.Br] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Br_S] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Blt] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Blt_S] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Bgt] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Bgt_S] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Ble_Un] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Ble_Un_S] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Brtrue] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Brtrue_S] = i =>
            {
                AddTarget(i, GetTarget(i));
            };

            handlers[OpCodes.Call] = _ =>
            {
            };

            handlers[OpCodes.Callvirt] = _ =>
            {
            };

            handlers[OpCodes.Ret] = _ =>
            {
            };

            var ignore = new[] { FlowControl.Call, FlowControl.Return, FlowControl.Next };
            foreach (var inst in instructions.Where(inst => !ignore.Contains(inst.OpCode.FlowControl)))
                handlers[inst.OpCode](inst);
        }

        private void AddTarget(Instruction inst, int target)
        {
            var next = inst.Offset + inst.Size;
            if (target == next)
                return;

            _labels[target] = new LabelInformation(Expression.Label("L_" + _labels.Count));
        }

        private static bool HasThis(MethodBase m)
        {
            return !m.IsStatic;
        }

        private Expression Pop()
        {
            var e = _stack.Last();
            _stack.RemoveAt(_stack.Count - 1);
            return e;
        }

        private Expression[] Pop(int num)
        {
            var start = _stack.Count - num;
            var res = _stack.Skip(start).Take(num).ToArray();
            _stack.RemoveRange(start, num);
            return res;
        }

        private static Expression Reduce(Expression e)
        {
            //while (e.CanReduce)
            //    e = e.ReduceAndCheck();
            return e;
        }

        private void Push(Expression e)
        {
            e = Reduce(e);
            _stack.Add(e);
        }

        private void PushStatement(Expression e)
        {
            e = Reduce(e);
            _statements.Add(e);
        }

        private Expression PopStatement()
        {
            var e = _statements.Last();
            _statements.RemoveAt(_statements.Count - 1);
            return e;
        }

        private Expression[] PopStatement(int num)
        {
            var start = _statements.Count - num;
            var res = _statements.Skip(start).Take(num).ToArray();
            _statements.RemoveRange(start, num);
            return res;
        }

        private void HandleConditionalBranch(Instruction inst, int target, DualLogicalExpression conditional)
        {
            var next = inst.Offset + inst.Size;
            if (target == next)
                return;

            var label = _labels[target];

            if (target > inst.Offset)
            {
                // forward branch will be handled when reaching the target
                label.CrossRefs.Add(new Tuple<int, Instruction>(_statements.Count, inst));
                PushStatement(conditional); 
                return;
            }

            // add a backward jump as goto
            // the loopreducer will have to simplify this term
            PushStatement(
                Expression.IfThen(
                    conditional.Primary,
                    Expression.Goto(label.Label)));
        }

        private void HandleTarget(LabelInformation label)
        {
            switch (label.CrossRefs.Count)
            {
                case 1: // if then
                    // pop till reaching the last conditional statement
                    var xref = label.CrossRefs.First();
                    var count = _statements.Count - xref.Item1;
                    var block = PopStatement(count - 1);
                    var cond = (DualLogicalExpression)PopStatement();
                    
                    //var expr = block.Length > 1 ? Expression.Block(block) : block[0];
                    var expr = Expression.Block(block); // simpler to handle in visitor
                    PushStatement(Expression.IfThen(cond.Dual, expr));

                    return; // dont place label
                case 0:
                    break;
                default:
                    throw new NotImplementedException();
            }

            PushStatement(Expression.Label(label.Label));
        }
    }
}
