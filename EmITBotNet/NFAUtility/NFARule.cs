using ir.EmIT.EmITBotNet.NFAUtility.Action;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    class NFARule
    {
        public int srcState { get; }
        public IAction action { get; }
        public int dstState { get; }

        public NFARule(int srcState, IAction action, int dstState)
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
