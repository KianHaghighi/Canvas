using Library.Canvas.Services;
using Library.Canvas.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AddModuleViewViewModel : INotifyPropertyChanged
{
    private string _moduleName;
    private string _moduleDescription;
    private CourseService _courseService;

    public AddModuleViewViewModel(CourseService courseService)
    {
        _courseService = courseService;
        AddModuleCommand = new Command(AddModule);
    }

    public string ModuleName
    {
        get { return _moduleName; }
        set
        {
            _moduleName = value;
            OnPropertyChanged(nameof(ModuleName));
        }
    }

    public string ModuleDescription
    {
        get { return _moduleDescription; }
        set
        {
            _moduleDescription = value;
            OnPropertyChanged(nameof(ModuleDescription));
        }
    }

    public Command AddModuleCommand { get; }

    private void AddModule()
    {
        var newModule = new Module(ModuleName, ModuleDescription);
        //var course = _courseService.Get(SelectedCourse.Code);
        var course = new Course();
        _courseService.AddOrUpdateModule(course, newModule);
        
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

