using System;
using System.Collections.Generic;

namespace ColorCalculator
{
    public class Equation
    {
        private readonly ETree _equation;

        public Equation(string equationString)
        {
            var splitEquation = SplitEquation(equationString);
            try
            {
                _equation = EParse(splitEquation);
            }
            catch (Exception)
            {
                throw new Exception("Unable to parse: " + equationString);
            }

        }

        public double Evaluate(Dictionary<char, double> variables)
        {
            return _equation.GetValue(variables);
        }

        private static IEnumerable<string> SplitEquation(string equation)
        {
            equation = equation.ToUpper().Replace(" ", string.Empty);
            var splitEquation = new List<string>();

            var number = "";
            foreach (var c in equation)
            {
                if (('0' <= c && '9' >= c) || c == '.')
                {
                    number += c;
                }
                else
                {
                    if (number != "")
                    {
                        splitEquation.Add(number);
                        number = "";
                    }
                    splitEquation.Add(c.ToString());
                }
            }
            if (number != "")
            {
                splitEquation.Add(number);
            }
            return splitEquation.ToArray();
        }

        private static ETree EParse(IEnumerable<string> equation)
        {
            var s = new Queue<string>(equation);
            var t = E(s);
            if (s.Count != 0) throw new Exception("Unable to parse equation");
            return t;
        }

        private static ETree E(Queue<string> s)
        {
            var t = T(s);
            while (s.Count > 0 && (s.Peek() == "+" || s.Peek() == "-"))
            {
                var op = EBinary.GetBinaryOpperator(s.Dequeue());
                var t1 = T(s);
                t = new EBinary(op, t, t1);
            }
            return t;
        }

        private static ETree T(Queue<string> s)
        {
            var t = F(s);
            while (s.Count > 0 && (s.Peek() == "*" || s.Peek() == "/" || s.Peek() == "%"))
            {
                var op = EBinary.GetBinaryOpperator(s.Dequeue());
                var t1 = F(s);
                t = new EBinary(op, t, t1);
            }
            return t;
        }

        private static ETree F(Queue<string> s)
        {
            var t = P(s);
            if (s.Count > 0 && s.Peek() == "^")
            {
                s.Dequeue();
                var t1 = F(s);
                return new EBinary(EBinary.GetBinaryOpperator("^"), t, t1);
            }
            return t;
        }

        private static ETree P(Queue<string> s)
        {
            ETree t;
            double v;
            if (double.TryParse(s.Peek(), out v))
            {
                s.Dequeue();
                t = new ELeaf(v);
                return t;
            }
            if (s.Peek()[0] >= 'A' && s.Peek()[0] <= 'Z')
            {
                t = new EVar(s.Dequeue()[0]);
                return t;
            }
            if (s.Peek() == "(")
            {
                s.Dequeue();
                t = E(s);
                if (s.Dequeue() != ")") throw new ArgumentException("parenthese issue");
                return t;
            }
            if (s.Peek() == "-")
            {
                s.Dequeue();
                t = F(s);
                return new EUnary(EUnary.GetUnaryOpperator("-"), t);
            }
            throw new ArgumentException();
        }

        private abstract class ETree
        {
            public abstract double GetValue(Dictionary<char, double> v);
        }

        private class ELeaf : ETree
        {
            private double Value { get; }

            public ELeaf(double value)
            {
                Value = value;
            }

            public override double GetValue(Dictionary<char, double> dictionary)
            {
                return Value;
            }
        }

        private class EVar : ETree
        {
            private char Value { get; }

            public EVar(char value)
            {
                Value = value;
            }

            public override double GetValue(Dictionary<char, double> dictionary)
            {
                if(dictionary.ContainsKey(Value))
                return dictionary[Value];
                throw new Exception("Could not find variable \"" + Value + "\"");
            }
        }

        private class EBinary : ETree
        {
            internal enum Opperator
            {
                Add,
                Subtact,
                Multiply,
                Divide,
                Raise,
                Modular
            }

            private readonly Opperator _opp;
            private readonly ETree _l;
            private readonly ETree _r;

            public EBinary(Opperator opperator, ETree left, ETree right)
            {
                _opp = opperator;
                _l = left;
                _r = right;
            }

            public override double GetValue(Dictionary<char, double> v)
            {
                switch (_opp)
                {
                    case Opperator.Add:
                        return _l.GetValue(v) + _r.GetValue(v);
                    case Opperator.Subtact:
                        return _l.GetValue(v) - _r.GetValue(v);
                    case Opperator.Multiply:
                        return _l.GetValue(v) * _r.GetValue(v);
                    case Opperator.Divide:
                        return _l.GetValue(v) / _r.GetValue(v);
                    case Opperator.Raise:
                        return Math.Pow(_l.GetValue(v), _r.GetValue(v));
                    case Opperator.Modular:
                        return _l.GetValue(v) % _r.GetValue(v);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public static Opperator GetBinaryOpperator(string s)
            {
                switch (s)
                {
                    case "+": return Opperator.Add;
                    case "-": return Opperator.Subtact;
                    case "*": return Opperator.Multiply;
                    case "/": return Opperator.Divide;
                    case "^": return Opperator.Raise;
                    case "%": return Opperator.Modular;
                    default: throw new ArgumentException();
                }
            }
        }

        private class EUnary : ETree
        {
            public enum Opperator
            {
                Negative
            }

            private readonly Opperator _opp;
            private readonly ETree _t;

            public EUnary(Opperator opperator, ETree t)
            {
                _t = t;
                _opp = opperator;
            }

            public override double GetValue(Dictionary<char, double> v)
            {
                switch (_opp)
                {
                    case Opperator.Negative:
                        return -_t.GetValue(v);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public static Opperator GetUnaryOpperator(string s)
            {
                if (s == "-")
                    return Opperator.Negative;
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}