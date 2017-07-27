using mszcoolPoDInventoryApi.Models;
using mszcoolPoDMachineInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDInventoryApi.Components
{
    public interface IDeviceAgentsRepository
    {
        PoDDeviceAgent GetAgent(string environmentName, string agentName);
        IList<PoDDeviceAgent> GetAgents(string environmentName);
        void AddAgent(string environmentName, PoDDeviceAgent newAgent);
        void UpdateAgent(PoDDeviceAgent updatedAgent);
        void RemoveAgent(string environmentName, string agentName);
        void AddAgentDevice(string environmentName, string agentName, PoDDevice device);
        void RemoveAgentDevice(string environmentName, string agentName, string deviceName);
    }
}