using System.Collections.Generic;
using System.Linq;
using ir.EmIT.EmITBotNet.NFAUtility.Action;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    public class EmITNFA
    {
        private List<NFARule> rules;
        private List<StatePostFunction> statePostFunctions;

        public EmITNFA()
        {
            rules = new List<NFARule>();
            statePostFunctions = new List<StatePostFunction>();
        }

        public void addRule(int srcState, string action, int dstState)
        {
            addRule(srcState, new StrAction(action), dstState);
        }

        public void addRule(int srcState, int action, int dstState)
        {
            addRule(srcState, new StrAction(action.ToString()), dstState);
        }

        public void addRule(int srcState, int fromAction, int toAction, int dstState)
        {
            for (int i = fromAction; i <= toAction; i++)
            {
                addRule(srcState, new StrAction(i.ToString()), dstState);
            }            
        }

        public void addRegexRule(int srcState, string regexExpr, int dstState)
        {
            addRule(srcState, new RegexAction(regexExpr), dstState);
        }

        public void addLambdaRule(int srcState, int dstState)
        {
            addRule(srcState, new LambdaAction(), dstState);
        }

        public void addElseRule(int srcState, int dstState)
        {
            addRule(srcState, new ElseAction(), dstState);
        }


        private void addRule(int srcState, AbstractAction action, int dstState)
        {
            rules.Add(new NFARule(srcState, action, dstState));
        }

        public void addRulePostFunction(int newState, int preState, PostFunction function)
        {
            statePostFunctions.Add(new StatePostFunction(newState, preState, function));
        }

        public void addRulePostFunction(int newState, PostFunction function)
        {
            statePostFunctions.Add(new StatePostFunction(newState, -1, function));
        }

        private int getNextState(int srcState, int action)
        {
            var matchedRules = rules.Where(r => r.srcState == srcState && r.action.isAction(action));
            if (matchedRules.Count() > 0)
                return matchedRules.First().dstState;
            else
                return -1;
        }

        public int getNextState(int srcState, string action)
        {
            var matchedRules = rules.Where(r => r.srcState == srcState && r.action.isAction(action));
            if (matchedRules.Count() > 0)
                return matchedRules.First().dstState;
            else
            {
                var elseRule = rules.Where(r => r.srcState == srcState && r.action.GetType() == typeof(ElseAction));
                if (elseRule.Count() > 0)
                    return elseRule.First().dstState;
                else
                    return -1;
            }
        }

        public int getNextState(int srcState)
        {
            var matchedRules = rules.Where(r => r.srcState == srcState && r.action.isAction(null));
            if (matchedRules.Count() > 0)
                return matchedRules.First().dstState;
            else
                return -1;
        }

        //todo تعیین تکلیف تابع move
        public PostFunction move(int srcState, string action)
        {
            int nextState = getNextState(srcState, action);
            var spfList = statePostFunctions.Where(spf => spf.preState == srcState && spf.nextState == nextState);
            if (spfList.Count() > 0)
                return spfList.First().function;
            else
            {
                spfList = statePostFunctions.Where(spf => spf.preState == -1 && spf.nextState == nextState);
                if (spfList.Count() > 0)
                    return spfList.First().function;
                else
                    return (PostFunctionData pfd) => { };
            }
        }

        public PostFunction getPostFunction(int preState, int nextState)
        {
            var spfList = statePostFunctions.Where(spf => spf.preState == preState && spf.nextState == nextState);
            if (spfList.Count() > 0)
                return spfList.First().function;
            else
            {
                spfList = statePostFunctions.Where(spf => spf.preState == -1 && spf.nextState == nextState);
                if (spfList.Count() > 0)
                    return spfList.First().function;
                else
                    return (PostFunctionData pfd) => { };
            }
        }

    }
}
