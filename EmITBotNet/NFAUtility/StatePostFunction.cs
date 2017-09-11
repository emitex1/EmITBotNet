namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class StatePostFunction
    {
        public int nextState;
        public int preState;
        public PostFunction function;

        public StatePostFunction(int newState, int preState, PostFunction function)
        {
            this.nextState = newState;
            this.preState = preState;
            this.function = function;
        }
    }
}
