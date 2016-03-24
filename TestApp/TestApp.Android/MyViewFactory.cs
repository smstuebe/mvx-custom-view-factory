using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TestApp.Android
{
    public class MyViewFactory : Java.Lang.Object, LayoutInflater.IFactory
    {
        private readonly Dictionary<string, Type> _textViewTypes = new Dictionary<string, Type>();
        private static readonly Lazy<MyViewFactory> _instance = new Lazy<MyViewFactory>(() => new MyViewFactory());

        public static MyViewFactory Instance => _instance.Value;

        private MyViewFactory() { }

        public View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            try
            {
                var view = CreateView(name, context, attrs);
                if (view == null)
                    return null;

                view.SetBackgroundColor(Color.Magenta);
                return view;

            }
            catch
            {
                return null;
            }
        }

        private TextView CreateView(string name, Context context, IAttributeSet attrs)
        {
            if (!_textViewTypes.ContainsKey(name))
            {
                switch (name)
                {
                    case "TextView":
                        _textViewTypes.Add(name, typeof(TextView));
                        break;
                    default:
                        return null;
                }
            }

            return Activator.CreateInstance(_textViewTypes[name], context, attrs) as TextView;
        }
    }
}