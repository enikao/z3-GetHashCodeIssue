using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Z3;
using System;
using System.Collections.Generic;

namespace Z3UnitTestHashCode
{
    class MyData
    {
        public string Name { get; set; }
    }

    [TestClass]
    public class TestSymbolHashCode
    {
        private Context _ctx;
        private Solver _solver;

        [TestMethod]
        public void TestMethod()
        {
            var data = new List<MyData> { new MyData { Name = "60" }, new MyData { Name = "61" } };
            var symbol2Data = new Dictionary<Symbol, MyData>();
            var data2Const = new Dictionary<MyData, BoolExpr>();

            _ctx = new Context(new Dictionary<string, string> { { "proof", "true" } });
            _solver = _ctx.MkSolver();

            foreach (var d in data)
            {
                var symbol = _ctx.MkSymbol($"Feature-{d.Name}");
                Console.WriteLine($"symbol: {d.Name} {symbol.GetHashCode()}");
                var constant = _ctx.MkBoolConst(symbol);
                symbol2Data[symbol] = d;
                data2Const[d] = constant;
            }

            Console.WriteLine(symbol2Data);
            Console.WriteLine(data2Const);

        }
    }
}
