namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class RulePostFunction
    {
        public BotState nextState;
        public BotState preState;
        public PostFunction function;

        public RulePostFunction(BotState newState, BotState preState, PostFunction function)
        {
            this.nextState = newState;
            this.preState = preState;
            this.function = function;
        }
    }
}
