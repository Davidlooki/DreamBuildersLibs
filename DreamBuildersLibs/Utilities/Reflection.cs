using System.Reflection;

namespace DreamBuildersLibs;

public static class Reflection
{
    private const BindingFlags _FLAGS = BindingFlags.Instance | BindingFlags.Static |
                                        BindingFlags.NonPublic | BindingFlags.Public |
                                        BindingFlags.DeclaredOnly;

    public static IEnumerable<FieldInfo> GetAllFields(this object target, Func<FieldInfo, bool> predicate)
    {
        List<Type> types = GetSelfAndBaseTypes(target);

        for (int i = types.Count - 1; i >= 0; i--)
        {
            IEnumerable<FieldInfo> fieldInfos = types[i]
                .GetFields(_FLAGS)
                .Where(predicate);

            foreach (FieldInfo fieldInfo in fieldInfos)
                yield return fieldInfo;
        }
    }

    public static IEnumerable<PropertyInfo> GetAllProperties(this object target, Func<PropertyInfo, bool> predicate)
    {
        List<Type> types = GetSelfAndBaseTypes(target);

        for (int i = types.Count() - 1; i >= 0; i--)
        {
            IEnumerable<PropertyInfo> propertyInfos = types[i]
                .GetProperties(_FLAGS)
                .Where(predicate);

            foreach (PropertyInfo? propertyInfo in propertyInfos)
                yield return propertyInfo;
        }
    }

    public static IEnumerable<MethodInfo> GetAllMethods(this object target, Func<MethodInfo, bool> predicate)
    {
        List<Type> types = GetSelfAndBaseTypes(target);

        for (int i = types.Count - 1; i >= 0; i--)
        {
            IEnumerable<MethodInfo> methodInfos = types[i]
                .GetMethods(_FLAGS)
                .Where(predicate);

            foreach (MethodInfo methodInfo in methodInfos)
                yield return methodInfo;
        }
    }

    public static bool TryGetField(this object target, string fieldName, out FieldInfo? fieldInfo)
    {
        fieldInfo = GetAllFields(target, f =>
                f.Name.Equals(fieldName, StringComparison.Ordinal))
            .FirstOrDefault();

        return fieldInfo != null;
    }

    public static bool TryGetProperty(this object target, string propertyName, out PropertyInfo? propertyInfo)
    {
        propertyInfo = GetAllProperties(target, p =>
                p.Name.Equals(propertyName, StringComparison.Ordinal))
            .FirstOrDefault();

        return propertyInfo != null;
    }

    public static bool TryGetMethod(this object target, string methodName, out MethodInfo? methodInfo)
    {
        methodInfo = GetAllMethods(target, m =>
                m.Name.Equals(methodName, StringComparison.Ordinal))
            .FirstOrDefault();

        return methodInfo != null;
    }

    public static Type? GetListElementType(this Type listType) =>
        listType.IsGenericType ? listType.GetGenericArguments()[0] : listType.GetElementType();

    /// <summary>
    ///		Get type and all base types of target, sorted as following:
    ///		<para />[target's type, base type, base's base type, ...]
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static List<Type> GetSelfAndBaseTypes(this object target)
    {
        List<Type> types = new() { target.GetType() };

        while (types.Last().BaseType != null)
            types.Add(types.Last().BaseType);

        return types;
    }
}