using System;
using System.Collections.Generic;

public class HashTableChain {
    private List<string>[] table; // Используем только один тип

    public void Add(string key) {
        // Добавляем ключ в соответствующий список
        int index = GetIndex(key);
        table[index].Add(key);
    }

    private int GetIndex(string key) {
        // Реализация метода GetIndex
        throw new NotImplementedException();
    }
} 