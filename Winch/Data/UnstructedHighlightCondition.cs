using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winch.Data.GridConfig;

namespace Winch.Data
{
    /// <summary>
    /// Need this or else SetValue won't work
    /// </summary>
    public class UnstructedHighlightCondition
    {
        public bool alwaysHighlight = false;

        public List<QuestStepData> ifTheseStepsActive = new List<QuestStepData>();

        public List<string> highlightIfNodesUnvisited = new List<string>();

        public List<string> andTheseNodesVisited = new List<string>();

        public List<QuestStepData> andTheseStepsNotCompleted = new List<QuestStepData>();

        public HighlightConditionExtraData extraConditions;

        public static implicit operator HighlightCondition(UnstructedHighlightCondition u)
        {
            return new HighlightCondition
            {
                alwaysHighlight = u.alwaysHighlight,
                ifTheseStepsActive = u.ifTheseStepsActive,
                highlightIfNodesUnvisited = u.highlightIfNodesUnvisited,
                andTheseNodesVisited = u.andTheseNodesVisited,
                andTheseStepsNotCompleted = u.andTheseStepsNotCompleted,
                extraConditions = u.extraConditions
            };
        }
    }
}
