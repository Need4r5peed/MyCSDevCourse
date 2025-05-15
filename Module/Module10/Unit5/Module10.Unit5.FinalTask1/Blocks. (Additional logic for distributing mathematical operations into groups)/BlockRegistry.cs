using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class BlockRegistry
    {
        private static readonly Dictionary<string, Func<OperationBlock>> _blockRegistry = new Dictionary<string, Func<OperationBlock>>();

        // Статический конструктор | вызывается один раз при первом обращении к классу
        static BlockRegistry()
        {
            // Регистрируем блок <BasicArithmeticBlock> под именем "basic arithmetic737"
            Register<BasicArithmeticBlock>("basic arithmetic");
        }
        // Метод для регистрации нового типа блока
        public static void Register<T>(string name) where T : OperationBlock, new()
        {
            // Добавляем в словарь фабрику, которая создаёт новый экземпляр типа T
            _blockRegistry[name] = () => new T();
        }

        // Добавляем в словарь делегат, который при вызове создаст новый экземпляр T
        public static OperationBlock Create(string blockName)
        {

            BlockNotFoundExpertiseException.Expertise(blockName, _blockRegistry);

            // 1. Доступ к словарю
            // 2. Ключ для поиска
            // 3. Вызов делегата
            return _blockRegistry[blockName]();
        }

        // Метод для получения списка всех доступных блок
        public static IEnumerable<string> GetAvailableBlocks() => _blockRegistry.Keys;
    }
}
