using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class BlockNotAvailableException : Exception
    {
        public string BlockName { get; }

        public BlockNotAvailableException(string blockName)
            : base($"Блок '{blockName}' не доступен!\nТак как ранее не был создан!")
            => BlockName = blockName;
    }
}
