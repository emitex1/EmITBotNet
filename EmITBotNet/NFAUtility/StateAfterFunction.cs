using System;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class StateAfterFunction
    {
        public int nextState;
        public int preState;
        public Func<AfterFunctionData, int> function;

        public StateAfterFunction(int newState, int preState, Func<AfterFunctionData, int> function)
        {
            this.nextState = newState;
            this.preState = preState;
            this.function = function;
        }
    }
}
