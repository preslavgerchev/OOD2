using System;

namespace Network_System.Interfaces
{
    interface IFlowHandler
    {
        event Action PipelineValueChanged;
        void AdjustPipelineValues();
    }
}