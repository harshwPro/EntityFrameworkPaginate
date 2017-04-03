using EntityFrameworkPaginate;

namespace InfiniteScroll.Dal
{
    public class PlacesDal
    {
        public Page<Trek> GetFilteredPagedTreks(int pageSize, int currentPage, string countryName, int sortBy)
        {
            Page<Trek> treks;
            var filters = new Filters<Trek>();
            filters.Add(!string.IsNullOrEmpty(countryName), x => x.Country.Equals(countryName));

            var sorts = new Sorts<Trek>();
            sorts.Add(sortBy == 1, x => x.DifficultyLevel);
            sorts.Add(sortBy == 2, x => x.DifficultyLevel,true);

            using (var context = new PlacesEntities())
            {
                treks = context.Treks.Paginate(currentPage, pageSize, sorts, filters);
            }

            return treks;
        }
    }
}