namespace CommonBasicLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
public static class Enums
{
    extension<TEnum>(TEnum first)
    {
        //if i ever had to combine flags, can do.
        public TEnum CombineFlags(params List<TEnum> others)
        {
            ulong flags = Convert.ToUInt64(first);

            foreach (TEnum item in others)
            {
                flags |= Convert.ToUInt64(item);
            }

            return (TEnum)Enum.ToObject(typeof(TEnum), flags);
        }
    }
}
