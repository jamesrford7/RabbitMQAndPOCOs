using System;

namespace Consumer
{
    using Items;

    class Item2Processor : IItemProcessor
    {
        private Item2 _item2;

        public Item2Processor(Item2 item2)
        {
            _item2 = item2;
        }

        public void Process()
        {
            Console.WriteLine("Item 2 mofo!!");
            Console.WriteLine(_item2.Address);
            Console.WriteLine(_item2.Password);
        }
    }
}
