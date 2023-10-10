while True:
    x1 = float(input('Введите первое число: '))
    x2 = float(input('Введите второе число: '))
    deistvie = input('Введите знак действия(+ - * /): ')
    if deistvie == '+':
        x = x1 + x2
        print(x)
    elif deistvie == '-':
        x = x1 - x2
        print(x)
    elif deistvie == '*':
        x = x1 * x2
        print(x)
    elif deistvie == '/':
        x = x1 / x2
        okrug = 0
        while okrug > 2 or okrug < 1:
            okrug = int(input('Округлить число? 1)Да 2)Нет: '))
            if okrug == 1:
                x = round(x)
        print(x)
    else:
        print('Неверный знак')
