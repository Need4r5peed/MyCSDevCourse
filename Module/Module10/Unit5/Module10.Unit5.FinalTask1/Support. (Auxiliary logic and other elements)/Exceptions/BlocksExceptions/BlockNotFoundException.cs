using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class BlockNotFoundException : Exception
    {
        public string BlockName { get; }

        public BlockNotFoundException(string blockName)
            : base($"Блок '{blockName}' не найден в реестре.\nУказанный блок операций не создан!")
            => BlockName = blockName;
    }
}