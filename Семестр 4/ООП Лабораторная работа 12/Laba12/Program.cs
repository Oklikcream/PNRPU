using UsefulLib;
using TransportLib;
using System.Collections;
using System.Collections.Generic;

namespace Laba12
{
    class DoubleNode<T>
    {
        public T data;
        public DoubleNode<T>? next;
        public DoubleNode<T>? prev;

        public DoubleNode(T data)
        {
            this.data = data;
            next = null;
            prev = null;
        }
    }

    class DoubleList<T>
    {
        public DoubleNode<T>? tail;
        public DoubleNode<T>? head;
        private static int length;

        public int Length
        {
            get => length;
        }

        public DoubleList()
        {
            tail = null;
            head = null;
        }

        public void AddLast(T data)
        {
            DoubleNode<T> newNode = new(data);

            if (tail != null)
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            else
            {
                tail = newNode;
                head = tail;
            }

            length++;
        }

        public void AddAt(int index, T data)
        {
            if (index <= length + 1 && index > 0)
            {
                DoubleNode<T> newNode = new(data);

                if (index == 1)
                {
                    newNode.next = head;
                    if (head != null)
                        head.prev = newNode;
                    else
                        tail = newNode;
                    head = newNode;
                    return;
                }

                var current = head;

                for (int i = 1; i < index - 1; i++)
                {
                    current = current.next;
                }

                newNode.next = current.next;
                if (current.next != null) 
                    current.next.prev = newNode;
                current.next = newNode;
                newNode.prev = current;

                length++;
            }
            else
            {
                throw new Exception("Index out of range!");
            }
        }

        public void Print()
        {
            Console.WriteLine("Вывод: ");
            if (head != null)
            {
                var current = head;
                while (current != null)
                {
                    Console.WriteLine($"| {current.data.ToString()}");
                    current = current.next;
                }
            }
            else
            {
                Console.WriteLine("| Список пуст");
            }
        }

        public void Clear()
        {
            var current = head;
            while (current != null)
            {
                var next = current.next;
                current.next = null;
                current.prev = null;
                current = next;
            }

            head = null;
            tail = null;

            Console.WriteLine("Список очищен");
        }
    }

    class BinaryNode<T>
    {
        public T data;
        public BinaryNode<T>? left;
        public BinaryNode<T>? right;

