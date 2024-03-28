using Library.Canvas.Services;
using Library.Canvas.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Library.Canvas.Services;
using Library.Canvas.Models;
using Library.Canvas.Database;

namespace MAUI.Canvas.ViewModels
{
    internal class PersonDetailViewViewModel
    {
        public string Name { get; set; }
        public string ClassificationString { get; set; }
        public int Id { get; set; }
        public PersonDetailViewViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }

        //methods
        public void LoadById(int id)
        {
           // if (id == 0) { return; }
            var person = PersonService.Current.GetById(id) as Person;
            if (person != null)
            {
                this.Name = person.Name;
                this.Id = person.Id;
                this.ClassificationString = ToString();
            }

            //need to implement NotifyPropertyChanged in order for Edit Enrollments to work
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ClassificationString));

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //add "AddPerson" method here
        public void AddPerson()
        {

            if (Id <= 0)
            {
                //breakpoint added on the next line
                PersonService.Current.Add(new Person(Name, ClassificationString));
            }
            else
            {
                var refToUpdate = PersonService.Current.GetById(Id) as Person;
                refToUpdate.Name = Name;
                refToUpdate.Classification = ToString();
            }
            Shell.Current.GoToAsync("//PersonDetail");
        }
        public void DisplayData()
        {
            var people = PersonService.Current.People;
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
        private PersonClassification StringToClass(string s)
        {
            PersonClassification classification;
            switch (s)
            {
                case "S":
                    classification = PersonClassification.Senior;
                    break;
                case "J":
                    classification = PersonClassification.Junior;
                    break;
                case "O":
                    classification = PersonClassification.Sophomore;
                    break;
                case "F":
                default:
                    classification = PersonClassification.Freshman;
                    break;
            }

            return classification;
        }
        /*

        private string ClassToString(PersonClassification pc)
        {
            var classificationString = string.Empty;
            switch (pc)
            {
                case PersonClassification.Senior:
                    classificationString = "S";
                    break;
                case PersonClassification.Junior:
                    classificationString = "J";
                    break;
                case PersonClassification.Sophomore:
                    classificationString = "O";
                    break;
                case PersonClassification.Freshman:
                default:
                    classificationString = "F";
                    break;
            }
            return classificationString;
        }*/
    }
}
