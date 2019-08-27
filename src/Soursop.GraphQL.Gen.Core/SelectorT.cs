using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Soursop.GraphQL.Gen.Core;

namespace Soursop.GraphQL.Gen.Core
{
    public abstract class Selector<TModel, TSelector> : Selector
    {
        private static readonly Dictionary<string, PropertyMappingInfo> _propertyNamesLookup;

        static Selector()
        {
            var properties = typeof(TModel).GetProperties(BindingFlags.Instance | BindingFlags.Public).ToArray();
            _propertyNamesLookup = properties
                .ToDictionary(p => p.Name, p => new PropertyMappingInfo
                {
                    Name = p.Name,
                    JsonName = GetJsonName(p)
                });
        }

        protected override Dictionary<string, PropertyMappingInfo> PropertyInfoMapping => _propertyNamesLookup;

        private static string GetJsonName(PropertyInfo propertyInfo)
        {
            var jsonPropertyAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();

            return jsonPropertyAttribute == null ? propertyInfo.Name : jsonPropertyAttribute.PropertyName;
        }

        protected sealed override bool TryGetJsonPropertyName(string name, out string jsonName)
        {
            if (_propertyNamesLookup.TryGetValue(name, out var mappingInfo))
            {
                jsonName = mappingInfo.JsonName;
                return true;
            }

            jsonName = null;
            return false;
        }

        protected Selector<TModel, TSelector> Select(params Expression<Func<TSelector, object>>[] expressions)
        {
            foreach (var expression in expressions)
            {
                var member = (expression.Body as MemberExpression)?.Member;

                if (member == null)
                {
                    var unary = (expression.Body as UnaryExpression)?.Operand;
                    member = (unary as MemberExpression)?.Member;
                }

                if (member == null)
                {
                    continue;
                }

                if (Selections.TryGetValue(member.Name, out var selection))
                {
                    selection.IsSelected = true;
                }

                if (!SelectedProperties.ContainsKey(member.Name))
                {
                    SelectedProperties.Add(member.Name, PropertyInfoMapping[member.Name]);
                }
            }

            return this;
        }

        public Selector<TModel, TSelector> SelectAll()
        {
            Clear();
            foreach (var pair in PropertyInfoMapping)
            {
                SelectedProperties.Add(pair.Key, pair.Value);
            }

            return this;
        }

        public Selector<TModel, TSelector> Clear()
        {
            SelectedProperties.Clear();
            return this;
        }
    }
}
