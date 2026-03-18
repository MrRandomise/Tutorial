# 🎮 Unity Pro — Обучающий проект (Otus.ru)

[![Unity](https://img.shields.io/badge/Unity-2021.3.7f1-black?logo=unity)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-239120?logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-BSD%202--Clause-blue.svg)](LICENSE)
[![Course](https://img.shields.io/badge/Course-Otus.ru%20Unity%20Professional-orange)](https://otus.ru/)

> **Учебный проект** в рамках курса [Otus Unity Professional](https://otus.ru/).  
> В проекте реализована полноценная система обучения (tutorial system) для мобильной игры с продвинутой архитектурой.

---

## 📋 О проекте

Проект представляет собой полнофункциональную мобильную игру жанра **action-RPG**, разработанную в процессе прохождения профессионального курса по Unity. Основная задача — изучение и практическое применение архитектурных паттернов, используемых в коммерческой разработке игр.

**Ключевые достижения:**
- Разработана **система обучения (Tutorial System)** с пошаговыми заданиями и отслеживанием прогресса
- Реализована **слоистая архитектура** приложения с чётким разделением ответственностей
- Применено **27 уроков** по архитектурным паттернам с практическими заданиями
- Создан полный игровой цикл: от загрузки ресурсов до мета-игрового прогресса

---

## 🚀 Технологии и инструменты

| Категория | Технологии |
|-----------|-----------|
| **Движок** | Unity 2021.3.7f1, URP (Universal Render Pipeline 12.1.7) |
| **Язык** | C# (.NET), ~1900+ файлов исходного кода |
| **Архитектура** | MVP, MVO, MVC, DI (Dependency Injection), ECS, Facade |
| **Анимация** | DOTween, Cinemachine 2.8.6, Timeline 1.6.4 |
| **UI** | TextMeshPro 3.0.6, UGUI, кастомные Window-системы |
| **Хранение данных** | Easy Save 3, SQLite3 |
| **Асинхронность** | UniTask, Asyncoroutine |
| **Адресация ресурсов** | Unity Addressables 1.19.19 |
| **Монетизация** | Unity Purchasing 4.2.1 |
| **Аналитика** | GameAnalytics, Firebase |
| **Редактор** | Odin Inspector (Sirenix) |
| **Тестирование** | Unity Test Framework |

---

## 🏗️ Архитектура

### Жизненный цикл игры

Проект использует строгую state-машину для управления жизненным циклом:

```
OFF → CONSTRUCT → INIT → READY → PLAY ⇄ PAUSE → FINISH
```

### Интерфейсы жизненного цикла (`IGameElement`)

```csharp
IGameConstructElement  // Разрешение зависимостей
IGameInitElement       // Инициализация начального состояния
IGameReadyElement      // Подготовка к запуску
IGameStartElement      // Начало игрового процесса
IGamePauseElement      // Пауза / возобновление
IGameFinishElement     // Завершение игры
IGameUpdateElement     // Per-frame логика
```

Классы реализуют только нужные интерфейсы — принцип разделения интерфейсов (ISP из SOLID).

### Паттерн GameFacade + GameContext

```csharp
// Регистрация и получение сервисов
gameFacade.RegisterService(new AudioService());
var audio = gameFacade.GetService<IAudioService>();

// Управление жизненным циклом
gameFacade.ConstructGame();
gameFacade.InitGame();
gameFacade.ReadyGame();
gameFacade.StartGame();
```

---

## 🎓 Система обучения (Tutorial System)

Ключевая разработка проекта — **пошаговая система обучения**, которая ведёт нового игрока через механики игры.

### Шаги Tutorial

| Шаг | Описание |
|-----|---------|
| `WELCOME` | Приветствие и знакомство с интерфейсом |
| `HARVEST_RESOURCE` | Сбор ресурсов на карте |
| `CONVERT_RESOURCE` | Переработка ресурсов на конвейере |
| `TAKE_RESOURCE` | Получение переработанных ресурсов |
| `SELL_RESOURCE` | Продажа ресурсов торговцу |
| `UPGRADE_HERO` | Прокачка персонажа |
| `DESTROY_ENEMY` | Уничтожение противников |
| `COMPLETE_QUEST` | Выполнение квеста |

### Архитектура Tutorial

```
Assets/Game/Tutorial/
├── Core/          # TutorialManager, TutorialStep, TutorialList
├── App/           # Интеграция с игровым lifecycle
├── Content/       # ScriptableObjects с данными шагов
├── Gameplay/      # Игровые обработчики событий туториала
├── UI/            # Визуальные подсказки и диалоги
├── Debug/         # Отладочные инструменты
└── Addressables/  # Ассеты, загружаемые по требованию
```

---

## 📚 Учебные модули (Lessons)

Проект содержит **27 модульных уроков**, охватывающих весь спектр профессиональной разработки:

### Архитектура и паттерны
- `Lesson1_Entry` — Точка входа, Bootstrap
- `Lesson2_SOLID` — Принципы SOLID
- `Lesson3_GRASP` — Паттерны GRASP
- `Lesson4_GameSystem` — Игровые системы
- `Lesson5_DI` — Dependency Injection

### UI-архитектура
- `Lesson_MVP` — Model-View-Presenter
- `Lesson_MVO` — Model-View-Observer
- `Lesson_MVA` — Model-View-Adapter
- `Lesson_PM` / `Lesson_PresentationModel` — Presentation Model
- `Lesson_Declarative` — Декларативные UI-паттерны

### Продвинутые темы
- `Lesson_Mechanics` — Игровые механики
- `Lesson_SaveLoad` — Сохранение и загрузка
- `Lesson_Loading` — Асинхронная загрузка сцен
- `Lesson_App` — Архитектура приложения
- `II.Gameplay`, `III.MetaGame`, `IV.AI`, `V.Plugins` — Продвинутые системы

---

## 🗂️ Структура проекта

```
Assets/
├── Game/                  # Основная игра (~984 C#-файла)
│   ├── App/               # Слой приложения (сервисы, менеджеры)
│   ├── GameEngine/        # Движок: таймер, пауза, ресурсы
│   ├── Gameplay/          # Геймплей: герой, враги, квесты
│   ├── Meta/              # Мета-игра: прогрессия, магазин
│   ├── Rendering/         # Визуальные эффекты
│   ├── Tutorial/          # ⭐ Система обучения
│   └── UI/                # Интерфейс пользователя
├── Lessons/               # Учебные модули (~489 C#-файлов)
├── Modules/               # Переиспользуемые модули (~408 C#-файлов)
│   ├── AI/                # Искусственный интеллект
│   ├── DialogueSystem/    # Система диалогов
│   ├── GameSystem/        # GameContext, IGameElement
│   ├── Localization/      # Локализация
│   ├── Services/          # Service Locator
│   ├── Windows/           # UI Windows Manager
│   └── ...                # ещё 15+ модулей
├── Homeworks/             # Домашние задания (ECS, SaveLoad, Shooter, Runner)
└── Plugins/               # Сторонние библиотеки
```

---

## ⚙️ Ключевые подсистемы

| Подсистема | Описание |
|-----------|---------|
| **GameManagement** | Центральный оркестратор с Facade-паттерном |
| **Loading System** | Асинхронная загрузка с отслеживанием прогресса |
| **Backend / GameClient** | HTTP-запросы, авторизация, cloud save |
| **Audio Manager** | Музыкальные плейлисты, SFX |
| **Localization** | Поддержка нескольких языков |
| **Analytics** | GameAnalytics + Firebase |
| **Quest System** | Создание и отслеживание квестов |
| **Inventory** | Управление инвентарём игрока |
| **Enemy AI** | Поведение врагов с pathfinding |
| **Vendor System** | Торговля NPC, покупки |
| **Resource System** | Сбор и обработка ресурсов |

---

## 🏆 Навыки, продемонстрированные в проекте

- ✅ Проектирование архитектуры масштабируемого Unity-приложения
- ✅ Применение SOLID, GRASP, GoF паттернов в игровом контексте
- ✅ Разработка пользовательских систем на C# (Tutorial, Quest, Inventory)
- ✅ MVP/MVO/PM паттерны для UI
- ✅ Dependency Injection без сторонних фреймворков
- ✅ Entity-Component System (ECS)
- ✅ Асинхронное программирование (UniTask, Coroutines)
- ✅ Addressable Assets для управления памятью
- ✅ Интеграция Backend-сервисов (REST API)
- ✅ Аналитика и монетизация (IAP)
- ✅ Локализация мобильной игры

---

## 📖 Курс

Проект разработан в рамках курса **[Otus Unity Professional](https://otus.ru/)** — профессиональной программы для разработчиков игр, охватывающей архитектуру, паттерны, оптимизацию и публикацию мобильных игр.

