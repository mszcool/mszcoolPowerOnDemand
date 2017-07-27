using mszcoolPoDMachineInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDInventoryApi.Components
{
    public interface IEnvironmentsRepository
    {
        PoDEnvironment GetEnvironment(string environmentName);
        IList<PoDEnvironment> GetEnvironments(string ownerNameId);
        void AddEnvironment(PoDEnvironment newEnvironment);
        void UpdateEnvironment(PoDEnvironment updatedEnvironment);
        void DeleteEnvironment(string environmentName);
    }
}
