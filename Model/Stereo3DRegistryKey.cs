﻿using System;

namespace Advanced3DVConfig.Model
{
    public class Stereo3DRegistryKey : IEquatable<Stereo3DRegistryKey>
    {
        public string KeyName { get; private set; }
        public int KeyValue { get; set; }
        public int KeyDefaultValue { get; private set; }
        public bool KeyIsHotkey { get; private set; }
        public Stereo3DRegistryKey(string keyName, int keyValue)
        {
            KeyName = keyName;
            KeyValue = keyValue;
            KeyDefaultValue = Stereo3DRegistryKeyDefaults.GetDefaultKeyValue(keyName);
            KeyIsHotkey = Stereo3DRegistryKeyDefaults.KeyIsHotkey(keyName);
        }

        public bool ResetToDefaultValue()
        {
            if (KeyDefaultValue < 0) return false;
            KeyValue = KeyDefaultValue;
            return true;
        }

        #region EqualityMembers

        public bool Equals(Stereo3DRegistryKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(KeyName, other.KeyName) && KeyValue == other.KeyValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Stereo3DRegistryKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((KeyName != null ? KeyName.GetHashCode() : 0)*397) ^ KeyValue;
            }
        }

        public static bool operator ==(Stereo3DRegistryKey left, Stereo3DRegistryKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Stereo3DRegistryKey left, Stereo3DRegistryKey right)
        {
            return !Equals(left, right);
        }

        #endregion

    }
}
