using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VisualLog.Attributes;

namespace VisualLog.GraphCreators.AttributeBased
{
    internal class ReflectedObject : IObjectDescriptor, IEquatable<ReflectedObject>
    {
        public override int GetHashCode()
        {
            return (_object != null ? _object.GetHashCode() : 0);
        }

        private readonly object _object;
        private string _description;

        private readonly MemberInfo[] _fieldsAndProperties;
        private readonly List<IObjectDescriptor> _innerReflectedObjects = new List<IObjectDescriptor>();


        public ReflectedObject(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Object cannot be null");
            }
            _object = obj;

            var type = obj.GetType();
            _fieldsAndProperties = type.GetMembers(BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var innerObjectsMemberInfo = _fieldsAndProperties.Where(prop => prop.IsDefined(typeof(VisualLogAttribute), false));
            foreach (var innerObjectMemberInfo in innerObjectsMemberInfo)
            {
                var objectToReflect = GetObjectFromType(innerObjectMemberInfo, _object);
                if (objectToReflect == null)
                {
                    _innerReflectedObjects.Add(new NullReflectedObject());                    
                }
                else
                {
                    if (objectToReflect is IEnumerable)
                    {
                        foreach (var objectItem in (IEnumerable)objectToReflect)
                        {
                            _innerReflectedObjects.Add(new ReflectedObject(objectItem));
                        }
                    }
                    else
                    {
                        _innerReflectedObjects.Add(new ReflectedObject(objectToReflect));
                    }
                }
            }
        }

        public IEnumerable<IObjectDescriptor> InnerObjectsDescriptors
        {
            get { return _innerReflectedObjects; }
        }

        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(_description))
                {
                    var descriptionMember =
                        _fieldsAndProperties.FirstOrDefault(
                            prop => prop.IsDefined(typeof (VisualLogDescriptionAttribute), false));


                    object description = GetObjectFromType(descriptionMember, _object);
                    _description = description == null ? _object.ToString() : description.ToString();

                }

                return _description;
            }
        }

        private static object GetObjectFromType(MemberInfo memberInfo, object objectToReflect)
        {
            var member = memberInfo as PropertyInfo;
            object memberValue = null;

            if (member != null)
            {
                memberValue = member.GetGetMethod().Invoke(objectToReflect, null);
            }
            else
            {
                var info = memberInfo as FieldInfo;
                if (info != null)
                {
                    memberValue = info.GetValue(objectToReflect);
                }
            }
            return memberValue;
        }

        public bool Equals(ReflectedObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_object, other._object);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ReflectedObject) obj);
        }
    }
}
