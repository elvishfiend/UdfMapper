using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace UdfMapper
{
    public class ReflectionMapper
    {
        public readonly Configuration.Configuration Config;

        private Dictionary<Type, IEnumerable<MemberInfo>> MappingCache = new Dictionary<Type, IEnumerable<MemberInfo>>();

        public ReflectionMapper() : this(new Configuration.Configuration())
        {
        }

        public ReflectionMapper(Configuration.Configuration config)
        {
            Config = config;
        }

        public void MapTo<T>(T srcObj, Fields fields)
        {
            IEnumerable<MemberInfo> membersToMap;
            var type = typeof(T);

            if (!MappingCache.TryGetValue(type, out membersToMap))
            {
                membersToMap = GetMembers(type).ToList();
                MappingCache.Add(type, membersToMap);
            }

            foreach (var member in membersToMap)
            {
                var field = fields.Item(member.Name);

                switch (member)
                {
                    case PropertyInfo p:
                        field.Value = p.GetValue(srcObj);
                        break;
                    case FieldInfo f:
                        field.Value = f.GetValue(srcObj);
                        break;
                }
            }
        }

        public IEnumerable<MemberInfo> GetMembers(Type t)
        {
            var type = t;
            var allMembers = type.GetMembers(
                BindingFlags.GetProperty 
                | BindingFlags.GetField 
                | BindingFlags.Public
                | BindingFlags.Instance);

            var membersToMap = allMembers.Where(x => x.Name.StartsWith(Config.UdfPrefix));
            return membersToMap;
        }
    }
}
