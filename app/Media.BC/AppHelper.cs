using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Media.BE;

namespace Media.BC
{
    /// <summary>
    /// this interface is implemented by all classes that wish to be registered as an app helper.
    /// </summary>
    public interface IAppHelper
    {
        /// <summary>
        /// locates the items (ie: performs a search) using the data in the context. the context
        /// will (possibly) contain data in fields declared as inputFields in the helper contract
        /// </summary>
        AppHelperItem[] LocateItems(AppHelperContext context);
        /// <summary>
        /// loads the specified item into the context, setting values as declared as outputFields 
        /// in the helper contract (defined in the Helpers.xml file)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="listener"></param>
        /// <param name="context"></param>
        bool LoadItem(AppHelperItem item, AppHelperContext context);

        /// <summary>
        /// returns the name of this app helper; used in dropdown lists etc
        /// </summary>
        string Name
        {
            get;
        }
    }
   
    public class AppHelperException : Exception
    {
        public AppHelperException(string msg)
            : base(msg)
        {
        }
    }
    public interface AppHelperItem
    {
        string Name { get; }
        object Value { get; }
    }
    public class SimpleAppHelperContext : AppHelperContext
    {
        Dictionary<string, object> ht = new Dictionary<string, object>();

        #region AppHelperContext Members

        private string[] inputFields;
        public string[] InputFields
        {
            get
            {
                return inputFields;
            }
            set
            {
                inputFields = value;
            }
        }

        private string[] outputFields;
        public string[] OutputFields
        {
            get
            {
                return outputFields;
            }
            set
            {
                outputFields = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ht.GetEnumerator();
        }
        public object this[string fieldName]
        {
            get
            {
                if( ht.ContainsKey(fieldName) )
                    return ht[fieldName];
                return null;
            }
            set
            {
                ht[fieldName] = value;
            }

        }

        #endregion
    }
    public class SimpleAppHelperItem : AppHelperItem
    {
        private String _name;
        private object _val;
        #region AppHelperItem Members
        public SimpleAppHelperItem(String name, Object details)
        {
            this._name = name;
            this._val = details;
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public object Value
        {
            get
            {
                return _val;
            }
        }
        #endregion
    }
}
