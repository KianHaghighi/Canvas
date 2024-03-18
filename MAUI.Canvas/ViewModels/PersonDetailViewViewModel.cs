using Library.Canvas.Services;
using Library.Canvas.Models;

namespace MAUI.Canvas.ViewModels
{
    internal class PersonDetailViewViewModel
    {
        public string Name { get; set; }
        public string ClassificationString { get; set; }
        public int Id { get; set; }

        //methods
        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var person = PersonService.Current.GetById(id) as Person;
            if (person != null)
            {
                Name = person.Name;
                Id = person.Id;
                ClassificationString = ToString();
            }

            //NotifyPropertyChanged(nameof(Name));
            //NotifyPropertyChanged(nameof(ClassificationString));

        }
        //add "AddPerson" method here
        public void AddPerson()
        {

            if (Id <= 0)
            {
                PersonService.Current.Add(new Person(Name, ClassificationString));
            }
            else
            {
                var refToUpdate = PersonService.Current.GetById(Id) as Person;
                refToUpdate.Name = Name;
                refToUpdate.Classification = ToString();
            }
            Shell.Current.GoToAsync("//Instructor");
        }
}
}
