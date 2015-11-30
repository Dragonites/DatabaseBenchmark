﻿using DatabaseBenchmark.Core;
using DatabaseBenchmark.Core.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DatabaseBenchmark.Frames
{
    public partial class TestsFrame : DockContent
    {
        public TestsFrame()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            var tests = ReflectionUtils.GetTests();

            foreach (var test in tests)
            {
                ListViewItem item = new ListViewItem();
                item.Text = test.Name;
                item.Tag = test;

                listView1.Items.Add(item);

            }
        }

        public ITest SelectedTest
        {
            get
            {
                //TODO: Fix it for more test types.
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Selected || !item.Checked)
                     return  (ITest)item.Tag;
                }

                return null;
            }
        }

        public List<ITest> CheckedTests
        {
            get
            {
                if (listView1.CheckedItems.Count == 0)
                    return null;

                List<ITest> tests = new List<ITest>();

                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    var test = (ITest)item.Tag;
                    tests.Add(test);
                }

                return tests;
            }
        }

        public event EventHandler TestClick
        {
            add
            {
                listView1.Click += value;
            }

            remove
            {
                listView1.Click -= value;
            }
        }
    }
}
