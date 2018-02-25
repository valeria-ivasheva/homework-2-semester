using System;

namespace Calculator
{
    interface IStack
    {
        //Забрать элемент
        double Pop();

        //Добавить элемент
        void Push(double value);

        //Проверка на пустоту
        bool IsEmpty();

    }
}
