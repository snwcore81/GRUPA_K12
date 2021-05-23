using GRUPA_K12.Classes.System;
using GRUPA_K12.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace GRUPA_K12.Classes
{
    public static class XmlStorageTypes
    {
        private static readonly List<Type> KnownTypes = new List<Type>();
        static XmlStorageTypes()
        {
            using var _log = Log.DEB("XmlStorageTypes", "XmlStorageTypes");

            Register<object>();
            Register<Exception>();

            foreach (var _type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!_type.IsGenericType)
                {
                    foreach (var _attr in _type.GetCustomAttributes())
                    {
                        if (_attr.GetType() == typeof(DataContractAttribute))
                        {
                            Register(_type);
                            break;
                        }
                    }
                }
            }
        }

        public static void Initialize()
        {
            using var _log = Log.DEB("XmlStorageTypes", "Initialize");
        }
        
        public static void Register(Type _oType)
        {
            using var _log = Log.DEB("XmlStorageTypes", "Register");

            if (!KnownTypes.Contains(_oType))
            {
                _log.PR_DEB($"Register:{_oType.Name}");

                KnownTypes.Add(_oType);
            }
        }

        public static void Register<T>()
        {
            Register(typeof(T));
        }

        public static Type[] GetArray() => KnownTypes.ToArray();
    }

    [DataContract]
    public abstract class XmlStorage<T> : IXmlStorage where T : class
    {
        [IgnoreDataMember]
        public T BaseObject { get; protected set; }
        
        public virtual bool FromXml(Stream a_oStream)
        {
            DataContractSerializer _oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var _oReader = XmlDictionaryReader.CreateTextReader(a_oStream, new XmlDictionaryReaderQuotas());            

            return InitializeFromObject((T)_oSerializer.ReadObject(_oReader, false));
        }

        public virtual MemoryStream ToXml()
        {
            DataContractSerializer _oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var _oStream = new MemoryStream();

            using var _oWriter = XmlDictionaryWriter.CreateTextWriter(_oStream, Encoding.UTF8);

            _oSerializer.WriteObject(_oWriter, this);

            return _oStream;            
        }

        public abstract bool InitializeFromObject(T Object);
    }
}
