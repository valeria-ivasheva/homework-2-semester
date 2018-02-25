using ListSpace;

namespace HashTable
{
    class HashTable
    {
        private List[] buckets = new List[100];

        private int abs(int value)
        {
            if (value < 0)
            {
                value *= -1;
            }
            return value;
        }

        public void InsertElement(string value)
        {
            int number = abs(value.GetHashCode() % 100);
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
            int number = abs(value.GetHashCode() % 100);
            if (buckets[number] == null)
            {
                return;
            }
            buckets[number].DeleteElement(value);
        }

        public bool HasElement(string value)
        {
            int number = abs(value.GetHashCode() % 100);
            if (buckets[number] == null)
            {
                return false;
            }
            return buckets[number].HasElement(value);
        }
    }
}
