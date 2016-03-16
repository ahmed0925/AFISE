using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFAxeCreditFull_;
using EFAxeCreditFull;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows;
using Common.Model;
namespace AFISE.ViewModel
{
    public class NavigationProperty : IEquatable<NavigationProperty>
    {
        public string KeyName { get; set; }
        public string NavigationName { get; set; }
        public string ParentTable { get; set; }
        public NavigationProperty()
        { this.NavigationName = ""; }
        public NavigationProperty(string s)
        {
            NavigationName = s;
        }
        public bool Equals(NavigationProperty other)
        {
            return null != other && NavigationName == other.NavigationName;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as NavigationProperty);
        }
        /*  public override string GetHashCode()
          {
              return NavigationName;
          }*/
        public override string ToString()
        {
            return this.NavigationName;
        }
    }

    public class NonNavigationProperty : IEquatable<NonNavigationProperty>
    {
        public string ParentTable { get; set; }
        public string NonNavigationName { get; set; }
        public string NonNavigationType { get; set; }
        public NonNavigationProperty(string s)
        {
            NonNavigationName = s;
        }
        public bool Equals(NonNavigationProperty other)
        {
            return null != other && NonNavigationName == other.NonNavigationName;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as NonNavigationProperty);
        }
        /*public override int GetHashCode()
        {
            return _id;
        }*/


    }

    public class TaskListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null)
            {
                var taskitem = item;

                if (taskitem.GetType() == typeof(NavigationProperty))
                    return
                        element.FindResource("NavigationTemplate") as DataTemplate;
                else
                    return
                        element.FindResource("NonNavigationTemplate") as DataTemplate;
            }

            return null;
        }
    }
    public class MappingViewModel : INotifyPropertyChanged
    {
        public Foreignkey[] ForeignKeys;
        public List<string> EntiyList { get; set; }
        public string selectedItem { get; set; }

        //public List<string> PropertyList { set; get; }
        public List<List<NavigationProperty>> navpro;
        public List<List<NonNavigationProperty>> nonnavpro;
        public List<NavigationProperty> GetNavPropertyList(Type type)
        {
            IEnumerable<PropertyInfo> Pi = DependencyUtilities.GetSingleEntityNavigatorProperties(type);

            // var t= DependencyUtilities.GetReferenceProperies(y);
            //selectedItem = type.Name;
            //OnPropertyChanged("selectedItem");
            var x = Pi.Select(a => new NavigationProperty { NavigationName = a.Name, ParentTable = type.FullName.Substring(16) }).ToList();
            return x;
        }
        public List<NonNavigationProperty> GetNonNavPropertyList(Type type)
        {
            IEnumerable<PropertyInfo> NNP = DependencyUtilities.GetNonNavProps(type);
            var x = NNP.Select(a => new NonNavigationProperty(a.Name) { NonNavigationName = a.Name, NonNavigationType = a.PropertyType.FullName, ParentTable = type.FullName.Substring(16) }).ToList();
            return x;
        }
        public MappingViewModel()
        {

            List<CompositeCollection> temp = new List<CompositeCollection>();

            IEnumerable<Type> typelist = DependencyUtilities.GetTypesInNamespace(Assembly.GetAssembly(typeof(AxeCreditConnection)), "EFAxeCreditFull");
            EntiyList = typelist.Select(t => t.FullName).ToList();
            int i = 0;
            ForeignKeys = QueryUtilities.QueryFK();
            var damn = new List<Foreignkey>(ForeignKeys);
            foreach (var t in typelist)
            {
                CompositeCollection temp2 = new CompositeCollection();
                List<NavigationProperty> v = GetNavPropertyList(t);
                List<NonNavigationProperty> u = GetNonNavPropertyList(t);
                foreach (NavigationProperty n in v)
                {
                    int len = n.NavigationName.Length;
                    while (n.NavigationName[len - 1] >= '0' && n.NavigationName[len - 1] <= '9') len--;
                    //n.NavigationName =
                    string NavigationNameIfMultiple = n.NavigationName.Substring(0, len);

                    var y = ForeignKeys.FirstOrDefault(f => f.FK_Table == n.ParentTable && f.PK_Table == NavigationNameIfMultiple);
                    // ForeignKeys.FirstOrDefault(f => f.table == n.ParentTable && n.NavigationName.Length >= f.referenced_table.Length && f.referenced_table == n.NavigationName.Substring(0, f.referenced_table.Length)).table = " ";
                    if (y != null)
                    {
                        n.KeyName = y.FK_Column;

                        damn.Remove(y);
                        ForeignKeys = damn.ToArray();

                        var todelete = u.SingleOrDefault(ue => ue.NonNavigationName == n.KeyName);
                        if (todelete != null)
                        {
                            u.Remove(todelete);
                        }
                    }
                }
                v.ForEach(k => temp2.Add(k));

                u.ForEach(k => temp2.Add(k));
                temp.Add(temp2);
                i++;
                foreach (var j in v)
                {
                    j.NavigationName = truncateNumbers(j.NavigationName);
                }

            }

            allproperties = temp;



        }
        public string truncateNumbers(string s)
        {
            int len = s.Length;
            while (s[len - 1] >= '0' && s[len - 1] <= '9') len--;
            //n.NavigationName =
            return s.Substring(0, len);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private List<CompositeCollection> allproperties_;
        public List<CompositeCollection> allproperties
        {
            get { return allproperties_; }
            set { allproperties_ = value; OnPropertyChanged("allproperties"); }
        }

    }
}
