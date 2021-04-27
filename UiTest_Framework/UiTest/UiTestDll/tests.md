# мысли
* нужно ли тестировать конфиги?
* можно ли менять конфиги?


# сущности
## деревья
## игрок
## станок для переработки дерева

# деревья
1. Для рубки дерева в инвентаре должен присутствовать топор
2a. При входе в область дерева, иконка действия становится активной.
2b. При однократном нажатии на кнопку действия рядом с деревом, игрок совершает один заруб
2. Если совершён 1 заруб, то дерево продолжает стоять.
3. Дерево срубается за 3 заруба топором.
4a. Когда дерево срублено, иконка действия становится не активной
4b. Когда игрок выходит на пределы дерева, то иконка действия становится неактивной
5. Когда игрок срубил дерево, ему добавляется 3 бревна в инвентарь.
6. 

# игрок
1. Игрок может перемещаться использую джойстик
2. При срубке дерева, фокус должен перейти на другое дерево рядом.

## инвентарь
1. окно инвентаря показывается
2. окно инвентаря закрывается
3. предметы можно удалять. Для этого надо кликнуть предмет, а потом кликнуть ведро
4. предметы можно перемещать по инвентарю
6. предметы типа ресурсов стакаются вместе
7. нельзя взять предметы, если инвентарь заполнен
8. Максимальный размер стака для материалов - 20.
9. Предмет можно положить в любой слот инвентаря.
11. 


# станок
1. окно станка открывается
2. окно станка закрывается
3. в станок можно поместить дерево для обработки, в левый слот
4. можно забрать дерево во время обработки, тогда процесс прервётся
5. дерево, помещённое для обработки, будет обработано. Обработанное дерево появится в правом слоте
6. обработку можно ускорить, использовав монеты. Монеты должны находится в инвентаре. Тратится 5 монет на ускорение
7. нельзя ускорить обработку, если не хватает монет
8. Обрабатываться должны только материалы ресурсов, например брёвна. Монеты, инструменты и другие подобные предметы не должны отрабатываться, хотя их можно положить в левый слот
9. Предметы должны обрабатываться только по схемам. Если сначала заполнить правый слот монетами, а потом в левый положить брёвна, то обработка не должна начаться.
10. Правый слот должен быть свободным, или иметь такой же тип предмета, который должен получится в конце обработки, чтобы обработка прошла успешно. Если положить в левый слот брёвна то начнётся обработка. Сразу же надо положить в правый слот инструмент (например топор), тогда обработка должна прерваться. При этом Если убрать инструмент из правого слота, то обработка должна продолжиться. 
11. Предметы в слотах можно заменять в любой момент времени. Если заменить предмет по время обработки дерева на неподходящий предмет, то обработка должна прерваться.
12. Обработку можно предвать. Начать обработку бревна и через секунду 
13. Когда правый слот заполняется максимальным размером стака нужного предмета, то обработка дальше не идёт.
14. Ускорение должно работать только если есть предмет в левом слоте и этот предмет обрабатывается.
15. Прогресс обработки показывается
16. 


# баги (поставить приоритеты)
2. Деревья рубятся без топора. При этом иконка действия не активна, но на неё можно нажать, дерево будет рубиться и срубится, как если бы в инветаре был топор.
3. Станок для обработки дерева не правильно учитывает предметы в правом слоте. Если положить в правый слот монеты, а потом в левый слот положить брёвна, то бревно обработается в монету. Critical
4. В инвентаре не подсвечивается выбранный предмет.
5. При ускорении обработки дерева прогресс обработки не сбрасывается.
6. (спорно, надо обсуждать) При попадании стакающегося предмета в инвентарь предмет кладётся в отдельный слот. Уже находящийся предмет должен быть помещён не в первую свободную ячейку.
7. Иногда дерево не срубается по окончанию рубки.
8. Ускорениу обработки дерева работает даже если не хватает монет. При этом монеты в инвентаре уходят в минус.
9. В некоторые слоты инвентаря нельзя положить предметы. Нельзя положить в 4 слота: [[0,1],[0,2],[1,1],[1,2]]
10. Окно инвентаря не закрывается. Blocker!
11. Пропадают предметы из инвентаря после перетаскивания в другой слот. А потом не закрывается окно инвентаря.
12. В конфиге спрайтов нету иконок, которые в ТЗ. !НЕ CellFrame
    - tool_hatchet_iron
    - Icon_Coin
    - res_wood_1
    - res_plank_1
13. Чит CellSearchByIcon не работает - вываливает NullReferenceException, когда передаём Context.Commands.CellSearchByIconCommand("tool", "1", new HashSet<string>() {"inventory_count"}, result);

Каюсь, почти для всех багов нашёл рут козы, в основном через изучение декомпилированного кода клиента.


# улучшение фреймворка
1. Зарефакторить Commands.cs: вынести куда-нибудь повторяющиеся действия (идеально вынести всё что до и после Run выполняться в коде команде, но тогда хз как лучше поступить в контекстом, чтобы логи писать), CommandsId можно, например, генерить через рефлексию.
2. log.txt переименовать в result.txt
3. Некоторые тестовые команды можно сделать обычными методами, потому что внутри они не используют yield return
4. 