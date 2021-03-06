﻿namespace Advanced3DVConfig.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows;
    using System.Xml.Serialization;
    using Advanced3DVConfig.Annotations;
    using Advanced3DVConfig.Model;
    using Advanced3DVConfig.ViewModel.Commands;
    using DialogBoxResult = System.Windows.Forms.DialogResult;
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly Stereo3DKeys _s3DKeys;
        private Dictionary<string, Stereo3DRegistryKey> _viewModelRegistryKeys = new Dictionary<string, Stereo3DRegistryKey>();
        private Dictionary<string, Stereo3DRegistryKey> _previousViewModelRegistryKeys = new Dictionary<string, Stereo3DRegistryKey>();
        #region General
        public uint EnablePersistentStereoDesktop {
            get { return _viewModelRegistryKeys["EnablePersistentStereoDesktop"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["EnablePersistentStereoDesktop"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public bool EnableWindowedMode {
            get { return _viewModelRegistryKeys["EnableWindowedMode"].KeyValue > 0; }
            set
            {
                if (value)
                    _viewModelRegistryKeys["EnableWindowedMode"].KeyValue = 5;
                else
                {
                    EnablePersistentStereoDesktop = 0;
                    _viewModelRegistryKeys["EnableWindowedMode"].KeyValue = 0;
                }
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoSeparation{
            get { return _viewModelRegistryKeys["StereoSeparation"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoSeparation"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoToggle {
            get { return _viewModelRegistryKeys["StereoToggle"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoToggle"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoSeparationAdjustMore {
            get { return _viewModelRegistryKeys["StereoSeparationAdjustMore"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoSeparationAdjustMore"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoSeparationAdjustLess {
            get { return _viewModelRegistryKeys["StereoSeparationAdjustLess"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoSeparationAdjustLess"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoConvergenceAdjustMore {
            get { return _viewModelRegistryKeys["StereoConvergenceAdjustMore"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoConvergenceAdjustMore"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoConvergenceAdjustLess {
            get { return _viewModelRegistryKeys["StereoConvergenceAdjustLess"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoConvergenceAdjustLess"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoToggleMode {
            get { return _viewModelRegistryKeys["StereoToggleMode"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoToggleMode"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }

        #endregion

        #region Advanced
        public uint CycleFrustumAdjust {
            get { return _viewModelRegistryKeys["CycleFrustumAdjust"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["CycleFrustumAdjust"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint MonitorSize {
            get { return _viewModelRegistryKeys["MonitorSize"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["MonitorSize"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoAdjustEnable {
            get { return _viewModelRegistryKeys["StereoAdjustEnable"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoAdjustEnable"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoDefaultOn {
            get { return _viewModelRegistryKeys["StereoDefaultOn"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoDefaultOn"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoVisionConfirmed {
            get { return _viewModelRegistryKeys["StereoVisionConfirmed"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoVisionConfirmed"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint ToggleMemo {
            get { return _viewModelRegistryKeys["ToggleMemo"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["ToggleMemo"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint WriteConfig {
            get { return _viewModelRegistryKeys["WriteConfig"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["WriteConfig"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        #endregion

        #region Screenshots
        public uint SaveStereoImage{
            get { return _viewModelRegistryKeys["SaveStereoImage"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["SaveStereoImage"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint StereoImageType{
            get { return _viewModelRegistryKeys["StereoImageType"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["StereoImageType"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint SnapShotQuality{
            get { return _viewModelRegistryKeys["SnapShotQuality"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["SnapShotQuality"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        #endregion

        #region Laser Sight / Etc.
        public uint LaserSightEnabled
        {
            get { return _viewModelRegistryKeys["LaserSightEnabled"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["LaserSightEnabled"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        public uint ToggleLaserSight
        {
            get { return _viewModelRegistryKeys["ToggleLaserSight"].KeyValue; }
            set
            {
                _viewModelRegistryKeys["ToggleLaserSight"].KeyValue = value;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }

        public bool InterleavePattern
        {
            get
            {
                return (_viewModelRegistryKeys["InterleavePattern0"].KeyValue == 0xFF00FF00) &&
                       (_viewModelRegistryKeys["InterleavePattern1"].KeyValue == 0xFF00FF00);
            }
            set
            {
                uint newInterleaveValue = value ? 0xFF00FF00 : 0x00FF00FF;
                _viewModelRegistryKeys["InterleavePattern0"].KeyValue = newInterleaveValue;
                _viewModelRegistryKeys["InterleavePattern1"].KeyValue = newInterleaveValue;
                ResetASettingCommand.OnCanExecuteChanged();
            }
        }
        #endregion

        public bool SystemPermissionsLocked { get { return _s3DKeys.SystemSetWriteDenied; } }

        #region Commands
        public ResetASettingCommand ResetASettingCommand { get; private set; }
        public SaveSettingsToRegistryCommand SaveSettingsToRegistryCommand { get; private set; }
        public SaveProfileCommand SaveProfileCommand { get; private set; }
        public LoadProfileCommand LoadProfileCommand { get; private set; }
        public OpenImagesDirectoryCommand OpenImagesDirectoryCommand { get; private set; }
        public ToggleSystemRegistryLockCommand ToggleSystemRegistryLockCommand { get; private set; }
        #endregion

        public ViewModel()
        {
            SetUpCommands();
            try{
                _s3DKeys = new Stereo3DKeys();
                _viewModelRegistryKeys = new Dictionary<string, Stereo3DRegistryKey>();
                var keysList = _s3DKeys.Stereo3DSettings;
                foreach (var key in keysList)
                {
                    _viewModelRegistryKeys.Add(key.KeyName, new Stereo3DRegistryKey(key.KeyName, key.KeyValue));
                    _previousViewModelRegistryKeys.Add(key.KeyName, new Stereo3DRegistryKey(key.KeyName, key.KeyValue));
                }
            }
            catch (Exception exception){
                MessageBox.Show(exception.Message, "Registry Error");
            }
        }

        private void SetUpCommands()
        {
            ResetASettingCommand = new ResetASettingCommand(this);
            SaveSettingsToRegistryCommand = new SaveSettingsToRegistryCommand(this);
            SaveProfileCommand = new SaveProfileCommand(this);
            LoadProfileCommand = new LoadProfileCommand(this);
            OpenImagesDirectoryCommand = new OpenImagesDirectoryCommand(this);
            ToggleSystemRegistryLockCommand = new ToggleSystemRegistryLockCommand(this);
            ResetASettingCommand.OnCanExecuteChanged();
        }

        public void SaveSettingsToRegistry()
        {
            List<Stereo3DRegistryKey> changedSettingsToSave = GetChangedSettings();
            if (!changedSettingsToSave.Any())
            {
                MessageBox.Show("No settings changed, therefore no settings saved.",
                    "Settings not saved", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string duplicateHotkeysMessage = CheckForDuplicateHotkeys(changedSettingsToSave);
            if (duplicateHotkeysMessage != null)
            {
                MessageBox.Show(duplicateHotkeysMessage, "Duplicate hotkeys detected", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            string settingsToSaveMessage = CreateChangedSettingsMessage(changedSettingsToSave);
            if (MessageBox.Show(settingsToSaveMessage, "Confirm save", MessageBoxButton.OKCancel,
                    MessageBoxImage.Question) == MessageBoxResult.Cancel) return;
            _s3DKeys.SaveSettingsToRegistry(changedSettingsToSave);

            foreach (var setting in changedSettingsToSave) {
                _previousViewModelRegistryKeys[setting.KeyName].KeyValue = setting.KeyValue;
            }
            MessageBox.Show("Settings saved to registry.", "Save success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private List<Stereo3DRegistryKey> GetChangedSettings()
        {
            var settingsToSave = from s in _viewModelRegistryKeys.Values
                                 where s.KeyValue != _previousViewModelRegistryKeys[s.KeyName].KeyValue
                                 select s;
            return new List<Stereo3DRegistryKey>(settingsToSave);
        }

        public void ResetASetting(string keyName)
        {
            if (keyName == "InterleavePattern")
            {
                _viewModelRegistryKeys["InterleavePattern0"].ResetToDefaultValue();
                _viewModelRegistryKeys["InterleavePattern1"].ResetToDefaultValue();
            }
            else
                _viewModelRegistryKeys[keyName].ResetToDefaultValue();
            OnPropertyChanged(keyName);
            ResetASettingCommand.OnCanExecuteChanged();
        }
        private string CheckForDuplicateHotkeys(List<Stereo3DRegistryKey> keysToCheck) {
            var sb = new StringBuilder();
            var groupedHotkeyValues = from s in keysToCheck.FindAll(k => k.KeyIsHotkey)
                                      group s by s.KeyValue
                                          into d
                                          where d.Count() > 1
                                          select d;
            if (!groupedHotkeyValues.Any()) return null;
            foreach (var groupedHotkeyValue in groupedHotkeyValues) {
                var saveValue = (from v in groupedHotkeyValue
                                 select v.KeyValue).ToArray();
                sb.Append(String.Format("{0} - {1}", String.Join(", ", saveValue), groupedHotkeyValue.Key) +
                          Environment.NewLine);
            }
            sb.Append(Environment.NewLine + "Settings not saved. Please resolve all hotkey conflicts.");
            return sb.ToString();
        }

        private string CreateChangedSettingsMessage(IEnumerable<Stereo3DRegistryKey> settingsChanged)
        {
            var sb = new StringBuilder();
            sb.Append("Settings to save:" + Environment.NewLine);
            foreach (var setting in settingsChanged)
            {
                sb.Append(String.Format("{0}: {1}", setting.KeyName, setting.KeyValue) + Environment.NewLine);
            }
            return sb.ToString();
        }

        public void SaveSettingsProfile()
        {
            var dialog = new System.Windows.Forms.SaveFileDialog()
            {
                DefaultExt = "xml",
                FileName = "3DVRegistryProfile",
                 Filter = "xml files (*.xml)|*.xml",
                InitialDirectory =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "config.xml"),
               
            };
            if (dialog.ShowDialog() != DialogBoxResult.OK) return;
            try
            {
                var xml = new XmlSerializer(typeof (List<SettingsProfileEntry>));
                using (Stream output = dialog.OpenFile())
                    xml.Serialize(output, new SettingsProfile(_viewModelRegistryKeys.Values).KeySettings);
            }
            catch (Exception)
            {
                MessageBox.Show("Your profile could not be saved.",
                    "Profile Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadSettingsProfile()
        {
            var dialog = new System.Windows.Forms.OpenFileDialog()
            {
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                InitialDirectory =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "config.xml"),
            };
            if (dialog.ShowDialog() != DialogBoxResult.OK) return;
            try
            {
                var serializer = new XmlSerializer(typeof(List<SettingsProfileEntry>));
                List<SettingsProfileEntry> list;
                using (Stream input = dialog.OpenFile())
                    list = (List<SettingsProfileEntry>) serializer.Deserialize(input);

                foreach (SettingsProfileEntry entry in list)
                {
                    if (!_viewModelRegistryKeys.ContainsKey(entry.KeyName) ||
                        entry.Value == _viewModelRegistryKeys[entry.KeyName].KeyValue) continue;
                    _viewModelRegistryKeys[entry.KeyName] = new Stereo3DRegistryKey(entry.KeyName, entry.Value);
                    OnPropertyChanged(entry.KeyName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Your profile could not be loaded.",
                    "Profile Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public object GetCurrentKeyValueByString(string keyName)
        {
            if (keyName == "InterleavePattern")
                return _viewModelRegistryKeys["InterleavePattern0"].KeyValue;
            if(!_viewModelRegistryKeys.ContainsKey(keyName))
                throw new ArgumentException($"No key named {keyName} was found.", nameof(keyName));
            return _viewModelRegistryKeys[keyName].KeyValue;
        }

        public void ToggleSystemRegistryLock()
        {
            _s3DKeys.ToggleSystemKeyPermissions();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
