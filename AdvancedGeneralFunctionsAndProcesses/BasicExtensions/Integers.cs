using CommonBasicLibraries.AdvancedGeneralFunctionsAndProcesses.Misc;
namespace CommonBasicLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
public static class Integers
{
    extension(IEnumerable<int> list)
    {
        public string Join(string delimiter)
        {
            StrCat cats = new();
            list.ForEach(x => cats.AddToString(x.ToString(), delimiter));
            return cats.GetInfo();
        }
    }
    extension(int payload)
    {
        
        public void Times(Action action)
        {
            for (var i = 0; i < payload; i++)
            {
                action?.Invoke();
            }
        }
        public void Times(Action<int> action)
        {
            for (var i = 0; i < payload; i++)
            {
                action?.Invoke(i + 1);
            }
        }
    }   
}