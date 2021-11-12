namespace DFASimulator.ConsoleApp
{
    class DFA
    {

        private State StartState { get; set; }
        private List<State> FinalStates { get; set; }
        private List<State> States { get; set; }

        public DFA()
        {
            FinalStates = new List<State>();
            States = new List<State>();
        }

        public DFA AddStartState(State startState)
        {
            StartState = startState;
            return this;
        }

        public DFA AddFinalState(State finalState)
        {
            FinalStates.Add(finalState);
            return this;
        }

        public DFA AddState(State state)
        {
            States.Add(state);
            return this;
        }
        public DFA AddState(List<State> states)
        {
            States.AddRange(states);
            return this;
        }

        public bool Run(string input)
        {
            var currentState = StartState;

            for (int i = 0; i < input.Length; i++)
            {
                currentState = currentState.GetDestination(input[i].ToString());
            }

            return FinalStates.Contains(currentState);
        }

    }


    class State
    {
        public State(string name)
        {
            Name = name;
            Transitions = new Dictionary<string, State>();
        }

        private string Name { get; set; }
        private Dictionary<string, State> Transitions { get; set; }


        public void AddRoute(string transition, State destination)
        {
            Transitions.Add(transition, destination);
        }

        public State GetDestination(string transition)
        {
            var isValid = Transitions.TryGetValue(transition, out var destination);
            if (!isValid)
            {
                throw new Exception("State is not valid!");
            }

            return destination;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}