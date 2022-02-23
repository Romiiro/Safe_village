/// <summary>
/// Код окончания игры
/// </summary>
public enum EndGameCode {
    EndOfFood = 1,
    Defeat = 2,
    Win = 3
};

/// <summary>
/// Тип ресурсов
/// </summary>
public enum ResourceType {
    Food,
    Baker,
    Elf,
    Goblin
};

/// <summary>
/// Тип аудио дорожки
/// </summary>
public enum AudioType {
    General,
    Surround,
    Interface
}