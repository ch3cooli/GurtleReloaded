﻿#region License, Terms and Author(s)
//
// Gurtle - IBugTraqProvider for Google Code
// Copyright (c) 2011 Sven Strickroth. All rights reserved.
//
//  Author(s):
//
//      Sven Strcirkoth <email@cs-ware.de>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion


namespace Gurtle.Providers
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Windows.Forms;

    #endregion

    interface IProvider
    {
        void CancelLoad();
        System.Collections.Generic.IList<string> ClosedStatuses { get; }
        bool IsClosedStatus(string status);
        Uri IssueDetailUrl(int id);
        Uri RevisionDetailUrl(int revision);
        void Load();
        event EventHandler Loaded;
        string Name { get; }
        string ProjectName { get; }
        void Reload();
        bool IsLoaded { get; }
        bool CanHandleIssueUpdates();
        Action DownloadIssues(string project, int start, bool includeClosedIssues, Func<IEnumerable<Issue>, bool> onData, Action<DownloadProgressChangedEventArgs> onProgress, Action<bool, Exception> onCompleted);
        void UpdateIssue(IssueUpdate issue, System.Net.NetworkCredential credential, Action<string> stdout, Action<string> stdout_4);
        ListViewSorter<ListViewItem<Issue>, Issue> GenerateListViewSorter(ListView issueListView);
        void FillSearchItems(ComboBox.ObjectCollection searchSourceItems);
        void GeneratorSubItems(ListViewItem<Issue> item, Issue issue);
        void SetupListView(ListView issueListView);
        bool IsValidProjectName(string name);
        DialogResult ShowOptions(Parameters parameters);
    }
}
