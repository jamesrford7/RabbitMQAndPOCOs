using System;

using Items;

namespace Consumer
{
    class Item1Processor : IItemProcessor
    {
        private Item1 item1;

        public Item1Processor(Item1 item1)
        {
            this.item1 = item1;
        }

        public void Process()
        {
            Console.WriteLine("Item 1 yo!");
            Console.WriteLine(this.item1.FirstName);
            Console.WriteLine(this.item1.Email);
        }
    }
}
