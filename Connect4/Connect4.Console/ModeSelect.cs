using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Console
{
    class ModeSelect
    {
        public static Mode SelectMode()
        {
            while (true)
            {
                System.Console.WriteLine("-- Select Mode --");
                Enum.GetNames(typeof(Mode)).ToList().ForEach(name =>
                {
                    System.Console.WriteLine("{0}: {1}", (byte)Enum.Parse(typeof(Mode), name) + 1, name.Replace('_', ' '));
                });
                var keyInput = System.Console.ReadKey();

                byte keyIndex = (byte)(keyInput.KeyChar - '0' - 1);
                byte[] values = Enum.GetValues(typeof(Mode)).Cast<byte>().ToArray();

                int index = Array.IndexOf<byte>(values, keyIndex);
                if (index != -1)
                    return (Mode)Enum.Parse(typeof(Mode), keyIndex.ToString());
                else
                {
                    System.Console.Clear();
                    System.Console.WriteLine("-- Invalid Selection --");
                }
            }
        }
    }
}
