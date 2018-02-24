using ListSpace;

namespace HashTable
{
    class HashTable
    {
        List[] buckets = new List[100];

        private int HashFunction(string value)
        {
            int result = 0;
            int p = 2;
            for (int i = 0; i < value.Length; i++)
            {
                result = result * p + value[i];
            }
            return result / 100;
        }

        public void InsertElement(string value)
        {
            int number = HashFunction(value);
            if (buckets[number] == null)
            {
                var temp = new List(value);
                buckets[number] = temp;
                return;
            }
            buckets[number].Insert(value);
        }

        public void DeleteElement(string value)
        {
            int number = HashFunction(value);
            if (buckets[number] == null)
            {
                return;
            }
            buckets[number].DeleteElement(value);
        }

        public bool IsHaveElement(string value)
        {
            int number = HashFunction(value);
            if (buckets[number] == null)
            {
                return false;
            }
            return buckets[number].IsHaveElement(value);
        }
    }
}
