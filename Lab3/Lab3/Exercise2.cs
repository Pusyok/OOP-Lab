namespace Lab3;

// Задача 2. Приховування властивостей.
// Базовий клас для представлення співробітника
internal class Employee(string name, string position, decimal baseSalary)
{
    public string Name { get; set; } = name;
    public string Position { get; set; } = position;
    public decimal BaseSalary { get; set; } = baseSalary;

    // Віртуальна властивість для обчислення зарплати, яка може бути перевизначена
    public virtual decimal Salary => BaseSalary;

    // Звичайна властивість, що повертає інформацію про співробітника у вигляді рядка
    public string EmployeeInfo => $"{Name} - {Position}, Зарплата: {Salary:C}";
}

// Клас менеджера, який розширює базовий клас співробітника
internal class Manager(string name, decimal baseSalary, decimal bonus) : Employee(name, "Менеджер", baseSalary)
{
    // Додаткова властивість для бонусу менеджера
    public decimal Bonus { get; set; } = bonus;

    // Перевизначена властивість (override) - розширює логіку базового класу
    // При використанні поліморфізму буде викликатися ця версія методу
    public override decimal Salary => BaseSalary + Bonus;

    // Прихована властивість (new) - повністю замінює реалізацію базового класу
    // Доступна тільки при прямому використанні типу Manager, недоступна через поліморфізм
    public new string EmployeeInfo =>
        $"{Name} - {Position}, Базова ставка: {BaseSalary:C}, Бонус: {Bonus:C}, Загальна зарплата: {Salary:C}";
}