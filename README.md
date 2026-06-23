 1. Coding Principles (Short Answer)
Describe two coding principles or practices you consider most important when working on real Unity projects that mix:
• 3D gameplay
• UI systems
• Iteration by designers
Explain why they matter and where you apply them.
1) Принцип единной ответственности классы и сущности которые мы создают должны нести тот функционал ради которого они созданные, если не придерживатся этого правила то тогда ответственности будут размы взаимодействие не логичным
2) Принцип постановки лисков , наследники не должны переопределять логику родителя, это создает путаницу при большом наследовании и это становиться сложно поддерживать 

3.1 Unity Components Question
Which Unity components would you use to build the popup prefab, and why?

1)Canvas, EventSystem без них в принципе функционального окна не получится
2)Вертикальная или горизонтальная группа для упорядочивания объектов.
3)Ссылка на сам RectTransform родителя что-бы вложить туда окно
4)Камера для отображения UI 
