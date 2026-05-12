using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#pragma warning disable SYSLIB0011

namespace DemoApp.Legacy.ClassicLib
{
    public static class BinaryFormatterProbe
    {
        public static byte[] SerializeInt(int value)
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, value);
                return ms.ToArray();
            }
        }
    }
}

#pragma warning restore SYSLIB0011
