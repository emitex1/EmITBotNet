using ir.EmIT.EmITBotNet.NFAUtility.Action;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    //todo اصلاح نام NFARule و StatePostFunction به نام های مناسب و همسان
    class NFARule
    {
        public BotState srcState { get; }
        public IAction action { get; }
        public BotState dstState { get; }

        public NFARule(BotState srcState, IAction action, BotState dstState)
        {
            this.srcState = srcState;
            this.action = action;
            this.dstState = dstState;
        }

        public override string ToString()
        {
            return srcState.ToString() + " -> (" + action.ToString() + ") -> " + dstState.ToString();
        }
    }
}
