namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class StateAfterFunction
    {
        public int nextState;
        public int preState;
        public AfterFunction function;

        public StateAfterFunction(int newState, int preState, AfterFunction function)
        {
            this.nextState = newState;
            this.preState = preState;
            this.function = function;
        }
    }
}
