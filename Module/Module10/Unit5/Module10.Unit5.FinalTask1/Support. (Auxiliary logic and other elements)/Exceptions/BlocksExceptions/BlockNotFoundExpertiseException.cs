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

        // Проверка наличия фабрики в реестре для получение делегата (Func<OperationBlock>)
        // (в дальнейшем - для создания блока операций с заданным именем в словаре (blockRegistry))
        // и возвращения соответствующей фабрики через out-параметр
        public static void Expertise(
            string blockName,
            Dictionary<string, Func<OperationBlock>> blockRegistry,
            out Func<OperationBlock> factory)
        {
            if (!blockRegistry.TryGetValue(blockName, out factory))
                throw new BlockNotFoundException(blockName);
        }

        // Проверка доступности блока операций с заданным именем
        // в коллекции доступных блоков (IEnumerable<OperationBlock>)
        public static void Expertise(
            string blockName,
            IEnumerable<OperationBlock> availableBlocks)
        {
            if (!availableBlocks.Any(b => b.BlockName.Equals(blockName)))
                throw new BlockNotAvailableException(blockName);
        }
    }
}
