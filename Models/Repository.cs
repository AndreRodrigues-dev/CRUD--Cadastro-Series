using DIO.Series.Interfaces;

namespace DIO.Series.Models 
{
    public class Repository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public void Delete(int Id)
        {
            listSerie[Id].Delete();
        }

        public void Insert(Serie obj)
        {
            listSerie.Add(obj);
        }

        public int nextId()
        {
            return listSerie.Count; //usado .Count pois a quantidade de elementos sempre será uma unidade a mais que o último índice
        }

        public Serie returnForId(int Id)
        {
            return listSerie[Id];
        }

        public void Update(int Id, Serie obj)
        {
            listSerie[Id] = obj;
        }

        public List<Serie> ToList()
        {
            return listSerie;
        }
    }
}