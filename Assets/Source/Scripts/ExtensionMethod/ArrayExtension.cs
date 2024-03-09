using System;

[Serializable]
public static class ArrayExtensions
{
    public static T[] Add<T>(this T[] source, T item)
    {
        if (source == null)
        {
            return new T[] { item };
        }

        T[] result = new T[source.Length + 1];
        source.CopyTo(result, 0); 
        result[source.Length] = item; 
        return result;
    }
}
