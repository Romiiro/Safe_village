/// <summary>
/// Интерфейс для классов зависимых от количества ресурсов.
/// </summary>
public interface IResCountDependency {
    public void OnChangeResValue();
}