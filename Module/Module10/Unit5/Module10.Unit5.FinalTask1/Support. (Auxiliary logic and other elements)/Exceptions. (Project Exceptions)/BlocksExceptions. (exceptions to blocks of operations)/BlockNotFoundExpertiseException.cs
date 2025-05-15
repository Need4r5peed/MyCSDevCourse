using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public static class BlockNotFoundExpertiseException
    {
        // Проверка в реестре (по Dictionary<string, Func<OperationBlock>>)
        public static void Expertise(
            string blockName,
            Dictionary<string, Func<OperationBlock>> blockRegistry)
        {
            if (!blockRegistry.ContainsKey(blockName))
                throw new BlockNotFoundException(blockName);
        }

        // Проверка в доступных операциях (по IEnumerable<OperationBlock>)
        public static void Expertise(
            string blockName,
            IEnumerable<OperationBlock> availableBlocks)
        {
            if (!availableBlocks.Any(b => b.BlockName.Equals(blockName)))
                throw new BlockNotAvailableException(blockName);
        }
    }
}
