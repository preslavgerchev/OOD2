using System;

namespace ClassDiagram_Final
{
    interface IFlowHandler
    {
        event Action PipelineValueChanged;
        void AdjustPipelineValues();
    }
}