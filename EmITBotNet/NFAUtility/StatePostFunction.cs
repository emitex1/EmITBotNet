namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class StatePostFunction
    {
        public BotState nextState;
        public BotState preState;
        public PostFunction function;

        public StatePostFunction(BotState newState, BotState preState, PostFunction function)
        {
            this.nextState = newState;
            this.preState = preState;
            this.function = function;
        }
    }
}
