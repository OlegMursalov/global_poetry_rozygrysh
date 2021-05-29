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
            new Varik { Value = "На вписке йа - банши/королева!", IsTrue = true },
            new Varik { Value = "Мы эпохально стелим, а вы заправляете..", IsTrue = false },
            new Varik { Value = "Братик, они трутся стручками, у них фасолины", IsTrue = false },
            new Varik { Value = "Ха-ха-ха-ха-ха-ха-ха, нет! Не верю в это!!", IsTrue = false },
            new Varik { Value = "Завяжи свой х*й узлом, развяжи и завяжи опять", IsTrue = false },
            new Varik { Value = "У меня купюры длинные, это правда, йоу", IsTrue = false },
            new Varik { Value = "Моя жопа с Китай, воооууу", IsTrue = true },
            new Varik { Value = "Перед мамой уже сделал 'каминг-аут'", IsTrue = true },
            new Varik { Value = "йа говорил люблю.. да а толку???", IsTrue = false },
            new Varik { Value = "Мой отчим - тёмный Лорд, негр", IsTrue = true },
            new Varik { Value = "Если рэп для меня хобби, то пошёл йа на х*й", IsTrue = false },
            new Varik { Value = "Йа играю в Warface каждый день!!!", IsTrue = true },
            new Varik { Value = "Еврейство в крови, вампирю в ночи..", IsTrue = false },
            new Varik { Value = "Додики слягут в канаве, будут квакать, словно лягушки...", IsTrue = false },
            new Varik { Value = "Медики до ваших трупиков не добегут", IsTrue = true },
            new Varik { Value = "Йа как Равшан, типо Казах, а ты кто??", IsTrue = false },
            new Varik { Value = "Прессуют в школе эти альфы..", IsTrue = true },
            new Varik { Value = "Отдай мне этот лёд, эту тачку, это всё отдай, ахах, есь жы", IsTrue = false },
            new Varik { Value = "От тех, кто играет в CS'ку", IsTrue = true },
            new Varik { Value = "Они придумают правила, а мы завалим их", IsTrue = false },
            new Varik { Value = "Ребят, с нами вампиры-потники, которые сосут при Луне, но не кровь", IsTrue = true },
            new Varik { Value = "Почему меня не любят улицы, Олег, скажи мне!?", IsTrue = false },
            new Varik { Value = "ГЕЙСТВО - ЭТО, КОНЕЧНО, В ПЕРВУЮ ОЧЕРЕДЬ БОЛЬ!!", IsTrue = false },
            new Varik { Value = "Наш GANG не гейский, наш GANG трансушный!!!", IsTrue = false },
            new Varik { Value = "Мы пчелы, а вы в рэпе - трутни", IsTrue = false },
            new Varik { Value = "Дырка от бублика", IsTrue = false },
            new Varik { Value = "всех любим.. и ненавидим всех тоже.. есь жы..", IsTrue = true },
            new Varik { Value = "Из семьи моей давно ушёл отец", IsTrue = true },
            new Varik { Value = "Мою жопу не получит босс-капиталист, однако..", IsTrue = true },
            new Varik { Value = "Скажи мне, ты любишь меня за эти розыгрыши??", IsTrue = false },
            new Varik { Value = "Мама, целуй меня в лоб перед сном, все будет ОК", IsTrue = false },
            new Varik { Value = "Признайся, ты хотел так выглядеть! Так трахаться!!", IsTrue = false },
            new Varik { Value = "Играешь за инжу, додик? Ты уж обреченный!", IsTrue = true },
            new Varik { Value = "Ха, тебе сдавать экзамен, а мне нет!!", IsTrue = false },
            new Varik { Value = "БПШчка в тарелки с майонезною подливою", IsTrue = true },
            new Varik { Value = "Череп, кости.. В йаму меня бросьте..", IsTrue = false },
            new Varik { Value = "Мне всегда хотелось быть искренним с вами..", IsTrue = false },
            new Varik { Value = "бедняжкам завтра сдавать зачет", IsTrue = true },
            new Varik { Value = "А М О Н Г У С, рили..", IsTrue = false },
            new Varik { Value = "товарищ Троцкий примерил тут угги и сплясал с ледорубом", IsTrue = false },
            new Varik { Value = "мы любим новоприбывших варфейсеров..", IsTrue = true },
            new Varik { Value = "У ВАС ЕСТЬ ШАНС СТАТЬ УСПЕШНЫМИ И ПОДЗАРАБОТАТЬ РУБЛИ", IsTrue = true },
        };

        public IEnumerable<Varik> GetAllRapLines()
        {
            return _list;
        }
    }
}