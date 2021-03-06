﻿// Copyright (c) 2015, Dijji, and released under Ms-PL.  This can be found in the root of this distribution. 

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace RepairTasks
{

    public enum Source
    {
        Recycle,
        Zip,
        Other
    }

    class State : INotifyPropertyChanged
    {
        private ObservableCollection<Report> reports = new ObservableCollection<Report>();
        private List<Target> targets = new List<Target>();
        private bool canScan = true;
        private bool canRepair = false;
        private bool canUnplug = false;
        private string status;

        public ObservableCollection<Report> Reports { get { return reports; } }
        public List<Target> Targets { get { return targets; } }
        public string Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
        public bool CanScan { get { return canScan; } set { canScan = value; OnPropertyChanged("CanScan"); } }
        public bool CanRepair { get { return canRepair; } set { canRepair = value; OnPropertyChanged("CanRepair"); } }
        public bool CanUnplug { get { return canUnplug; } set { canUnplug = value; OnPropertyChanged("CanUnplug"); } }
        public Source Source { get; set; }
        public string SourcePath { get; set; }
        public string BackupPath { get; set; }

        public void Reset()
        {
            targets.Clear();
            reports.Clear();
            Status = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
