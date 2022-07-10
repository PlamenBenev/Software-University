using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy : Hacker
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType , new object[] {});

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var item in classFields.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
