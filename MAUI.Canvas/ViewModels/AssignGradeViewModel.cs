﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUI.Canvas.ViewModels
{
    public class AssignGradeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ContentItem _selectedSubmission;
        public ContentItem SelectedSubmission
        {
            get
            {
                return _selectedSubmission;
            }
            set
            {
                _selectedSubmission = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSubmission)));
            }
        }

        public AssignGradeViewModel()
        {
        }
        /*public ObservableCollection<ContentItem> Submissions { 
            get
            {
                return new ObservableCollection<ContentItem>(CourseService.Current.);
            } 
        }*/

        public ObservableCollection<Person> Students
        {
            get
            {
                return new ObservableCollection<Person>(PersonService.Current.People);
            }
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.Courses);
            }
        }
        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(CourseService.Current.Assignments);
            }
        }
        public ObservableCollection<ContentItem> Submissions
        {
            get
            {
                return new ObservableCollection<ContentItem>(CourseService.Current.Assignments.SelectMany(a => a.Submissions));
            }
        }
        public Dictionary<Assignment, ObservableCollection<ContentItem>> AssignmentSubmissions
        {
            get
            {
                return new Dictionary<Assignment, ObservableCollection<ContentItem>>(CourseService.Current.Assignments.ToDictionary(a => a, a => new ObservableCollection<ContentItem>(a.Submissions)));
            }
        }
    }

}
