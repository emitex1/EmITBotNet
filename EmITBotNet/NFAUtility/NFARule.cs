using ir.EmIT.EmITBotNet.NFAUtility.Action;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    class NFARule
    {
        public int srcState { get; }
        public AbstractAction action { get; }
        public int dstState { get; }

        public NFARule(int srcState, AbstractAction action, int dstState)
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
