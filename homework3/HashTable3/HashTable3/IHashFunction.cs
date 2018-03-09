namespace HashTable3
{
    /// <summary>
    /// Интерфейс хэш-функции
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Получить хэш-значение по ключу
        /// </summary>
        /// <param name="value">Ключ, для которого нужно вернуть хэш-значение</param>
        /// <returns>Значение хэш-функции</returns>
        int GetHash(string value);
    }
}
