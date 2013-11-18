using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VisualLog.Attributes;

namespace VisualLog.GraphCreators.AttributeBased
{
    internal class ReflectedObject
    {
        private readonly object _object;
        private string _description;

        private readonly MemberInfo[] _fieldsAndProperties;
        private readonly List<ReflectedObject> _innerReflectedObjects = new List<ReflectedObject>();


        public ReflectedObject(object obj)
        {
            _object = obj;

            var type = obj.GetType();
            _fieldsAndProperties = type.GetMembers(BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var innerObjectsMemberInfo = _fieldsAndProperties.Where(prop => prop.IsDefined(typeof(VisualLogAttribute), false));
            foreach (var innerObjectMemberInfo in innerObjectsMemberInfo)
            {
                var objectToReflect = GetObjectFromType(innerObjectMemberInfo, _object);
                _innerReflectedObjects.Add(new ReflectedObject(objectToReflect));
            }
        }

        public IEnumerable<ReflectedObject> InnerReflectedObjects
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
                    _description = description.ToString();

                }

                return _description;
            }
        }

        private static object GetObjectFromType(MemberInfo memberInfo, object objectToReflect)
        {
            var member = memberInfo as PropertyInfo;
            object reflectedObject = null;

            if (member != null)
            {
                reflectedObject = member.GetGetMethod().Invoke(objectToReflect, null);
            }
            else
            {
                var info = memberInfo as FieldInfo;
                if (info != null)
                {
                    reflectedObject = info.GetValue(objectToReflect);
                }
            }
            return reflectedObject;
        }
    }
}
