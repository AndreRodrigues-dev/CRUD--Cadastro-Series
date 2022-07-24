namespace DIO.Series.Models
{
    public class Serie : GenericClass
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year {get; set;}
        private bool Deleted {get;set;}

        public Serie(int Id, Genre Genre, string Title, string Description, int Year)
        {
            this.Id = Id;
            this.Genre = Genre;
            this.Title = Title;
            this.Description = Description;
            this.Year = Year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            return ($"Genre: {this.Genre}\nTitle: {this.Title}\nDescription: {this.Description}\nYear: {this.Year}\nExcluído: {this.Deleted}");
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public bool returnDeleted()
        {
            return this.Deleted;
        }
        public int returnId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }
}