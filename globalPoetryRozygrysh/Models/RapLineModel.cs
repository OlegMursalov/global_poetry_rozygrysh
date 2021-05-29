using System.Collections.Generic;

namespace globalPoetryRozygrysh.Models
{
    public class Varik
    {
        public string Value { get; set; }
        public bool IsTrue { get; set; }
    }

    public class RapLineModel
    {
        private readonly IEnumerable<Varik> _list = new List<Varik>
        {
            new Varik { Value = "Йа - вампир новой эры, спасибо этому тырнэту", IsTrue = true },
            new Varik { Value = "Ты что? Оглох? Йа - эпоха!", IsTrue = false },
            new Varik { Value = "У меня большие стволы, как члены негрил", IsTrue = false },
            new Varik { Value = "Сало, оливки!", IsTrue = true },
            new Varik { Value = "Мой геморрой с волейбольный мяч", IsTrue = false },
            new Varik { Value = "За окном тьма и псин вой..", IsTrue = false },
            new Varik { Value = "Толстая йа трансуха-фемка, снимать трусы мне некому..", IsTrue = true },
        };

        public IEnumerable<Varik> GetAllRapLines()
        {
            return _list;
        }
    }
}