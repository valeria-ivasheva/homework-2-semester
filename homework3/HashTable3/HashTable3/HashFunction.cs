using System;

namespace HashTable3 
{
    /// <summary>
    /// Класс хэш-функции
    /// </summary>
    public class HashFunction : IHashFunction
    {
        /// <summary>
        /// Получить хэш-значение по ключу
        /// </summary>
        /// <param name="value">Ключ, для которого нужно вернуть хэш-значение</param>
        /// <returns> Значение хэш-функции</returns>
        public int GetHash(string value)
        {
            int number = 0;
            for (int i = 0; i < value.Length; i++)
            {
                number += value[i];
            }
            return number % 100;
        }
    }
}
