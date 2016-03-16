using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFAxeCreditFull_
{
    public static class DependencyUtilities
    {

        public static Type[] GetTypesInNamespace(System.Reflection.Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
        public static IEnumerable<PropertyInfo> GetNonNavProps(Type entityType)
        {
            IEnumerable<PropertyInfo> all = entityType.GetProperties();
            IEnumerable<PropertyInfo> nav = GetNaviProps(entityType);
            return all.Except(nav);
        }
        public static IEnumerable<PropertyInfo> GetNaviProps(Type entityType) // Call with typeof(entity) 
        {
            return entityType.GetProperties()
                             .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string)) || p.PropertyType.Namespace == entityType.Namespace);
            // .Select(p => p.Name)
            //.ToArray();
        }

        public static object GetEntityFieldValue(this object entityObj, string propertyName)
        {
            var pro = entityObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).First(x => x.Name == propertyName);
            return pro.GetValue(entityObj, null);

        }
        public static IEnumerable<PropertyInfo> GetSingleEntityNavigatorProperties(Type entityObj)
        {
            var props = entityObj.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanWrite && x.GetGetMethod().IsVirtual && x.PropertyType.IsGenericType == false);
            return props;
        }

        public static IEnumerable<PropertyInfo> GetManyRelatedEntityNavigatorProperties(Type entityObj)
        {
            var props = entityObj.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanWrite && x.GetGetMethod().IsVirtual && x.PropertyType.IsGenericType == true);
            return props;
        }

        public static bool HasAnyRelation(Type entityObj)
        {

            var collectionProps = GetManyRelatedEntityNavigatorProperties(entityObj);


            foreach (var item in collectionProps)
            {
                var collectionValue = GetEntityFieldValue(entityObj, item.Name);
                if (collectionValue != null && collectionValue is IEnumerable)
                {
                    var col = collectionValue as IEnumerable;
                    if (col.GetEnumerator().MoveNext())
                    {
                        return true;
                    }

                }
            }
            return false;
        }


        public static void GetTypeObject(Object entityObj)
        {
            var ObjectT = entityObj.GetType();
            Type[] Types = new Type[10];
            DependencyUtilities.GetTypesInNamespace(Assembly.GetExecutingAssembly(), "EntityFrameworkDatabaseFirst");
            var i = Types.Select(t => t.Name == ObjectT.Name);



        }

       public static IEnumerable<string> GetReferenceProperies<T>(DbContext context)
        {
            var oc = ((IObjectContextAdapter)context).ObjectContext;
            var entityType = oc.MetadataWorkspace.GetItems(DataSpace.OSpace)
                               .OfType<EntityType>()
                               .FirstOrDefault(et => et.Name == typeof(T).Name);
            if (entityType != null)
            {
                foreach (NavigationProperty np in entityType.NavigationProperties
                        .Where(p => p.ToEndMember.RelationshipMultiplicity
                                             == RelationshipMultiplicity.One
                                 || p.ToEndMember.RelationshipMultiplicity
                                             == RelationshipMultiplicity.ZeroOrOne))
                {
                    yield return np.Name;
                }
            }
        }



    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
