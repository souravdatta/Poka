using Poka;

var evaluator = new PokaEvaluator();
evaluator.Eval("[1 2.0 3] 3.23 + {foo| + reduce}");
