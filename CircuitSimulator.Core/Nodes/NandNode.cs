﻿using System;

namespace CircuitSimulator.Core.Nodes
{
    public class NandNode :  Node
	{

        //      (More inputs possible)
        //      (Goes by the rule: 'If all inputs are high, output a low signal')

        //      Input A  Input B  Output
        //      0        0        1
        //      0        1        1
        //      1        0        1
        //      1        1        0


        protected override NodeCurrent processOutput(NodeCurrent value)
        {
            InputValues.Add(value);

            NodeCurrent output = NodeCurrent.None;
            foreach (NodeCurrent input in InputValues)
            {
                if (input == NodeCurrent.High && output != NodeCurrent.High)
                {
                    output = NodeCurrent.Low;
                }
                else
                {
                    output = NodeCurrent.High;
                }

            }

            this.value = output;
            return output;
        }
    }
}
