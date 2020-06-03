using DevExpress.Xpo.Metadata;
using NB.Core.Model;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NB.Core.Controller.DxSampleModelCode
{
    public class DxSampleModelJsonSerializationContractResolver : DefaultContractResolver
    {
        public bool SerializeCollections { get; set; } = false;
        public bool SerializeReferences { get; set; } = true;
        public bool SerializeByteArrays { get; set; } = true;

        readonly XPDictionary dictionary;

        public DxSampleModelJsonSerializationContractResolver()
        {
            dictionary = new ReflectionDictionary();
            dictionary.GetDataStoreSchema(new Type[]
            {
                typeof(Task),
                typeof(EventLog)
            });
        }

        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            XPClassInfo classInfo = dictionary.QueryClassInfo(objectType);

            if (classInfo != null && classInfo.IsPersistent)
            {
                var allSerializableMembers = base.GetSerializableMembers(objectType);
                var serializableMembers = new List<MemberInfo>(allSerializableMembers.Count);

                foreach (MemberInfo member in allSerializableMembers)
                {
                    XPMemberInfo mi = classInfo.FindMember(member.Name);
                    if (!(mi.IsPersistent || mi.IsAliased || mi.IsCollection || mi.IsManyToManyAlias)
                        || ((mi.IsCollection || mi.IsManyToManyAlias) && !SerializeCollections)
                        || (mi.ReferenceType != null && !SerializeReferences)
                        || (mi.MemberType == typeof(byte[]) && !SerializeByteArrays))
                    {
                        continue;
                    }
                    serializableMembers.Add(member);
                }
                return serializableMembers;
            }
            return base.GetSerializableMembers(objectType);
        }
    }
}