        public BinaryNode(T data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    class BinaryTree<T> where T : Transport
    {
        private BinaryNode<T>? root;

        public BinaryTree()
        {
            root = null;
        }

        public void Add(T data)
        {
            BinaryNode<T> newItem = new(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }

        private BinaryNode<T> RecursiveInsert(BinaryNode<T>? current, BinaryNode<T> n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data.MaxSpeed < current.data.MaxSpeed)
            {
                current.left = RecursiveInsert(current.left, n);
                current = BalanceTree(current);
            }
            else if (n.data.MaxSpeed > current.data.MaxSpeed)
            {
                current.right = RecursiveInsert(current.right, n);
                current = BalanceTree(current);
            }
            return current;
        }

        private BinaryNode<T> BalanceTree(BinaryNode<T> current)
        {
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                if (BalanceFactor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        public void Print()
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пусто");
                return;
            }
            PrintRecursive(root, "", true);
        }

        private void PrintRecursive(BinaryNode<T> current, string indent, bool last)
        {
            if (current != null)
            {
                Console.WriteLine(indent + (last ? "└── " : "├── ") + current.data.ToString());
                
                if (current.left != null)
                {
                    PrintRecursive(current.left, indent + (last ? "    " : "│   "), current.right == null);
                }
                if (current.right != null)
                {
                    PrintRecursive(current.right, indent + (last ? "    " : "│   "), true);
                }
            }
        }

        public T? FindMin<TKey>(Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        {
            if (root == null) 
                return default;
            return FindMinRecursive(root, keySelector).data;
        }

        private BinaryNode<T> FindMinRecursive<TKey>(BinaryNode<T> current, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        {
            BinaryNode<T> minNode = current;
            
            if (current.left != null)
            {
                var leftMin = FindMinRecursive(current.left, keySelector);
                if (keySelector(leftMin.data).CompareTo(keySelector(minNode.data)) < 0)
                {
                    minNode = leftMin;
                }
            }
            
            if (current.right != null)
            {
                var rightMin = FindMinRecursive(current.right, keySelector);
                if (keySelector(rightMin.data).CompareTo(keySelector(minNode.data)) < 0)
                {
                    minNode = rightMin;
                }
            }
            
            return minNode;
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }

        private int getHeight(BinaryNode<T>? current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }

        private int BalanceFactor(BinaryNode<T> current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }

        private BinaryNode<T> RotateRR(BinaryNode<T> parent)
        {
            BinaryNode<T> pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }

        private BinaryNode<T> RotateLL(BinaryNode<T> parent)
        {
            BinaryNode<T> pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

        private BinaryNode<T> RotateLR(BinaryNode<T> parent)
        {
            BinaryNode<T> pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }

        private BinaryNode<T> RotateRL(BinaryNode<T> parent)
        {
            BinaryNode<T> pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }

        public void Clear()
        {
            ClearRecursive(root);
            root = null;
            Console.WriteLine("Дерево очищено");
        }

        private void ClearRecursive(BinaryNode<T>? node)
        {
            if (node != null)
            {
                ClearRecursive(node.left);
                ClearRecursive(node.right);
                node.data = default;
                node.left = null;
                node.right = null;
            }
        }

        public void ConvertToSearchTree()
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пусто");
                return;
            }
            List<T> sortedNodes = new();
            InOrderTraversal(root, sortedNodes);
            
            sortedNodes.Sort((a, b) => a.MaxSpeed.CompareTo(b.MaxSpeed));
            
            root = BuildBalancedBST(sortedNodes, 0, sortedNodes.Count - 1);
            
            Console.WriteLine("Дерево преобразовано в дерево поиска");
        }

        private BinaryNode<T>? BuildBalancedBST(List<T> sortedNodes, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            BinaryNode<T> node = new(sortedNodes[mid]);

            node.left = BuildBalancedBST(sortedNodes, start, mid - 1);
            node.right = BuildBalancedBST(sortedNodes, mid + 1, end);

            return node;
        }

        private void InOrderTraversal(BinaryNode<T>? node, List<T> nodes)
        {
            if (node != null)
            {
                InOrderTraversal(node.left, nodes);
                nodes.Add(node.data);
                InOrderTraversal(node.right, nodes);
            }
        }
    }

    class HashTable<T> where T : Transport
    {
        private T?[] table;
        private int size;
        private int count;

        public int Size => size;
        public int Count => count;

        public HashTable(int size)
        {
            this.size = size;
            table = new T[size];
            count = 0;
        }

        private int Hash(T item)
        {
            return Math.Abs(item.GetHashCode()) % size;
        }

        public void Add(T item)
        {
            if (count >= size)
            {
                Console.WriteLine("Таблица заполнена");
                return;
            }

            int hash = Hash(item);

            while (table[hash] != null)
            {
                hash = (hash + 1) % size;
            }

            table[hash] = item;
            count++;
        }

        public void Find(T item)
        {
            int hash = Hash(item);
            for (int i = 0; i < size; i++)
            {
                if (table[hash] != null && item.Equals(table[hash]))
                { 
                    Console.WriteLine($"Найденный элемент: {table[hash]}");
                    return;
                }
                hash = (hash + 1) % size;
            }
            Console.WriteLine("Элемент не найден");
        }

        public void Remove(T item)
        {
            int hash = Hash(item);
            for (int i = 0; i < size; i++)
            {
                if (table[hash] != null && item.Equals(table[hash]))
                {
                    Console.WriteLine($"Удаленный элемент: {table[hash]}");
                    table[hash] = null;
                    count--;
                    return;
                }
                hash = (hash + 1) % size;
            }
            Console.WriteLine("Элемент не найден");
        }

        public void Print()
        {
            Console.WriteLine("Хеш-таблица:");
            for (int i = 0; i < size; i++)
            {
                if (table[i] != null)
                    Console.WriteLine($"[{i}] -> {table[i]}");
                else
                    Console.WriteLine($"[{i}] -> пусто");
            }
        }

        public void Clear()
        {
            Array.Clear(table, 0, size);
            count = 0;
            Console.WriteLine("Таблица очищена");
        }
    }

    class HashTableChain<T> : IDictionary<T, T>, ICollection<KeyValuePair<T, T>>, IEnumerable<KeyValuePair<T, T>>, IEnumerator<KeyValuePair<T, T>> where T : Transport
    {
        private LinkedList<KeyValuePair<T, T>>[] table;
        private int size;
        private int count;
        private int currentIndex = -1;
        private LinkedListNode<KeyValuePair<T, T>>? currentNode;

        public HashTableChain()
        {
            size = 10;
            table = new LinkedList<KeyValuePair<T, T>>[size];
            for (int i = 0; i < size; i++)
                table[i] = new LinkedList<KeyValuePair<T, T>>();
        }

        public HashTableChain(int capacity)
        {
            size = capacity;
            table = new LinkedList<KeyValuePair<T, T>>[size];
            for (int i = 0; i < size; i++)
                table[i] = new LinkedList<KeyValuePair<T, T>>();
        }

        public HashTableChain(HashTableChain<T> other)
        {
            size = other.size;
            count = other.count;
            table = new LinkedList<KeyValuePair<T, T>>[size];

            for (int i = 0; i < size; i++)
            {
                table[i] = new LinkedList<KeyValuePair<T, T>>();
                foreach (var pair in other.table[i])
                {
                    table[i].AddLast(pair);
                }
            }
        }

        public int Count => count;
        public bool IsReadOnly => false;

        private int Hash(T item)
        {
            return Math.Abs(item.GetHashCode()) % size;
        }

        public void Add(T key, T value) // IDictionary.Add
        {
            int hash = Hash(key);
            var pair = new KeyValuePair<T, T>(key, value);
            table[hash].AddLast(pair);
            count++;
        }

        public void Add(KeyValuePair<T, T> item) // ICollection.Add
        {
            Add(item.Key, item.Value);
        }

        public void Add(T item) // ICollection.Add
        {
            Add(item, item);
        }

        public bool TryGetValue(T key, out T value)
        {
            int hash = Hash(key);
            foreach (var pair in table[hash])
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            value = default;
            return false;
        }

        public bool Remove(T key) // IDictonary.Remove
        {
            int hash = Hash(key);
            var node = table[hash].First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    table[hash].Remove(node);
                    count--;
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public bool Remove(KeyValuePair<T, T> item) // ICollection.Remove
        {
            return Remove(item.Key);
        }

        public T this[T key]
        {
            get
            {
                if (TryGetValue(key, out T value))
                    return value;
                throw new KeyNotFoundException();
            }
            set
            {
                Remove(key);
                Add(key, value);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < size; i++)
                table[i].Clear();
            count = 0;
        }

        public bool Contains(KeyValuePair<T, T> item)
        {
            int hash = Hash(item.Key);
            return table[hash].Contains(item);
        }

        public bool ContainsKey(T key)
        {
            return TryGetValue(key, out _);
        }

        public void CopyTo(KeyValuePair<T, T>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Недостаточно места в целевом массиве");

            foreach (var list in table)
            {
                foreach (var pair in list)
                {
                    array[arrayIndex++] = pair;
                }
            }
        }

        public IEnumerator<KeyValuePair<T, T>> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                foreach (var pair in table[i])
                {
                    yield return pair;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if (currentNode == null)
            {
                currentIndex++;
                if (currentIndex >= size) return false;
                currentNode = table[currentIndex].First;
            }
            else
            {
                currentNode = currentNode.Next;
            }

            return currentNode != null;
        }

        public void Reset()
        {
            currentIndex = -1;
            currentNode = null;
        }

        public KeyValuePair<T, T> Current => currentNode.Value;
        object IEnumerator.Current => Current;
        public void Dispose() { }

        public ICollection<T> Keys // Реализация IDictionary.Keys
        {
            get
            {
                List<T> keys = new List<T>();
                for (int i = 0; i < size; i++)
                {
                    foreach (var pair in table[i])
                    {
                        keys.Add(pair.Key);
                    }
                }
                return keys;
            }
        }

        public ICollection<T> Values
        {
            get
            {
                List<T> values = new List<T>();
                for (int i = 0; i < size; i++)
                {
                    foreach (var pair in table[i])
                    {
                        values.Add(pair.Value);
                    }
                }
                return values;
            }
        }

        public T? Find(T key)
        {
            int hash = Hash(key);
            foreach (var pair in table[hash])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
            return default;
        }

        public HashTableChain<T> DeepClone()
        {
            HashTableChain<T> clone = new(size);

            for (int i = 0; i < size; i++)
            {
                clone.table[i] = new LinkedList<KeyValuePair<T, T>>();
                foreach (var pair in table[i])
                {
                    T clonedKey;
                    T clonedValue;

                    if (pair.Key is Transport transportKey)
                    {
                        clonedKey = (T)transportKey.Clone();
                    }
                    else if (pair.Key is Car carKey)
                    {
                        clonedKey = (T)carKey.Clone();
                    }
                    else if (pair.Key is Train trainKey)
                    {
                        clonedKey = (T)trainKey.Clone();
                    }
                    else if (pair.Key is Express expressKey)
                        clonedKey = (T)expressKey.Clone();
                    else
                    {
                        throw new InvalidOperationException($"Type {pair.Key.GetType().Name} does not implement ICloneable.");
                    }

                    if (pair.Value is Transport transportValue)
                    {
                        clonedValue = (T)transportValue.Clone();
                    }
                    else if (pair.Value is Car carValue)
                    {
                        clonedValue = (T)carValue.Clone();
                    }
                    else if (pair.Value is Train trainValue)
                    {
                        clonedValue = (T)trainValue.Clone();
                    }
                    else if (pair.Value is Express expressValue)
                    {
                        clonedValue = (T)expressValue.Clone();
                    }
                    else
                    {
                        throw new InvalidOperationException($"Type {pair.Value.GetType().Name} does not implement ICloneable.");
                    }

                    clone.Add(clonedKey, clonedValue);
                }
            }
            return clone;
        }

        public HashTableChain<T> ShallowCopy()
        {
            return new HashTableChain<T>(this);
        }

        public void Print()
        {
            Console.WriteLine("Хеш-таблица:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"[{i}] -> ");
                if (table[i].Count == 0)
                    Console.WriteLine("пусто");
                else
                {
                    foreach (var pair in table[i])
                    {
                        Console.WriteLine($"{pair.Value}");
                        Console.Write("     -> ");
                    }
                    Console.WriteLine("null");
                }
            }
        }
    }

    class Program
    {
        static readonly string[] mainOperations =
        [
            "Работа с двунаправленным списком",
            "Работа с бинарным деревом",
            "Работа с хеш-таблицей (метод открытой адресации)",
            "Работа с обобщённой коллекцией (хеш-таблица метод цепочек)",
            "Выход"
        ];
        static readonly string[] ListOperations =
        [
            "Печать",
            "Добавить элемент",
            "Добавить элемент по номеру",
            "Очистить",
            "Выход"
        ];

        static readonly string[] AddOperations =
        [
            "Вручную",
            "ДСЧ",
            "Выход"
        ];
        static readonly string[] BinaryOperations =
        [
            "Печать",
            "Добавить элемент",
            "Найти минимальный элемент",
            "Преобразовать идеально сбалансированное дерево в дерево поиска",
            "Очистить",
            "Выход"
        ];
        static readonly string[] SearchOperations =
        [
            "По скорости",
            "По году выпуска",
            "Выход"
        ];
        static readonly string[] HashOperations =
        [
            "Печать",
            "Добавить элемент",
            "Найти элемент",
            "Удалить элемент",
            "Очистить",
            "Выход"
        ];
        static readonly string[] ChoiceClass =
        [
            "Transport",
            "Car",
            "Train",
            "Express",
            "Выход"
        ];
        static readonly string[] HashChainOperations =
        [
            "Печать",
            "Добавить элемент",
            "Найти элемент",
            "Глубокое клонирование",
            "Поверхностное копирование",
            "Перебор в foreach",
            "Очистить",
            "Выход"
        ];

        static void Main()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Меню");
                DisplayMenu(mainOperations);

                int operId = UsefulFunct.InputIntFromDiaposon(1, 5);
                PrintWait();

                switch (operId)
                {
                    case 1:
                        ManageDoublyLinkedList();
                        break;
                    case 2:
                        ManageBinaryTree();
                        break;
                    case 3:
                        ManageHashTable();
                        break;
                    case 4:
                        ManageGenericCollection();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static void DisplayMenu(string[] operations)
        {
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {operations[i]}");
            }
            Console.WriteLine();
        }

        static void ManageDoublyLinkedList()
        {
            bool isRunning = true;
            DoubleList<Transport> transportList = new();

            while (isRunning)
            {
                Console.WriteLine("Работа с двунаправленным списком");
                DisplayMenu(ListOperations);

                int operId = UsefulFunct.InputIntFromDiaposon(1, 5);
                PrintWait();

                switch (operId)
                {
                    // Печать
                    case 1:
                        transportList.Print();
                        PrintWait();
                        break;
                    // Добавление элемента
                    case 2:
                        Console.WriteLine("Добавление элемента в конец списка");
                        DisplayMenu(AddOperations);
                        int addChoice = UsefulFunct.InputIntFromDiaposon(1, 3);
                        PrintWait();

                        switch (addChoice)
                        {
                            // Вручную
                            case 1:
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int classChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                Transport newTransport;
                                switch (classChoice)
                                {
                                    case 1:
                                        newTransport = new Transport();
                                        newTransport.Init();
                                        transportList.AddLast(newTransport);
                                        PrintWait();
                                        break;
                                    case 2:
                                        newTransport = new Car();
                                        newTransport.Init();
                                        transportList.AddLast(newTransport);
                                        PrintWait();
                                        break;
                                    case 3:
                                        newTransport = new Train();
                                        newTransport.Init();
                                        transportList.AddLast(newTransport);
                                        PrintWait();
                                        break;
                                    case 4:
                                        newTransport = new Express();
                                        newTransport.Init();
                                        transportList.AddLast(newTransport);
                                        PrintWait();
                                        break;
                                    case 5:
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            // ДСЧ
                            case 2:
                                Console.Write("Введите количество элементов: ");
                                int num = UsefulFunct.InputPositiveInt();
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int randomClassChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                for (int i = 0; i < num; i++)
                                {    
                                    Transport randomTransport;
                                    switch (randomClassChoice)
                                    {
                                        case 1:
                                            randomTransport = new Transport();
                                            randomTransport.RandomInit();
                                            transportList.AddLast(randomTransport);
                                            break;
                                        case 2:
                                            randomTransport = new Car();
                                            randomTransport.RandomInit();
                                            transportList.AddLast(randomTransport);
                                            break;
                                        case 3:
                                            randomTransport = new Train();
                                            randomTransport.RandomInit();
                                            transportList.AddLast(randomTransport);
                                            break;
                                        case 4:
                                            randomTransport = new Express();
                                            randomTransport.RandomInit();
                                            transportList.AddLast(randomTransport);
                                            break;
                                        case 5:
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                break;
                            case 3:
                                break;
                        }
                        break;
                    // Добавлнеие по номеру
                    case 3:
                        Console.WriteLine("Добавление элемента по номеру");
                        Console.Write("Введите номер позиции: ");
                        int position = UsefulFunct.InputIntFromDiaposon(1, transportList.Length + 1);
                        
                        DisplayMenu(AddOperations);
                        int addAtChoice = UsefulFunct.InputIntFromDiaposon(1, 3);
                        PrintWait();

                        switch (addAtChoice)
                        {
                            // Вручную
                            case 1:
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int addAtClassChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                Transport newAtTransport;
                                switch (addAtClassChoice)
                                {
                                    case 1:
                                        newAtTransport = new Transport();
                                        newAtTransport.Init();
                                        transportList.AddAt(position, newAtTransport);
                                        PrintWait();
                                        break;
                                    case 2:
                                        newAtTransport = new Car();
                                        newAtTransport.Init();
                                        transportList.AddAt(position, newAtTransport);
                                        PrintWait();
                                        break;
                                    case 3:
                                        newAtTransport = new Train();
                                        newAtTransport.Init();
                                        transportList.AddAt(position, newAtTransport);
                                        PrintWait();
                                        break;
                                    case 4:
                                        newAtTransport = new Express();
                                        newAtTransport.Init();
                                        transportList.AddAt(position, newAtTransport);
                                        PrintWait();
                                        break;
                                    case 5:
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            // ДСЧ
                            case 2:
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int randomAtClassChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                Transport randomAtTransport;
                                switch (randomAtClassChoice)
                                {
                                    case 1:
                                        randomAtTransport = new Transport();
                                        randomAtTransport.RandomInit();
                                        transportList.AddAt(position, randomAtTransport);
                                        break;
                                    case 2:
                                        randomAtTransport = new Car();
                                        randomAtTransport.RandomInit();
                                        transportList.AddAt(position, randomAtTransport);
                                        break;
                                    case 3:
                                        randomAtTransport = new Train();
                                        randomAtTransport.RandomInit();
                                        transportList.AddAt(position, randomAtTransport);
                                        break;
                                    case 4:
                                        randomAtTransport = new Express();
                                        randomAtTransport.RandomInit();
                                        transportList.AddAt(position, randomAtTransport);
                                        break;
                                    case 5:
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 3:
                                break;
                        }
                        break;
                    // Очистка
                    case 4:
                        transportList.Clear();
                        PrintWait();
                        break;
                    // Выход
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static void ManageBinaryTree()
        {
            bool isRunning = true;
            BinaryTree<Transport> transportTree = new();

            while (isRunning)
            {
                Console.WriteLine("Работа с бинарным деревом");
                DisplayMenu(BinaryOperations);

                int operId = UsefulFunct.InputIntFromDiaposon(1, 6);
                PrintWait();

                switch (operId)
                {
                    // Печать
                    case 1:
                        transportTree.Print();
                        PrintWait();
                        break;
                    // Добавление элемента
                    case 2:
                        Console.WriteLine("Добавление элемента");
                        DisplayMenu(AddOperations);
                        int addChoice = UsefulFunct.InputIntFromDiaposon(1, 3);
                        PrintWait();

                        switch (addChoice)
                        {
                            // Вручную
                            case 1:
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int classChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                Transport newTransport;
                                switch (classChoice)
                                {
                                    case 1:
                                        newTransport = new Transport();
                                        newTransport.Init();
                                        transportTree.Add(newTransport);
                                        PrintWait();
                                        break;
                                    case 2:
                                        newTransport = new Car();
                                        newTransport.Init();
                                        transportTree.Add(newTransport);
                                        PrintWait();
                                        break;
                                    case 3:
                                        newTransport = new Train();
                                        newTransport.Init();
                                        transportTree.Add(newTransport);
                                        PrintWait();
                                        break;
                                    case 4:
                                        newTransport = new Express();
                                        newTransport.Init();
                                        transportTree.Add(newTransport);
                                        PrintWait();
                                        break;
                                    case 5:
                                        break;
                                }
                                break;
                            // ДСЧ
                            case 2:
                                Console.Write("Введите количество элементов: ");
                                int num = UsefulFunct.InputPositiveInt();
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int randomClassChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                for (int i = 0; i < num; i++)
                                {
                                    Transport randomTransport;
                                    switch (randomClassChoice)
                                    {
                                        case 1:
                                            randomTransport = new Transport();
                                            randomTransport.RandomInit();
                                            transportTree.Add(randomTransport);
                                            break;
                                        case 2:
                                            randomTransport = new Car();
                                            randomTransport.RandomInit();
                                            transportTree.Add(randomTransport);
                                            break;
                                        case 3:
                                            randomTransport = new Train();
                                            randomTransport.RandomInit();
                                            transportTree.Add(randomTransport);
                                            break;
                                        case 4:
                                            randomTransport = new Express();
                                            randomTransport.RandomInit();
                                            transportTree.Add(randomTransport);
                                            break;
                                        case 5:
                                            break;
                                    }
                                }
                                break;
                            case 3:
                                break;
                        }
                        break;
                    // Поиск минимального элемента
                    case 3: 
                        Console.WriteLine("Выберите критерий поиска минимального элемента:");
                        DisplayMenu(SearchOperations);
                        int searchChoice = UsefulFunct.InputIntFromDiaposon(1, 3);
                        PrintWait();

                        Transport? minElement = null;
                        switch (searchChoice)
                        {
                            case 1:
                                minElement = transportTree.FindMin(t => t.MaxSpeed);
                                if (minElement != null)
                                {
                                    Console.WriteLine($"Транспорт с минимальной скоростью: {minElement}");
                                    PrintWait();
                                }
                                break;
                            case 2:
                                minElement = transportTree.FindMin(t => t.Year);
                                if (minElement != null)
                                {
                                    Console.WriteLine($"Транспорт с минимальным годом выпуска: {minElement}");
                                    PrintWait();
                                }
                                break;
                            case 3:
                                break;
                        }

                        if (minElement == null && searchChoice != 3)
                        {
                            Console.WriteLine("Дерево пусто");
                            PrintWait();
                        }

                        break;
                    // Преобразование в дерево поиска
                    case 4:
                        transportTree.ConvertToSearchTree();
                        PrintWait();
                        break;
                    // Очистка
                    case 5:
                        transportTree.Clear();
                        PrintWait();
                        break;
                    // Выход
                    case 6:
                        isRunning = false;
                        break;
                }
            }
        }

        static void ManageHashTable()
        {
            Console.Write("Введите размер хеш-таблицы: ");
            int size = UsefulFunct.InputPositiveInt();
            Console.Clear();
            bool isRunning = true;
            HashTable<Transport> transportHash = new(size);

            while (isRunning)
            {
                Console.WriteLine($"Работа с хеш-таблицей (метод открытой адресации)");
                Console.WriteLine($"  Размер: {transportHash.Size}, количество элементов: {transportHash.Count}");
                DisplayMenu(HashOperations);

                int operId = UsefulFunct.InputIntFromDiaposon(1, 6);
                PrintWait();

                switch (operId)
                {
                    // Печать
                    case 1:
                        transportHash.Print();
                        PrintWait();
                        break;
                    // Добавление элементов
                    case 2:
                        Console.WriteLine("Добавление элемента");
                        DisplayMenu(AddOperations);
                        int addChoice = UsefulFunct.InputIntFromDiaposon(1, 3);
                        PrintWait();

                        switch (addChoice)
                        {
                            // Вручную
                            case 1:
                                if (transportHash.Count >= transportHash.Size)
                                {
                                    Console.WriteLine("Таблица заполнена");
                                    PrintWait();
                                    break;
                                }

                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int classChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                Transport newTransport;
                                switch (classChoice)
                                {
                                    case 1:
                                        newTransport = new Transport();
                                        newTransport.Init();
                                        transportHash.Add(newTransport);
                                        PrintWait();
                                        break;
                                    case 2:
                                        newTransport = new Car();
                                        newTransport.Init();
                                        transportHash.Add(newTransport);
                                        PrintWait();
                                        break;
                                    case 3:
                                        newTransport = new Train();
                                        newTransport.Init();
                                        transportHash.Add(newTransport);
                                        PrintWait();
                                        break;
                                    case 4:
                                        newTransport = new Express();
                                        newTransport.Init();
                                        transportHash.Add(newTransport);
                                        PrintWait();
                                        break;
                                    case 5:
                                        break;
                                }
                                break;

                            // ДСЧ
                            case 2:
                                Console.Write("Введите количество элементов: ");
                                int num = UsefulFunct.InputPositiveInt();
                                
                                if (num > transportHash.Size - transportHash.Count)
                                {
                                    Console.WriteLine($"Невозможно добавить {num} элементов. Доступно мест: {transportHash.Size - transportHash.Count}");
                                    PrintWait();
                                    break;
                                }
                                
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int randomClassChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                for (int i = 0; i < num; i++)
                                {
                                    Transport randomTransport;
                                    switch (randomClassChoice)
                                    {
                                        case 1:
                                            randomTransport = new Transport();
                                            randomTransport.RandomInit();
                                            transportHash.Add(randomTransport);
                                            break;
                                        case 2:
                                            randomTransport = new Car();
                                            randomTransport.RandomInit();
                                            transportHash.Add(randomTransport);
                                            break;
                                        case 3:
                                            randomTransport = new Train();
                                            randomTransport.RandomInit();
                                            transportHash.Add(randomTransport);
                                            break;
                                        case 4:
                                            randomTransport = new Express();
                                            randomTransport.RandomInit();
                                            transportHash.Add(randomTransport);
                                            break;
                                        case 5:
                                            break;
                                    }
                                }
                                break;
                            case 3:
                                break;
                        }
                        break;
                    // Поиск элемента
                    case 3:
                        Console.WriteLine("Поиск элемента");
                        Transport searchTransport = new Transport();
                        searchTransport.Init();
                        transportHash.Find(searchTransport);
                        PrintWait();
                        break;
                    // Удаление элемента
                    case 4:
                        Console.WriteLine("Удаление элемента");
                        Transport deleteTransport = new Transport();
                        deleteTransport.Init();
                        transportHash.Remove(deleteTransport);
                        PrintWait();
                        break;
                    // Очистка
                    case 5:
                        transportHash.Clear();
                        PrintWait();
                        break;
                    // Выход
                    case 6:
                        isRunning = false;
                        break;
                }
            }
        }

        static void ManageGenericCollection()
        {
            Console.Write("Введите размер хеш-таблицы: ");
            int size = UsefulFunct.InputPositiveInt();
            Console.Clear();
            bool isRunning = true;
            HashTableChain<Transport> collection = new(size);

            while (isRunning)
            {
                Console.WriteLine($"Работа с хеш-таблицей (метод цепочек)");
                DisplayMenu(HashChainOperations);
                int choice = UsefulFunct.InputIntFromDiaposon(1, 9);
                PrintWait();

                switch (choice)
                {
                    // Печать
                    case 1:
                        collection.Print();
                        PrintWait();
                        break;
                    // Добавление элемента
                    case 2:
                        Console.WriteLine("Добавление элемента");
                        DisplayMenu(AddOperations);
                        int addChoice = UsefulFunct.InputIntFromDiaposon(1, 3);
                        PrintWait();

                        switch (addChoice)
                        {
                            // Вручную
                            case 1:
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int classChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                Transport newTransport;
                                switch (classChoice)
                                {
                                    case 1:
                                        newTransport = new Transport();
                                        newTransport.Init();
                                        collection.Add(newTransport);
                                        break;
                                    case 2:
                                        newTransport = new Car();
                                        newTransport.Init();
                                        collection.Add(newTransport);
                                        break;
                                    case 3:
                                        newTransport = new Train();
                                        newTransport.Init();
                                        collection.Add(newTransport);
                                        break;
                                    case 4:
                                        newTransport = new Express();
                                        newTransport.Init();
                                        collection.Add(newTransport);
                                        break;
                                }
                                break;

                            // ДСЧ
                            case 2:
                                Console.Write("Введите количество элементов: ");
                                int num = UsefulFunct.InputPositiveInt();
                                
                                Console.WriteLine("Выберите тип элемента");
                                DisplayMenu(ChoiceClass);
                                int randomClassChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                                PrintWait();

                                for (int i = 0; i < num; i++)
                                {
                                    Transport randomTransport;
                                    switch (randomClassChoice)
                                    {
                                        case 1:
                                            randomTransport = new Transport();
                                            randomTransport.RandomInit();
                                            collection.Add(randomTransport);
                                            break;
                                        case 2:
                                            randomTransport = new Car();
                                            randomTransport.RandomInit();
                                            collection.Add(randomTransport);
                                            break;
                                        case 3:
                                            randomTransport = new Train();
                                            randomTransport.RandomInit();
                                            collection.Add(randomTransport);
                                            break;
                                        case 4:
                                            randomTransport = new Express();
                                            randomTransport.RandomInit();
                                            collection.Add(randomTransport);
                                            break;
                                    }
                                }
                                break;

                            case 3:
                                break;
                        }
                        PrintWait();
                        break;
                    // Поиск элемента
                    case 3:
                        if (collection.Count == 0)
                        {
                            Console.WriteLine("Коллекция пуста");
                            PrintWait();
                            break;
                        }
                        Console.WriteLine("Выберите элемент для поиска");
                        DisplayMenu(ChoiceClass);
                        int searchChoice = UsefulFunct.InputIntFromDiaposon(1, 5);
                        PrintWait();

                        Transport searchTransport;
                        switch (searchChoice)
                        {
                            case 1:
                                searchTransport = new Transport();
                                searchTransport.Init();
                                HandleFoundItem(collection.Find(searchTransport), collection);
                                break;
                            case 2:
                                searchTransport = new Car();
                                searchTransport.Init();
                                HandleFoundItem(collection.Find(searchTransport), collection);
                                break;
                            case 3:
                                searchTransport = new Train();
                                searchTransport.Init();
                                HandleFoundItem(collection.Find(searchTransport), collection);
                                break;
                            case 4:
                                searchTransport = new Express();
                                searchTransport.Init();
                                HandleFoundItem(collection.Find(searchTransport), collection);
                                break;
                        }
                        PrintWait();
                        break;
                    // Глубокое клонирование
                    case 4:
                        var deepClone = collection.DeepClone();
                        Console.WriteLine("Создана глубокая копия. Оригинал:");
                        collection.Print();
                        Console.WriteLine("\nКопия:");
                        deepClone.Print();
                        PrintWait();
                        break;
                    // Поверхностное копирование
                    case 5:
                        var shallowCopy = collection.ShallowCopy();
                        Console.WriteLine("Создана поверхностная копия. Оригинал:");
                        collection.Print();
                        Console.WriteLine("\nКопия:");
                        shallowCopy.Print();
                        PrintWait();
                        break;
                    // Перебор в foreach
                    case 6:
                        Console.WriteLine("Перебор элементов в foreach:");
                        foreach (var pair in collection)
                        {
                            Console.WriteLine(pair.Value);
                        }
                        PrintWait();
                        break;
                    // Очистка
                    case 7:
                        collection.Clear();
                        Console.WriteLine("Коллекция очищена");
                        PrintWait();
                        break;
                    // Выход
                    case 8:
                        isRunning = false;
                        break;
                }
            }
        }

        static void HandleFoundItem(Transport? foundItem, HashTableChain<Transport> collection)
        {
            if (foundItem != null)
            {
                Console.WriteLine($"Найден элемент: {foundItem}");
                Console.Write("Хотите удалить этот элемент? (1 - да, 2 - нет): ");
                if (UsefulFunct.InputIntFromDiaposon(1, 2) == 1)
                {
                    collection.Remove(foundItem);
                    Console.WriteLine("Элемент удален");
                }
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }
        }

        static void PrintWait()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}