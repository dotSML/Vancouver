﻿using System;
using Vancouver.Aids;

namespace Vancouver.Core {
    public abstract class Archetype {
        protected internal string
            getString(ref string field, string value = Constants.Unspecified) {
            if (string.IsNullOrWhiteSpace(field)) field = (value ?? string.Empty).Trim();
            return field;
        }
        protected internal void setValue<T>(ref T field, T value) {
            field = value;
        }
        protected internal T getObject<T>(ref T field) where T : class, new() {
            field = field ?? new T();
            return field;
        }
        protected internal T getValue<T>(ref T field, T value) where T: IComparable {
            if (isNull(value)) value = default(T);
            if (isNull(field)) field = value;
            return field;
        }
        protected internal T getMinValue<T>(ref T field, ref T value) where T : IComparable {
            Sort.Upwards(ref field, ref value);
            return field;
        }
        protected internal T getMaxValue<T>(ref T field, ref T value) where T : IComparable {
            Sort.Upwards(ref value, ref field);
            return field;
        }
        public virtual bool Contains(string searchString) {
            if (string.IsNullOrEmpty(searchString)) return true;
            searchString = searchString.ToLower();
            var values = GetClass.ReadWritePropertyValues(this);
            foreach (var value in values) {
                if (value is null) continue;
                if (value.ToString().ToLower().Contains(searchString)) return true;
            }

            return GetType().Name.ToLower().Contains(searchString);
        }
        protected static bool isNull(object o) {
            return o is null;
        }
        protected bool isSpaces(string s) {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}




