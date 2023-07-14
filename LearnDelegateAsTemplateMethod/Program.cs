using System.Security.AccessControl;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, delegate knowledge!");
        EmployeeFactory employeeFactory = new EmployeeFactory();
        RegistryFactory registryFactory = new RegistryFactory();

        //定义委托
        Func<Employee> funcToTom = new Func<Employee>(employeeFactory.RegistryEmployeeTom);
        Func<Employee> funcToRose = new Func<Employee>(employeeFactory.RegistryEmployeeRose);

        //调用以委托为底的模板方法
        Department departmentForTom = registryFactory.RegistryEmployee(funcToTom);
        Department departmentForRose = registryFactory.RegistryEmployee(funcToRose);

        Console.WriteLine(departmentForTom.Employee.Name);
        Console.WriteLine(departmentForRose.Employee.Name);
    }
}

class Employee
{
    public string Name { get; set; }
}

class Department
{
    public Employee Employee { get; set; }
}

/**
 * RegistryFactory负责将员工的信息等级在各个部门,交给boss
 */
class RegistryFactory
{
    /**
     * RegistryEmployee是一个模板方法，RegistryEmployee这个模板方法接收一个委托类型的参数，此处咱们选择Func委托，并且这个Func委托封装的方法能够返回一个Employee类型的对象
     * RegistryEmployee这个模板方法的主要逻辑就是：先准备一个部门，然后通过invoke()调用委托获取一个员工，然后把获取的员工注册到部门中，然后返回部门
     * 使用模板方法的好处就是：哪怕有老员工走新员工来，我的Employee、Department、RegistryEmployee都不用再改动了。我只需要去改动EmployeeFactory，在EmployeeFactory里面增删要输出的员工，就可以实现各种各样员工的注册，boss就能实时掌握员工信息的流动过程了。最大限度提高了代码复用程度，提高效率减少bug，
     */
    public Department RegistryEmployee(Func<Employee> getEmployee)
    {
        Department department = new Department();
        Employee employee = getEmployee.Invoke();//形参中的委托类型返回值就是Employee，所以我们肯定能拿到一个Employee的对象
        department.Employee = employee;
        return department;
    }
}

/**
 * 用于输出各个新员工的工厂
 */
class EmployeeFactory
{
    public  Employee RegistryEmployeeTom()
    {
        Employee employee = new Employee();
        employee.Name = "Tom";
        return employee;
    }
    
    public Employee RegistryEmployeeRose()
    {
        Employee employee = new Employee();
        employee.Name = "Rose";
        return employee;
    }
}
