using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace OpenTracDashboard
{
    /// <summary>
    /// An assistant to help with common issues with the DataGridView.
    /// Usage: Let's say we have a grid based on a Heats table (assume curly is angle bracket) called myDgvHeat
    /// So declare: 
    ///     DataGridViewAssistant{Heat} dgvaHeat = new DataGridViewAssistant{Heat}(myDgvHeat);
    /// And then set the source:
    ///     dgvaHeat = context.Heats
    /// It handles events of CellFormatting, DataError, and DataSourceChanged, and allows column sorting,
    /// for a more pleasurable viewing experience.
    /// </summary>
    public class DataGridViewAssistant<T>
    {
        public DataGridView MyDgv { get; set; }

        /// <summary>
        /// Changes the cellfont
        /// </summary>
        public Font CellFont { get; set; }

        /// <summary>
        /// How to format doubles
        /// </summary>
        public int DoublesPrecision { get; set; }

        /// <summary>
        /// Columns that should be excluded.
        /// This is ignored if ColumnsToInclude is specified.
        /// </summary>
        public List<string> ColumnsToExclude { get; set; }

        /// <summary>
        /// Display these columns, and in this order.
        /// </summary>
        public List<string> ColumnsToInclude { get; set; }

        /// <summary>
        /// Do not include columns that are not basic system types.
        /// These are generally foreign key columns that are added by EF.
        /// </summary>
        public bool ExcludeNonSystemColumns { get; set; }

        /// <summary>
        /// Exclude columns that are not easily read by humans ( GUID, ...)
        /// </summary>
        public bool ExcludeNonHumanColumns { get; set; }

        /// <summary>
        /// Given a List, set the datasource of our underlying DGV to sortable/bindable
        /// so that the columns can be sorted.
        /// </summary>
        public List<T> DataSource
        {
            set
            {
                SortableBindingList<T> sbList = new SortableBindingList<T>(value);
                MyDgv.DataSource = sbList;
            }
        }

        /// <summary>
        /// Constructor.
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        public DataGridViewAssistant(DataGridView dgv)
        {
            try
            {
                MyDgv = dgv;

                MyDgv.DataSourceChanged += MyDgv_DataSourceChanged;
                MyDgv.CellFormatting += MyDgv_CellFormatting;
                MyDgv.DataError += MyDgv_DataError;

                ColumnsToExclude = null;
                ColumnsToInclude = null;

                ExcludeNonHumanColumns = true;
                ExcludeNonSystemColumns = true;

                CellFont = null;
                DoublesPrecision = 2;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("DGVAssistant Constructor. Err={0}", ex.ToString()));
            }

        }




        private void MyDgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewHelpers.CheckDataError(e);
        }

        private void MyDgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                DataGridViewHelpers.FixFormatting(dgv, e);

                if (CellFont != null)
                    e.CellStyle.Font = CellFont; // new Font("Arial", 16.0F, GraphicsUnit.Pixel);

                if (DoublesPrecision != int.MaxValue)
                    DataGridViewHelpers.FormatDoubles(dgv, e);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Name={0} Err={1}", MyDgv.Name, ex.ToString()));
            }
        }

        /// <summary>
        /// The data source changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyDgv_DataSourceChanged(object sender, EventArgs e)
        {
            if (ExcludeNonSystemColumns)
                DataGridViewHelpers.RemoveNonSystemColumns(MyDgv);

            if (ExcludeNonHumanColumns)
                DataGridViewHelpers.RemoveNonUserColumns(MyDgv);

            if (ColumnsToInclude != null)
            {
                DataGridViewHelpers.IncludeColumnsByName(MyDgv, ColumnsToInclude);
            }
            else if (ColumnsToExclude != null)
            {
                DataGridViewHelpers.ExcludeColumnsByName(MyDgv, ColumnsToExclude);
            }
        }
    } // class


    /// <summary>
    /// An attribute so we can ignore fields or change their formatting.
    /// </summary>
    public class DataGridViewHelperAttribute : Attribute
    {
        public DataGridViewHelperAttribute()
        {
            Ignore = false;
        }

        /// <summary>
        /// Do not display the property.
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// Use this format when displaying the property.
        /// Same formatting as the ToString method. 
        /// Example: to set a float to single decimal, use "0.0".
        /// </summary>
        public string Format { get; set; }

    }

    /// <summary>
    /// Helpers for displaying classes in a WinForms DataGridView control.
    /// </summary>
    public static class DataGridViewHelpers
    {

        /// <summary>
        /// Correct formatting to show object name for columns trying
        /// to bind to EF objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void FixFormatting(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {
            string name = "??";

            try
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                DataGridViewColumn col = dgv.Columns[e.ColumnIndex];

                if (row.DataBoundItem != null)
                {
                    string dpn = col.DataPropertyName;
                    var vv = row.DataBoundItem;
                    //name = row.DataBoundItem.ToString();

                    string firstPart = row.DataBoundItem.GetType().Name;
                    name = firstPart;
                    if (firstPart.Length > 15)
                        firstPart = firstPart.Substring(0, 14) + "...";

                    string colType = col.ValueType.FullName;

                    // If the column is not a System type, and isn't an enumberable,
                    // then set the value to be the name of the object.
                    if (!colType.StartsWith("System.") && !colType.Contains(".Enum"))
                    {
                        e.Value = string.Format("({0})", col.ValueType.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("DataGridView Databound Name={0} Err={1}", name, ex.ToString()));
            }
        } // method

        /// <summary>
        /// Correct formatting to show object name for columns trying
        /// to bind to EF objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CheckAttributeFormat(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string name = "??";

            try
            {
                DataGridView grid = (DataGridView)sender;
                DataGridViewRow row = grid.Rows[e.RowIndex];
                DataGridViewColumn col = grid.Columns[e.ColumnIndex];

                if (row.DataBoundItem != null)
                {
                    string dpn = col.DataPropertyName;
                    //string ss = row.DataBoundItem.ToString();
                    //name = row.DataBoundItem.ToString();

                    string firstPart = row.DataBoundItem.GetType().Name;
                    if (firstPart.Length > 15)
                        firstPart = firstPart.Substring(0, 14) + "...";

                    Type T = row.DataBoundItem.GetType();

                    foreach (MethodInfo method in T.GetMethods())
                    {
                        foreach (object attribute in method.GetCustomAttributes(true))
                        {
                            if (attribute is DataGridViewHelperAttribute)
                            {
                                DataGridViewHelperAttribute att = (DataGridViewHelperAttribute)attribute;
                                //e.Value = e.Value.ToString(att.Format);
                                //Todo: Try to figure out how to make this work in a general fashion.
                            }
                        } // for
                    } // for

                    string colType = col.ValueType.FullName;

                    if (!colType.StartsWith("System."))
                    {
                        e.Value = string.Format("({0})", col.ValueType.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("DataGridView Databound Name={0} Err={1}", ex.ToString()));
            }
        } // method

        /// <summary>
        /// Correct formatting to show object name for columns trying
        /// to bind to EF objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void FormatDoubles(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {

            string dpn = "??";
            try
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                DataGridViewColumn col = dgv.Columns[e.ColumnIndex];

                if (row.DataBoundItem != null)
                {
                    dpn = col.DataPropertyName;
                    //if ( dpn.ToLower() == "state" )
                    //    { bool stopHere = true; }

                    var obj = row.DataBoundItem;
                    //string name = row.DataBoundItem.ToString();

                    // You could check for what the databound item is here
                    //string firstPart = row.DataBoundItem.GetType().Name;
                    //if (firstPart.Length > 15)
                    //    firstPart = firstPart.Substring(0, 14) + "...";

                    string colType = col.ValueType.FullName;

                    if (colType == "System.Double")
                    {
                        e.Value = Math.Round((double)e.Value, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Err={0}", ex.ToString()));
            }
        } // method

        /// <summary>
        /// Throw errors other than the EF specific error.
        /// </summary>
        /// <param name="e"></param>
        public static void CheckDataError(DataGridViewDataErrorEventArgs e)
        {
            string ss = e.Exception.ToString();
            if (ss.Contains("Property accessor") && ss.Contains("System.Data.Entity.DynamicProxies"))
                return;

            throw new ApplicationException(e.Exception.ToString());
        }

        /// <summary>
        /// Use this in the _DataSourceChanged event of the DataGridView to
        /// remove the non-system columns, such as EF relationships.
        /// </summary>
        /// <param name="sender"></param>
        public static void RemoveNonSystemColumns(DataGridView dgv)
        {
            try
            {

                List<String> columnsToRemove = new List<string>();

                foreach (DataGridViewColumn dgvc in dgv.Columns)
                {
                    string dpn = dgvc.DataPropertyName;
                    if ( dpn.ToLower() == "state")
                    { bool stopHere = true; }

                    // Leave Enums and System columns. Remove the others, which are objects
                    // Enums starts with the namespace, a dot and then Enum...
                    string colType = dgvc.ValueType.FullName;
                    if (!colType.StartsWith("System.") && !colType.ToLower().Contains(".enum") )
                    {
                        columnsToRemove.Add(dgvc.Name);
                    }
                } // for

                foreach (string colName in columnsToRemove)
                {
                    dgv.Columns.Remove(colName);
                } // for removing non-system columns

            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.ToString());
            }
        } // method

        /// <summary>
        /// Use this in the _DataSourceChanged event of the DataGridView to
        /// remove the columns that are of not useful to humans, such as Guid.
        /// </summary>
        /// <param name="sender"></param>
        public static void RemoveNonUserColumns(DataGridView dgv)
        {
            try
            {
                List<String> columnsToRemove = new List<string>();

                foreach (DataGridViewColumn dgvc in dgv.Columns)
                {
                    string colType = dgvc.ValueType.FullName;
                    if (colType.ToLower().Contains(".guid"))
                    {
                        columnsToRemove.Add(dgvc.Name);
                    }
                    if (colType.ToLower().Contains(".timestamp"))
                    {
                        columnsToRemove.Add(dgvc.Name);
                    }
                } // for

                foreach (string colName in columnsToRemove)
                {
                    dgv.Columns.Remove(colName);
                } // for removing non-system columns

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        } // method

        /// <summary>
        /// Use this in the _DataSourceChanged event of the DataGridView to
        /// include the columns desired on the grid, and in the given order.
        /// </summary>
        /// <param name="sender"></param>
        public static void IncludeColumnsByName(DataGridView dgv, List<string> nameList)
        {
            try
            {
                List<String> columnsToRemove = new List<string>();
                Dictionary<string, Tuple<string, int>> nameDict = new Dictionary<string, Tuple<string, int>>();

                // Build a dictionary that preserves the column order.
                int ii = 0;
                foreach (string name in nameList)
                {
                    if (!nameDict.ContainsKey(name.ToLower()))
                    {
                        Tuple<string, int> t1 = new Tuple<string, int>(name, ii);
                        nameDict.Add(name.ToLower(), t1);
                        ii++;
                    }
                }

                foreach (DataGridViewColumn dgvc in dgv.Columns)
                {
                    string colType = dgvc.ValueType.FullName;

                    Tuple<string, int> tpl = null;
                    if (!nameDict.TryGetValue(dgvc.Name.ToLower(), out tpl))
                    {
                        columnsToRemove.Add(dgvc.Name);
                    }
                    else
                    {
                        dgvc.DisplayIndex = tpl.Item2;
                    }
                } // for

                // Get rid of the un-needed columns
                foreach (string colName in columnsToRemove)
                {
                    dgv.Columns.Remove(colName);
                } // for removing non-system columns

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        } // method

        /// <summary>
        /// Use this in the _DataSourceChanged event of the DataGridView to
        /// remove the columns that are of not desired on the grid
        /// </summary>
        /// <param name="sender"></param>
        public static void ExcludeColumnsByName(DataGridView dgv, List<string> nameList)
        {
            try
            {
                List<String> columnsToRemove = new List<string>();
                Dictionary<string, string> nameDict = nameList.ToDictionary(rr => rr.ToLower(), rr => rr);

                foreach (DataGridViewColumn dgvc in dgv.Columns)
                {
                    string colType = dgvc.ValueType.FullName;

                    if (nameDict.ContainsKey(dgvc.Name.ToLower()))
                    {
                        columnsToRemove.Add(dgvc.Name);
                    }
                } // for

                foreach (string colName in columnsToRemove)
                {
                    dgv.Columns.Remove(colName);
                } // for removing non-system columns

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        } // method

    } // class



    /// <summary>
    /// Courtesy of Be.Timvw: http://www.timvw.be/2007/02/22/presenting-the-sortablebindinglistt/
    /// Used for the Sortable Binding List, which - when bound to a DataGridView - allows the user to sort on columns.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyComparer<T> : IComparer<T>
    {
        private readonly IComparer comparer;
        private PropertyDescriptor propertyDescriptor;
        private int reverse;

        public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
        {
            this.propertyDescriptor = property;
            Type comparerForPropertyType = typeof(Comparer<>).MakeGenericType(property.PropertyType);
            this.comparer = (IComparer)comparerForPropertyType.InvokeMember("Default", BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public, null, null, null);
            this.SetListSortDirection(direction);
        }

        #region IComparer<T> Members

        public int Compare(T x, T y)
        {
            return this.reverse * this.comparer.Compare(this.propertyDescriptor.GetValue(x), this.propertyDescriptor.GetValue(y));
        }

        #endregion

        private void SetPropertyDescriptor(PropertyDescriptor descriptor)
        {
            this.propertyDescriptor = descriptor;
        }

        private void SetListSortDirection(ListSortDirection direction)
        {
            this.reverse = direction == ListSortDirection.Ascending ? 1 : -1;
        }

        public void SetPropertyAndDirection(PropertyDescriptor descriptor, ListSortDirection direction)
        {
            this.SetPropertyDescriptor(descriptor);
            this.SetListSortDirection(direction);
        }
    } // class

    /// <summary>
    /// Courtesy of Be.Timv
    /// A binding list that can be bound to a DataGridView so the user can sort on columns.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortableBindingList<T> : BindingList<T>
    {
        private readonly Dictionary<Type, PropertyComparer<T>> comparers;
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        public SortableBindingList()
            : base(new List<T>())
        {
            this.comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        public SortableBindingList(IEnumerable<T> enumeration)
            : base(new List<T>(enumeration))
        {
            this.comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return this.isSorted; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return this.propertyDescriptor; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return this.listSortDirection; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)this.Items;

            Type propertyType = property.PropertyType;
            PropertyComparer<T> comparer;
            if (!this.comparers.TryGetValue(propertyType, out comparer))
            {
                comparer = new PropertyComparer<T>(property, direction);
                this.comparers.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndDirection(property, direction);
            itemsList.Sort(comparer);

            this.propertyDescriptor = property;
            this.listSortDirection = direction;
            this.isSorted = true;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            this.isSorted = false;
            this.propertyDescriptor = base.SortPropertyCore;
            this.listSortDirection = base.SortDirectionCore;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = this.Count;
            for (int i = 0; i < count; ++i)
            {
                T element = this[i];
                if (property.GetValue(element).Equals(key))
                {
                    return i;
                }
            }

            return -1;
        } // method

    } // class

}
