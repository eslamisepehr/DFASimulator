using DFASimulator.ConsoleApp;

var A = new State("A");
var B = new State("B");
var C = new State("C");
var D = new State("D");

A.AddTransition("1", A);
A.AddTransition("0", B);
B.AddTransition("1", A);
B.AddTransition("0", C);
C.AddTransition("1", A);
C.AddTransition("0", D);
D.AddTransition("0", D);
D.AddTransition("1", D);


Console.Write("Please enter the string: ");
var input = Console.ReadLine();

var dfa = new DFA()
    .AddState(A).AddState(B).AddState(C).AddState(D)
    .AddStartState(A)
    .AddFinalState(A);

var result = dfa.Run(input);
Console.WriteLine($"{input} is valid? {result}");