using System.Reflection;

namespace PhoneBook
{
    internal static class ProgramInfo
    {
        public static string AssemblyGuid
        {
            get
            {
                var attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;
            }
        }
    }
}