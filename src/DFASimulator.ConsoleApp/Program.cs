using DFASimulator.ConsoleApp;

var A = new State("A");
var B = new State("B");
var C = new State("C");
var D = new State("D");

A.AddRoute("1", A);
A.AddRoute("0", B);
B.AddRoute("1", A);
B.AddRoute("0", C);
C.AddRoute("1", A);
C.AddRoute("0", D);
D.AddRoute("0", D);
D.AddRoute("1", D);


Console.Write("Please enter the string: ");
var input = Console.ReadLine();

var dfa = new DFA()
    .AddState(A).AddState(B).AddState(C).AddState(D)
    .AddStartState(A)
    .AddFinalState(A);

var result = dfa.Run(input);
Console.WriteLine($"{input} is valid? {result}");