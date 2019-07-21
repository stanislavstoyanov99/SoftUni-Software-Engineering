using System;
using System.Linq;
using System.Text;
using System.Reflection;

public class Spy
{
    public string StealFieldInfo(string className, params string[] classFields)
    {
        Type type = Type.GetType(className);

        FieldInfo[] fields = type.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Static);

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(type, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        var filteredFields = fields
            .Where(f => classFields.Contains(f.Name))
            .ToList();

        foreach (FieldInfo field in filteredFields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type type = Type.GetType(className);

        FieldInfo[] classFields = type.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.Static);

        MethodInfo[] classPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        var filteredNonPublicMethods = classNonPublicMethods
            .Where(m => m.Name.StartsWith("get"))
            .ToList();

        foreach (MethodInfo method in filteredNonPublicMethods)
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        var filteredPublicMethods = classPublicMethods
            .Where(m => m.Name.StartsWith("set"))
            .ToList();

        foreach (MethodInfo method in filteredPublicMethods)
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }


        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);

        MethodInfo[] classMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);

        MethodInfo[] classMethods = type.GetMethods(
            BindingFlags.Instance | 
            BindingFlags.Public | 
            BindingFlags.NonPublic);

        var classGetters = classMethods
            .Where(c => c.Name.StartsWith("get"))
            .ToList();

        var classSetters = classMethods
            .Where(c => c.Name.StartsWith("set"))
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (MethodInfo getter in classGetters)
        {
            sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (MethodInfo setter in classSetters)
        {
            Type setterParameterType = setter
                .GetParameters()
                .First()
                .ParameterType;

            sb.AppendLine($"{setter.Name} will set field of {setterParameterType}");
        }

        return sb.ToString().TrimEnd();
    }
}
