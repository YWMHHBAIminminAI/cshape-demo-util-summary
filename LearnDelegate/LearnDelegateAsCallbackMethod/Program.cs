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

        Logger logger = new Logger();
        Action<Employee> log = new Action<Employee>(logger.Log);


        //调用以委托为底的模板方法
        Department departmentForTom = registryFactory.RegistryEmployee(funcToTom, log);
        Department departmentForRose = registryFactory.RegistryEmployee(funcToRose, log);

        Console.WriteLine(departmentForTom.Employee.Name);
        Console.WriteLine(departmentForRose.Employee.Name);
    }
}
/**
 * Logger这个类用来记录程序的运行状态，所有程序中这个Logger类一般很常见，因为是记录程序状态也因此没有返回值
 */
class Logger
{
    public void Log(Employee employee)
    {
        Console.WriteLine("Employee '{0}' outputed at {1}. Weight is {2}.",employee.Name, DateTime.UtcNow, employee.Weight);
    }
}
class Employee
{
    public string Name { get; set; }
    public double Weight { get; set; }
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
     * 使用模板方法的好处就是：哪怕有老员工走新员工来，我的Employee、Department、RegistryEmployee都不用再改动了。我只需要去改动EmployeeFactory，在EmployeeFactory里面增删要输出的员工，就可以实现各种各样员工的注册，boss就能实时掌握员工信息的流动过程了。最大限度提高了代码复用程度，提高效率减少bug
     */
    public Department RegistryEmployee(Func<Employee> getEmployee, Action<Employee> logCallback)
    {
        Department department = new Department();
        Employee employee = getEmployee.Invoke();//形参中的委托类型返回值就是Employee，所以我们肯定能拿到一个Employee的对象

        /**
         * 此时设置的log回调函数调用的逻辑是：如果体重大于200，咱们就要log一下
         */
        if(employee.Weight >= 200)
        {
            logCallback(employee);
        }

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
        employee.Weight = 150;
        return employee;
    }
    
    public Employee RegistryEmployeeRose()
    {
        Employee employee = new Employee();
        employee.Name = "Rose";
        employee.Weight = 220;
        return employee;
    }
}
