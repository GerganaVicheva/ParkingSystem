# Parking System
Това е интелигентна система за оптимизирано паркиране.
## Цели на проекта
Проектът симулира работещ паркинг, който използва конзолното приложение като начин за оптимизация и избягване на грешки. Целта на приложението е автоматизирана система за управление на паркирането.
## Решение
Основна функционалност:
1. Избор на място за паркиране -
   Потребителите могат да видят списък с паркоместа и текущото им състояние - свободни/заети, от кого са заети и кога ще бъдат освободени.
   
2. Резервиране на място за паркиране -
   Потребителите избират опция за резервация (OnDemand, Advance, Subscription), както и продължителността на резервацията. Методът за идентификация е чрез регистрационния номер на автомобила.

3. Опции за резервация - Потребителите могат да резервират паркомясто за определен период от време според 3 опции:
- Advance/Предварителна резервация: До 1 седмица преди началото на резервацията потребителите могат да резервират желано паркомясто за период от 1 ден до 1 седмица.
- OnDemand/Резервация на момента: Потребителите могат да резервират желано паркомясто от 1 час до целия ден, а ако резервират през уикенда, могат да останат за период от 1 час до края на уикенда (събота и неделя).
- Subscription/Абонамент: Потребителите могат да поискат месечен абонамент в сила от момента на запазване с продължителност 30 дни. При изтичане на абонамента паркомястото се освобождава.

4. Освобождаване на паркомясто -
   Потребителите имат възможност да напуснат паркинга по-рано (без абонамент) и да получат възстановяване на 70% от останалата сума.

5. Ценоразпис на резервациите - Важат следните цени на резервациите:
- Резервация на момента: 1 лв. на час.
- Предварителна резервация 2 или повече дни преди датата на ползване: 1.20 лв. на час
- Предварителна резервация 1 ден преди датата на ползване: 1 лв. на час.
- Абонамент: 168 лв. на месец.

### Програмата
Програмата има 5 основни класа:
- ParkingSpot
- ParkingReservation
- ParkingLot
- Actions
- Program

1. ParkingSpot:
Съдържа основните характеристики, които има всяко паркомясто:
ID/име (напр. A1), проверка дали мястото е заето или не, ID (регистрационен номер) на превозното средство, което заема мястото, време, до което мястото е запазено.

![ParkingSpot](https://github.com/GerganaVicheva/ParkingSystem/assets/173889883/0d104f84-7813-47e9-8151-0cc71001337e) 

2. ParkingReservation:
Съдържа основните свойства, които има всяка резервация:
ID/име на запазеното място, ID (регистрационен номер) на автомобила, използващ мястото, период на използване на мястото, тип резервация. Тук е капсулацията на всяко свойство, което класът има, и метод, който проверява дали входът отговаря на условията на типа резервация.

![ParkingReservation](https://github.com/GerganaVicheva/ParkingSystem/assets/173889883/14aaa4dc-e53f-4ed4-b1a4-7c8cc075fd50)


3. ParkingLot:
Създава паркинг със списък от места и списък с резервации. Тук са сновните дейности, които приложението извършва - методи за запазване и освобождаване на място, метод, който сумира всички приходи, както и списък с резервации в зависимост от периода.

![ParkingLot](https://github.com/GerganaVicheva/ParkingSystem/assets/173889883/36316cad-5f65-46f8-be3c-2bf1ef297de0)


4. Actions:
В този клас има 2 основни метода - HandleUserActions и HandleAdminActions. Те извикват другите функции в класа - BookSpotInterface, ReleaseSpotInterface, ViewReservations, ViewEarnings. Всички функции представляват това, което потребителят ще види.

![Actions](https://github.com/GerganaVicheva/ParkingSystem/assets/173889883/cc40576e-289b-41c5-b93b-456b1d86282b)


5. Program: 
Комуникира с потребителя и изпълнява зададените от него команди.

![Main](https://github.com/GerganaVicheva/ParkingSystem/assets/173889883/bf701e68-093b-47de-8a6f-a4f5b10d3112)

### Интересни технологии, използвани в проекта:
- клас DateTime
- клас TimeSpan
- Nullable value types T?
- Тернарен оператор ?:
- Ламбда изрази
- StringComparison Enum
- IQueryable Interface
